namespace Codecool.LifeOfAnts.Ants
{
    internal class Soldier : Ant
    {
        public override AntType Type => AntType.Soldier;
        public override Position Position { get; set; }
        private Direction previousDirection { get; set; } = ChooseRandomDirection();
        private Position queenPosition;
        private int _width;

        public Soldier(Position position)
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
            switch (previousDirection)
            {
                case Direction.North:
                    if (CheckForValidMove(_width, Position))
                    {
                        Position.X -= 1;
                    }
                    else
                    {
                        Position.X += 1;
                    }
                    previousDirection = Direction.West;
                    break;
                case Direction.South:
                    if (CheckForValidMove(_width, Position))
                    {
                        Position.X += 1;
                    }
                    else
                    {
                        Position.X -= 1;
                    }
                    previousDirection = Direction.East;
                    break;
                case Direction.West:
                    if (CheckForValidMove(_width, Position))
                    {
                        Position.Y += 1;
                    }
                    else
                    {
                        Position.Y -= 1;
                    }
                    previousDirection = Direction.South;
                    break;
                case Direction.East:
                    if (CheckForValidMove(_width, Position))
                    {
                        Position.Y -= 1;
                    }
                    else
                    {
                        Position.Y += 1;
                    }
                    previousDirection = Direction.North;
                    break;
            }
        }
    }
}
