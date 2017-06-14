using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SolutionMissionMars;
using MissionMars;

namespace SolutionMissionMars
{
   public class Fixture
    {
        [Fact]
       public void test_rover()
        {
            List<char> streamOfInstructiions = new List<char> { 'L','F','F','F','F','R','F','F','F','F','F','R','R','F','F','F','F',
                'F' };
             MarsRover rover = new MarsRover();
            rover.RoverLanding();
            rover.MovementOfRover(streamOfInstructiions);
            var finalResult = rover.DisplayUpdatedPositionOfRover();
            Assert.Matches("4,5,N", finalResult);
        }
        [Fact]
        public void test_rover1()
        {
            List<char> streamOfInstructiions = new List<char> { 'L', 'R', 'F', 'B','L' };
                
            MarsRover rover = new MarsRover();
            rover.RoverLanding();
            rover.MovementOfRover(streamOfInstructiions);
            var finalResult = rover.DisplayUpdatedPositionOfRover();
            Assert.Matches("0,1,E", finalResult);
        }
    }
}
