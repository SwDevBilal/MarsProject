using MarsRoverDiscoveryApp.AbstractClasses;
using MarsRoverDiscoveryApp.SurfaceClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverDiscoveryApp.DrivedClasses
{
    public class Rover : Vehicle
    {
        public Rover(string position, int index)
            :base(position, index)
        {
            
        }

        /// <summary>
        /// To Move Rover With directions
        /// </summary>
        /// <param name="directions"></param>
        /// <param name="surface"></param>
        public override void Move(string directions, Surface surface)
        {
            char[] directionList = directions.ToCharArray();

            for (int i = 0; i < directionList.Length; i++)
            {
                //Direction 'M' olup olmadığını kontrol et eğer M ise sadece hareket ettir....
                string newVehicleHead = Rotate(Head, directionList[i]);

                if (directionList[i] == 'M')
                {
                    switch (newVehicleHead)
                    {
                        case "W":
                            X = X - 1;
                            break;
                        case "E":
                            X = X + 1;
                            break;
                        case "S":
                            Y = Y - 1;
                            break;
                        case "N":
                            Y = Y + 1;
                            break;
                        default:
                            X = int.MinValue;
                            Y = int.MinValue;
                            break;
                    }

                    if (X == int.MinValue || Y == int.MinValue)
                    {
                        throw new InvalidOperationException("Houston we have a problem! Unexpected vehicle head");
                    }
                }

                if (X < 0 || X > surface.X
                    || Y < 0 || Y > surface.Y)
                {
                    throw new InvalidOperationException("Houston we have a problem! Vehicle moving outside of boundries");
                }

                this.Head = newVehicleHead;

                surface.updateVehiclePosition(this);
            }
        }

        /// <summary>
        /// To Rotate Rover with direction and current vehicle head
        /// </summary>
        /// <param name="currentVehicleHead"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public override string Rotate(string currentVehicleHead, char direction)
        {
            ValidateDirections(direction);
            
            string newHead = string.Empty;

            if (direction == 'M')
                return currentVehicleHead;
            
            switch (currentVehicleHead)
            {
                case "N":
                    newHead = direction == 'L' ? "W" : "E";
                    break;
                case "W":
                    newHead = direction == 'L' ? "S" : "N";
                    break;
                case "S":
                    newHead = direction == 'L' ? "E" : "W";
                    break;
                case "E":
                    newHead = direction == 'L' ? "N" : "S";
                    break;
                default:
                    newHead = string.Empty;
                    break;
            }

            if (string.IsNullOrEmpty(newHead))
                throw new InvalidOperationException("Houston we have a problem! Unexpected vehicle head");

            return newHead;
        }

        /// <summary>
        /// Validate direction parameters and surface object either valid or not
        /// </summary>
        /// <param name="directions"></param>
        /// <param name="surface"></param>
        private void ValidateMissionPatameters(string directions, Surface surface)
        {
            if(string.IsNullOrEmpty(directions))
            {
                throw new ArgumentNullException("Houston we have a problem! Move directions are empty");
            }

            if (surface == null)
            {
                throw new ArgumentNullException("Houston we have a problem! Surface defination is null, Mars surface can't recognize");
            }
        }

        /// <summary>
        /// Validate direction parameters
        /// </summary>
        /// <param name="direction"></param>
        private void ValidateDirections(char direction)
        {
            string validDirections = "LRM";
            if (!validDirections.Contains(direction))
            {
                throw new InvalidOperationException("Houston we have a problem! Unexpected direction");
            }
        }
    }
}
