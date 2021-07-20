using Xunit;
using FluentAssertions;
using RobotCodeChallenge.Models;

namespace RobotCodeChallenge.Tests
{
    
    public class RobotTests
    {
        [Theory]
        [InlineData("PLACE 0,0,NORTH")]
        [InlineData("PLACE 1,1,SOUTH")]
        [InlineData("PLACE 5,5,WEST")]
        [InlineData("PLACE 3,4,EAST")]
        [InlineData("PLACE 0,0,WEST")]
        [InlineData("place 0,0,east")]
        public void GivenValidPlaceCommandRobotIsPlaced(string command)
        {
            var sut = new Robot(new Table(5,5));
            sut.Command(command);

            var actual = sut.HasPlaced();
            actual.Should().BeTrue();
        }

        [Fact]
        public void GivenValidCommandsRobotMoves()
        {
            var sut = new Robot(new Table(5, 5));
            sut.Command("PLACE 1,2,EAST");
            sut.Command("MOVE");
            sut.Command("MOVE");
            sut.Command("LEFT");
            sut.Command("MOVE");

            var actual = sut.Command("REPORT");
            actual.Should().Be("Output: 3,3,NORTH");

        }

        [Fact]
        public void GivenValidCommandsRobotStaysOnTable()
        {
            var sut = new Robot(new Table(1, 1));
            sut.Command("PLACE 0,0,WEST");
            sut.Command("MOVE");

            var actual = sut.Command("REPORT");
            actual.Should().Be("Output: 0,0,WEST");

        }
    }
}
