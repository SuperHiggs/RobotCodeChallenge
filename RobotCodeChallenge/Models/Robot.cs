using System;
using System.Linq;

namespace RobotCodeChallenge.Models
{
    public class Robot
    {
        private readonly Table Table;
        private string CurrentFacing { get; set; }
        private int CurrentX { get; set; }
        private int CurrentY { get; set; }

        private readonly string[] AllowedDirections = new string[] { "NORTH", "EAST", "SOUTH", "WEST" };
        private readonly string[] AllowedCommands = new string[] { "MOVE", "LEFT", "RIGHT", "REPORT", "PLACE" };

        public Robot(Table table)
        {
            CurrentX = -1;
            CurrentY = -1;
            Table = table;
        }

        public bool HasPlaced()
        {
            return CurrentX != -1 && CurrentY != -1;
        }

        private void Place(string value)
        {
            value = value.Replace("PLACE", "").Trim();
            var splitvalue = value.Split(",");

            if (!int.TryParse(splitvalue[0], out var x))
                return;

            if (!Table.IsWithinWidthBound(x))
                return;

            if (!int.TryParse(splitvalue[1], out var y))
                return;

            if (!Table.IsWithinHeightBound(y))
                return;

            var facing = splitvalue[2];
            if (!ValidFacing(facing))
                return;

            CurrentX = x;
            CurrentY = y;
            CurrentFacing = facing;

        }

        public string Command(string command)
        {
            command = command.ToUpper();
            if (!ValidCommand(command))
                return "";

            if (command.StartsWith("PLACE"))
            {
                Place(command);
                return "";
            }

            if (!HasPlaced())
                return "";

            switch (command)
            {
                case "MOVE":
                    Move();
                    return "";
                case "REPORT":
                    return Report();
                default:
                    Rotate(command);
                    return ""; 
            }
        }

        private void Move()
        {

            var newX = CurrentX;
            var newY = CurrentY;

            switch (CurrentFacing)
            {
                case "NORTH":
                    newY++;
                    break;
                case "EAST":
                    newX++;
                    break;
                case "SOUTH":
                    newY--;
                    break;
                case "WEST":
                    newX--;
                    break;
            }

            if (!Table.IsWithinWidthBound(newX))
                return;

            if (!Table.IsWithinHeightBound(newY))
                return;

            CurrentX = newX;
            CurrentY = newY;

        }

        public string Report()
        {
            return $"Output: {CurrentX},{CurrentY},{CurrentFacing}";
        }

        public void Rotate(string value)
        {
            switch (CurrentFacing)
            {
                case "NORTH":
                    if (value.Equals("RIGHT"))
                        CurrentFacing = "EAST";
                    else if (value.Equals("LEFT"))
                        CurrentFacing = "WEST";
                    break;
                case "EAST":
                    if (value.Equals("RIGHT"))
                        CurrentFacing = "SOUTH";
                    else if (value.Equals("LEFT"))
                        CurrentFacing = "NORTH";
                    break;
                case "SOUTH":
                    if (value.Equals("RIGHT"))
                        CurrentFacing = "WEST";
                    else if (value.Equals("LEFT"))
                        CurrentFacing = "EAST";
                    break;
                case "WEST":
                    if (value.Equals("RIGHT"))
                        CurrentFacing = "NORTH";
                    else if (value.Equals("LEFT"))
                        CurrentFacing = "SOUTH";
                    break;
            }
        }

        private bool ValidCommand(string value)
        {
            return AllowedCommands.Any(s => value.StartsWith(s));
        }

        private bool ValidFacing(string value)
        {
            return AllowedDirections.Contains(value);
        }

    }
}
