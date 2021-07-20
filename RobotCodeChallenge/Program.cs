using System;
using RobotCodeChallenge.Models;

namespace RobotCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot(new Table(5,5));
            while (true)
            {
                var command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                    continue;

                var result = robot.Command(command);
                if(!string.IsNullOrEmpty(result))
                    Console.WriteLine(result);
            }
        }
    }
}
