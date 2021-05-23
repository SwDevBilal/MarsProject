using MarsRoverDiscoveryApp.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverDiscoveryApp.SurfaceClasses
{
    public class Surface
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected List<Vehicle> LandedVehicles;
       

        public Surface(string surfaceArea)
        {
            string[] surfaceAreaChars = surfaceArea.Split(' ');

            int surfaceAreax;
            int surfaceAreay;

            if (Int32.TryParse(surfaceAreaChars[0].ToString(), out surfaceAreax) && Int32.TryParse(surfaceAreaChars[1].ToString(), out surfaceAreay) && surfaceAreaChars.Length == 2)
            {
                this.X = surfaceAreax;
                this.Y = surfaceAreay;

                this.LandedVehicles = new List<Vehicle>();
            }
            else
            {
                throw new InvalidCastException("Houston we have a problem! Unexpected surface area defination");
            }
        }

        /// <summary>
        /// This method to user land vehicles on mars surface with initial parameters
        /// </summary>
        /// <param name="vehicle"></param>
        public void LandVehicleToSurface(Vehicle vehicle)
        {
            this.LandedVehicles.Add(vehicle);
        }

        /// <summary>
        /// This method made update vehicle position on the Mars surface
        /// </summary>
        /// <param name="vehicle"></param>
        public void updateVehiclePosition(Vehicle vehicle)
        {

            LandedVehicles[vehicle.VehicleIndex].X = vehicle.X;
            LandedVehicles[vehicle.VehicleIndex].Y = vehicle.Y;
            LandedVehicles[vehicle.VehicleIndex].Head = vehicle.Head;
        }

        /// <summary>
        /// This method returns single vehicle position on Mars surface with by index parameter
        /// </summary>
        /// <param name="index"></param>
        /// <returns>string</returns>
        public string getVehiclePositionByIndex(int index)
        {
            return string.Join(' ', new object[] { LandedVehicles[index].X, LandedVehicles[index].Y, LandedVehicles[index].Head });
        }

        /// <summary>
        /// This method returns all vehicles position on Mars surface with by index parameter
        /// </summary>
        /// <returns>string Array</returns>
        public string[] getAllLandedVehiclesPositions()
        {
            if (LandedVehicles.Count > 0)
            {
                string[] vPositions = new string[LandedVehicles.Count];
                int indx = 0;
                LandedVehicles.ForEach(vehicle =>
                {
                    vPositions[indx] = string.Join(' ', new object[] { vehicle.X, vehicle.Y, vehicle.Head });

                    indx++;
                });

                return vPositions;
            }

            throw new NullReferenceException("There are no any landed vehicle on the Mars surface Houston!");

        }

        /// <summary>
        /// This method shows positions of all vehicles position on surface
        /// </summary>
        public void monitorAllVehiclePositions()
        {
            if (LandedVehicles.Count > 0)
            {
                LandedVehicles.ForEach(vehicle =>
                {
                    Console.WriteLine(string.Join(' ', new object[] { vehicle.X, vehicle.Y, vehicle.Head }));
                });

                Console.ReadKey();

            }
            else {
                throw new NullReferenceException("There are no any landed vehicle on the Mars surface Houston!");
            }

            
        }
    }
}
