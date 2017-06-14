using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<char> streamOfInstructiions = new List<char> { 'L', 'R', 'F', 'B', 'L' };



            MarsRover rover = new MarsRover();
            rover.RoverLanding();
            rover.MovementOfRover(streamOfInstructiions);
           string solution =  rover.DisplayUpdatedPositionOfRover();
            Console.WriteLine(solution);

        }

    }
}


