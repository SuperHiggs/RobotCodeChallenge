namespace RobotCodeChallenge.Models
{
    public class Table
    { 
        public int Width { get; }
        public int Height { get; }

        public Table(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsWithinWidthBound(int value) => (value >= 0 && value <= Width);

        public bool IsWithinHeightBound(int value) => (value >= 0 && value <= Height);
     

    }
}
