using System.Drawing;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        Labirint l;
        public Form1()
        {
            InitializeComponent();
            Options();
            StartGame();
            l.MovePlayer();

        }

        public void Options()
        {
            Text = "Maze";

            BackColor = Color.FromArgb(255, 92, 118, 137);

            int sizeX = 40;
            int sizeY = 20;

            Width = sizeX * 16 + 16;
            Height = sizeY * 16 + 40;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void StartGame() {
            l = new Labirint(this, 40, 20);
            l.Show();
        }
    }
}
