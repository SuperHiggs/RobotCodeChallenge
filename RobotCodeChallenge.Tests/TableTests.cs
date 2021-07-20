using System;
using Xunit;
using FluentAssertions;
using RobotCodeChallenge.Models;

namespace RobotCodeChallenge.Tests
{
    public class TableTests
    {
        [Fact]
        public void InitialisedTableWithValues()
        {
            var sut = new Table(5, 5);

            sut.Width.Should().Be(5);
            sut.Height.Should().Be(5);
        }
    }
}
