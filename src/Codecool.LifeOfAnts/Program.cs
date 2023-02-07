using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            Display display = new Display();
            Colony colony = new Colony(10);
            display.Colony(colony);
            display.Message("Press enter to continue...");
            Console.ReadKey();

            bool isSimulationRunning = true;

            while (isSimulationRunning)
            {
                colony.Update();
                display.Colony(colony);
                display.Message("Press enter to continue...");
                Console.ReadKey();
            }
        }
    }
}
