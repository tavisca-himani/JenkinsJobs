using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars
{
    public class CheckMovementOfRover : MarsRover
    {
        public static bool checkIfRoverCanMove(ref char currentInstruction, ref char Roverface)
        {
            if (currentPositionXOfRoverOnMars == 0 && currentPositionYOfRoverOnMars == 0)
            {
                var check = ((Roverface == 'N' && currentInstruction == 'B') ||
                   (Roverface == 'S' && currentInstruction == 'F') ||
                    (Roverface == 'E' && currentInstruction == 'B') ||
                    (Roverface == 'W' && currentInstruction == 'F'));
                if (check)
                    return false;

            }

            else if (currentPositionXOfRoverOnMars == lengthOfMars && currentPositionYOfRoverOnMars == widthOfMars)
            {
                var check = (Roverface == 'N' && currentInstruction == 'F') ||
                    (Roverface == 'S' && currentInstruction == 'B') ||
                    (Roverface == 'E' && currentInstruction == 'F') ||
                    (Roverface == 'W' && currentInstruction == 'B');
                if (check)
                    return false;

            }

            else if (currentPositionXOfRoverOnMars == 0 && currentPositionYOfRoverOnMars == widthOfMars)
            {
                var check = (Roverface == 'N' && currentInstruction == 'F') ||
                    (Roverface == 'S' && currentInstruction == 'B') ||
                    (Roverface == 'E' && currentInstruction == 'B') ||
                    (Roverface == 'W' && currentInstruction == 'F');
                if (check)
                    return false;

            }
            else if (currentPositionXOfRoverOnMars == lengthOfMars && currentPositionYOfRoverOnMars == 0)
            {
                var check = (Roverface == 'N' && currentInstruction == 'B') ||
                    (Roverface == 'S' && currentInstruction == 'F') ||
                    (Roverface == 'E' && currentInstruction == 'F') ||
                    (Roverface == 'W' && currentInstruction == 'B');
                if (check)
                    return false;

            }
            else if ((currentPositionXOfRoverOnMars > 0 && currentPositionXOfRoverOnMars < lengthOfMars) && (currentPositionYOfRoverOnMars == 0))
            {
                var check = (Roverface == 'N' && currentInstruction == 'B') ||
                    (Roverface == 'S' && currentInstruction == 'F');

                if (check)
                    return false;

            }
            else if ((currentPositionXOfRoverOnMars == 0) && (currentPositionYOfRoverOnMars > 0 && currentPositionYOfRoverOnMars < widthOfMars))
            {
                var check = (Roverface == 'E' && currentInstruction == 'B') ||
                    (Roverface == 'W' && currentInstruction == 'F');
                if (check)
                    return false;

            }
            else if ((currentPositionXOfRoverOnMars > 0 && currentPositionXOfRoverOnMars < lengthOfMars) && (currentPositionYOfRoverOnMars == widthOfMars))
            {
                var check = (Roverface == 'N' && currentInstruction == 'F') ||
                    (Roverface == 'S' && currentInstruction == 'B');

                if (check)
                    return false;

            }
            else if ((currentPositionXOfRoverOnMars == lengthOfMars) && (currentPositionYOfRoverOnMars > 0 && currentPositionYOfRoverOnMars < widthOfMars))
            {
                var check = (Roverface == 'E' && currentInstruction == 'F') ||
                    (Roverface == 'W' && currentInstruction == 'B');
                if (check)
                    return false;

            }
            return true;
        }
    }
}
