using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars
{
    public class ChangePosition : MarsRover
    {
        public  static void rover_Moving(ref char currentInstruction, ref char facingOfRover)
        {
            if (CheckMovementOfRover.checkIfRoverCanMove(ref currentInstruction, ref facingOfRover))
            {
                if ((facingOfRover == 'N' && currentInstruction == 'F') || (facingOfRover == 'S' && currentInstruction == 'B'))
                    currentPositionYOfRoverOnMars++;

                else if ((facingOfRover == 'E' && currentInstruction == 'F') || (facingOfRover == 'W' && currentInstruction == 'B'))
                    currentPositionXOfRoverOnMars++;

                else if ((facingOfRover == 'S' && currentInstruction == 'F') || (facingOfRover == 'N' && currentInstruction == 'B'))
                    currentPositionYOfRoverOnMars--;

                else if ((facingOfRover == 'W' && currentInstruction == 'F') || (facingOfRover == 'E' && currentInstruction == 'B'))
                    currentPositionXOfRoverOnMars--;
            }
            
            
        }
        

    }
}
