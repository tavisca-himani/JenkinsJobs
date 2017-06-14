using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars
{
    public class MarsRover : Mars
    {
        public static double initialPositionXOfRoverOnMars;
        public static double initialPositionYOfRoverOnMars;
        public static char currentInstruction;
        public static char facingOfRover;
        public static double currentPositionXOfRoverOnMars;
        public static double currentPositionYOfRoverOnMars;

        public void RoverLanding()
        {
            initialPositionXOfRoverOnMars = 0;
            initialPositionYOfRoverOnMars = 0;
            facingOfRover = 'S';
            currentPositionXOfRoverOnMars = initialPositionXOfRoverOnMars;
            currentPositionYOfRoverOnMars = initialPositionYOfRoverOnMars;
        }

        public void MovementOfRover(List<char> StreamOfInstructions)
        {
            for (int itr = 0; itr < StreamOfInstructions.Count; itr++)
            {
                currentInstruction = StreamOfInstructions[itr];

                if (currentInstruction == 'L' || currentInstruction == 'R')
                {
                    ChangeFacing.changeDirection(ref currentInstruction, ref facingOfRover);

                }
                else if (currentInstruction == 'F' || currentInstruction == 'B')
                {
                    ChangePosition.rover_Moving(ref currentInstruction, ref facingOfRover);
                }



            }
        }
        public string DisplayUpdatedPositionOfRover()
        {
            
            string solution = currentPositionXOfRoverOnMars + "," + currentPositionYOfRoverOnMars + "," + facingOfRover;
            return solution;
        }



    }

}
