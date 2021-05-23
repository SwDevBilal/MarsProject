using MarsRoverDiscoveryApp.SurfaceClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverDiscoveryApp.AbstractClasses
{

    public abstract class Vehicle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Head { get; set; }

        public int VehicleIndex { get; set; }
        public Vehicle(string position,int index)
        {
           
            string[] currentPositionChars = position.Split(' ');
            int posx;
            int posy;

            if (Int32.TryParse(currentPositionChars[0].ToString(), out posx) && Int32.TryParse(currentPositionChars[1].ToString(), out posy) && currentPositionChars.Length == 3)
            {
                this.X = posx;
                this.Y = posy;
                this.Head = currentPositionChars[2];
                this.VehicleIndex = index;

                if (this.X < 0 || this.Y < 0)
                {
                    throw new InvalidCastException("Unexpected vehicle position defination!");
                }
            }
            else
            {
                throw new InvalidCastException("Unexpected vehicle position defination!");
            }
        }

        public abstract void Move(string directions, Surface surface);

        public abstract string Rotate(string currentVehicleHead, char direction);
    }
}
