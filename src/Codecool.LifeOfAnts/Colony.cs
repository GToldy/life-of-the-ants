using Codecool.LifeOfAnts.Ants;
using System.Collections.Generic;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        public Ant[,] AntColony { get; }
        public int Width { get; }
        private List<Ant> _ants { get; set; } = new List<Ant>();
        private Ant Queen { get; set; }

        public Colony(int width)
        {
            Width = width % 2 == 0 ? width + 1 : width;
            GenerateAnts(10, 5, 5);
            AntColony = PopulateColony();
        }

        private void GenerateAnts(int worker, int soldier, int drone)
        {
            Queen = new Queen(Width); _ants.Add(Queen);
            for (int i = 0; i < worker; i++) _ants.Add(new Worker(Queen.Position));
            //for (int i = 0; i < soldier; i++) _ants.Add(new Soldier(Queen.Position));
            //for (int i = 0; i < drone; i++) _ants.Add(new Drone(Queen.Position));
        }

        private Ant[,] PopulateColony()
        {
            Ant[,] colony = new Ant[Width, Width];
            PlaceAntsInColony(colony);
            return colony;
        }

        private void PlaceAntsInColony(Ant[,] colony)
        {
            foreach (Ant ant in _ants)
            {
                int x = ant.Position.X, y = ant.Position.Y;
                colony[x, y] = ant;
            }
        }

        public void Update()
        {
            foreach (Ant ant in _ants)
            {
                int x = ant.Position.X, y = ant.Position.Y;
                AntColony[x, y] = null;
                ant.Act();
            }
            PlaceAntsInColony(AntColony);
        }
    }
}
