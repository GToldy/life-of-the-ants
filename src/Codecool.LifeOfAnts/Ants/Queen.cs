namespace Codecool.LifeOfAnts.Ants
{
    public class Queen : Ant
    {
        public override AntType Type => AntType.Queen;
        public override Position Position { get; set; }
        private int _width;

        public Queen(int width)
        {
            _width = width;
            InicializePosition();
        }

        public override void InicializePosition()
        {
            Position = new Position(_width / 2, _width / 2);
        }

        public override void Act()
        {
            Position.X += 0;
            Position.Y += 0;
        }
    }
}
