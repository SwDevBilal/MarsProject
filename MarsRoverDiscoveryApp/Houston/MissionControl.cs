using MarsRoverDiscoveryApp.AbstractClasses;
using MarsRoverDiscoveryApp.DrivedClasses;
using MarsRoverDiscoveryApp.SurfaceClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverDiscoveryApp.Houston
{
    public class MissionControl
    {
        private Surface surface;
        private string[] inputs;
        public MissionControl(string[] missionInputs)
        {
            this.inputs = missionInputs;
        }

        /// <summary>
        /// This method use to start Mars mission
        /// </summary>
        public void StartMarsMission()
        {
            if (inputs == null || inputs.Length  == 0)
            {
                throw new NullReferenceException("Houston we have a problem! mission inputs are empty");
            }

            this.surface = new Surface(inputs[0]);
            int vehicleIndex = 0;
            for (int i = 1; i < inputs.Length; i++)
            {
                string initialPosition = string.Empty;
                string directions = string.Empty;
                Vehicle rover = new Rover(inputs[i], vehicleIndex);
                surface.LandVehicleToSurface(rover);
                rover.Move(inputs[i+1], surface);
                vehicleIndex++;
                i++;
            }

       }

        /// <summary>
        /// This method shows positions of all vehicles position on surface
        /// </summary>
        public void showAllVehiclesOnMarsSurface()
        {
            surface.monitorAllVehiclePositions();
        }

        /// <summary>
        /// This method returns all vehicles position on Mars surface with by index parameter
        /// </summary>
        /// <returns>string Array</returns>
        public string[] getPositionsAllVehiclePositions()
        {
            return surface.getAllLandedVehiclesPositions();
        }
    }
}
