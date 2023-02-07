using System;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public abstract AntType Type { get; }
        public abstract Position Position { get; set; }
        public abstract void InicializePosition();
        public abstract void Act();
        public static bool CheckForValidMove(int width, Position position)
        {
            int x = position.X;
            int y = position.Y;
            if (x - 1 >= 0 && x + 1 < width && y - 1 >= 0 && y + 1 < width) return true;
            return false;
        }
        public static Direction ChooseRandomDirection()
        {
            Random random = new Random();
            Array items = Enum.GetValues(typeof(Direction));
            int value = Convert.ToInt32(Math.Floor(random.NextDouble() * items.Length));
            return (Direction)items.GetValue(value);
        }
        public static int ChooseRandomCoordinate(int width)
        {
            Random random = new Random();
            int value = Convert.ToInt32(Math.Floor(random.NextDouble() * width));
            return value;
        }
    }
}
