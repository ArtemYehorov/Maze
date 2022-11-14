using System;
using System.Windows.Forms;
using System.Drawing;
using static Maze.MazeObject;

namespace Maze
{
    class Labirint
    {
        public int height; // высота лабиринта (количество строк)
        public int width; // ширина лабиринта (количество столбцов в каждой строке)

        public MazeObject[,] maze;
        public PictureBox[,] images;

        public static Random r = new Random();
        public Form parent;

        public Labirint(Form parent, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.parent = parent;

            maze = new MazeObject[height, width];
            images = new PictureBox[height, width];

            Generate();
        }

        private int smileX = 0;
        private int smileY = 2;

        MazeObject.MazeObjectType current;

        bool move = false;

        private void Generate()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    current = MazeObject.MazeObjectType.HALL;
                    // в 1 случае из 5 - ставим стену
                    if (r.Next(5) == 0)
                    {
                        current = MazeObject.MazeObjectType.WALL;
                    }

                    // в 1 случае из 250 - кладём денежку
                    if (r.Next(250) == 0)
                    {
                        current = MazeObject.MazeObjectType.MEDAL;
                    }

                    // в 1 случае из 250 - размещаем врага
                    if (r.Next(250) == 0)
                    {
                        current = MazeObject.MazeObjectType.ENEMY;
                    }

                    // стены по периметру обязательны
                    if (y == 0 || x == 0 || y == height - 1 | x == width - 1)
                    {
                        current = MazeObject.MazeObjectType.WALL;
                    }

                    // наш персонажик
                    if (x == smileX && y == smileY)
                    {
                        current = MazeObject.MazeObjectType.CHAR;
                    }

                    // есть выход, и соседняя ячейка справа всегда свободна
                    if (x == smileX + 1 && y == smileY || x == width - 1 && y == height - 3)
                    {
                        current = MazeObject.MazeObjectType.HALL;
                    }
                    
                    maze[y, x] = new MazeObject(current);
                    images[y, x] = new PictureBox();
                    images[y, x].Location = new Point(x * maze[y, x].width, y * maze[y, x].height);
                    images[y, x].Parent = parent;
                    images[y, x].Width = maze[y, x].width;
                    images[y, x].Height = maze[y, x].height;
                    images[y, x].BackgroundImage = maze[y, x].texture;
                    images[y, x].Visible = false;
                }
            }
        }

        public void MovePlayer()
        {
            if (Keys.KeyCode == Keys.Enter)
            {
                move = true;
            }
            while (move)
            {
                if (Keys.KeyCode == Keys.Left)
                {
                    smileX--;
                    maze[smileY,smileX] = new MazeObject(current);
                    images[smileY, smileX] = new PictureBox();
                    Show();
                }
                if (Keys.KeyCode == Keys.Right)
                {
                    smileX++;
                    maze[smileY, smileX] = new MazeObject(current);
                    images[smileY, smileX] = new PictureBox();
                    Show();
                }
                if (Keys.KeyCode == Keys.Up)
                {
                    smileY--;
                    maze[smileY, smileX] = new MazeObject(current);
                    images[smileY, smileX] = new PictureBox();
                    Show();
                }
                if (Keys.KeyCode == Keys.Down)
                {
                    smileY++;
                    maze[smileY, smileX] = new MazeObject(current);
                    images[smileY, smileX] = new PictureBox();
                    Show();
                }
            }
        }

        public void Show()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    images[y, x].Visible = true;
                }
            }
        }
    }
}