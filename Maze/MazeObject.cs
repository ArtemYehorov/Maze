using System.Drawing;

namespace Maze
{
    class MazeObject
    {
        public enum MazeObjectType { HALL, WALL, MEDAL, ENEMY, CHAR };

        public Bitmap[] images = {new Bitmap(@"pics\hall.png"),
            new Bitmap(@"pics\wall.png"),
            new Bitmap(@"pics\medal.png"),
            new Bitmap(@"pics\enemy.png"),
            new Bitmap(@"pics\player.png")};

        public MazeObjectType type;
        public int width;
        public int height;
        public Image texture;

        public MazeObject(MazeObjectType type)
        {
            this.type = type;
            width = 16;
            height = 16;
            texture = images[(int)type];
        }
    }
}