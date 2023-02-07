namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : Ant
    {
        public override AntType Type => AntType.Drone;
        public override Position Position { get; set; }
        private Position queenPosition;
        private int _width;

        public Drone(Position position)
        {
            _width = position.X * 2 + 1;
            queenPosition = position;
            InicializePosition();
        }

        public override void InicializePosition()
        {
            bool isValidPosition = false;
            while (!isValidPosition)
            {
                int x = ChooseRandomCoordinate(_width);
                int y = ChooseRandomCoordinate(_width);

                if (x != queenPosition.X && y != queenPosition.Y)
                {
                    isValidPosition = true;
                    Position = new Position(x, y);
                }
            }
        }

        public override void Act()
        {
            Direction direction = ChooseRandomDirection();
            switch (direction)
            {
                case Direction.North:
                    if (CheckForValidMove(_width, Position)) Position.X -= 1;
                    break;
                case Direction.South:
                    if (CheckForValidMove(_width, Position)) Position.X += 1;
                    break;
                case Direction.West:
                    if (CheckForValidMove(_width, Position)) Position.Y += 1;
                    break;
                case Direction.East:
                    if (CheckForValidMove(_width, Position)) Position.Y -= 1;
                    break;
            }
        }
    }
}
