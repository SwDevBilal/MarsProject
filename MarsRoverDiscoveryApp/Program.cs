using MarsRoverDiscoveryApp.AbstractClasses;
using MarsRoverDiscoveryApp.DrivedClasses;
using MarsRoverDiscoveryApp.Houston;
using MarsRoverDiscoveryApp.SurfaceClasses;
using System;

namespace MarsRoverDiscoveryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputs = new string[] { "5 5", "1 2 N", "LMLMLMLMM","3 3 E","MMRMMRMRRM","1 3 S","MLMRMMLMRRMM" };

                MissionControl missionControl = new MissionControl(inputs);
                missionControl.StartMarsMission();
                missionControl.showAllVehiclesOnMarsSurface();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.Read();
            }

        }
    }
}
