using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars
{
    public class ChangeFacing :MarsRover
    {
        public static void changeDirection(ref char newFacing,ref char facingOfRover)
        {
            if (newFacing == 'L')
            {
                if (facingOfRover == 'N')
                    facingOfRover = 'W';

                else if (facingOfRover == 'S')
                    facingOfRover = 'E';

                else if (facingOfRover == 'E')
                    facingOfRover = 'N';

                else if (facingOfRover == 'W')
                    facingOfRover = 'S';
            }
            else
            {
                if (facingOfRover == 'N')
                    facingOfRover = 'E';

                else if (facingOfRover == 'S')
                    facingOfRover = 'W';

                else if (facingOfRover == 'E')
                    facingOfRover = 'S';

                else if (facingOfRover == 'W')
                    facingOfRover = 'N';
            }
        }
    }
}
