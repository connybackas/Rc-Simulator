using System;
using RcSimulator.Implementation;
using RcSimulator.Implementation.RcCar;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        { 
            Simulator simulator = new Simulator(new MonsterTruck());
            simulator.promptSimulatorRoomSize();
            simulator.promptStartPosAndCarHeading();
            simulator.promptCarMovementCommandSeries();
            simulator.startSimulation();
        }
    }
}