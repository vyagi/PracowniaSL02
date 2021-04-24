using System;
using FluentAssertions;
using SimpleFactoryPattern;
using Xunit;

namespace SimpleFactoryPatternTests
{
    public class AnimalFactoryTests
    {
        [Fact]
        public void Can_create_all_animals()
        {
            var af = new AnimalFactory();
            af.Create<Dog>().Should().BeOfType<Dog>();
            af.Create<Cat>().Should().BeOfType<Cat>();
            af.Create<Fish>().Should().BeOfType<Fish>();
            af.Create<Monkey>().Should().BeOfType<Monkey>();
            af.Create<Horse>().Should().BeOfType<Horse>();

            // af.Create("Dog").Should().BeOfType<Dog>();
            // af.Create("Cat").Should().BeOfType<Cat>();
            // af.Create("Fish").Should().BeOfType<Fish>();
            // af.Create("Monkey").Should().BeOfType<Monkey>();
            // af.Create("Horse").Should().BeOfType<Horse>();
        }
    }
}
