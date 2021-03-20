using System;
using FluentAssertions;
using Xunit;

namespace Geometry.Tests
{
    public class PointTests
    {
        [Fact]
        public void Can_create_point()
        {
            var point = new Point(1, 2);
            var point2 = new Point(3.5, 2.4);

            point.X.Should().Be(1);
            point.Y.Should().Be(2);

            point2.X.Should().Be(3.5);
            point2.Y.Should().Be(2.4);
        }

        [Fact]
        public void Can_create_point_without_parameters()
        {
            var point = new Point();

            point.X.Should().Be(1);
            point.Y.Should().Be(1);
        }

        [Fact]
        public void Distance_should_be_correct()
        {
            var point = new Point(3, 4);

            var distance = point.Distance();

            distance.Should().Be(5);
        }

        [Fact]
        public void Distance_between_points_should_be_correct()
        {
            var point1 = new Point(-1, 2);
            var point2 = new Point(2, 6);

            var distance = point1.Distance(point2);

            distance.Should().Be(5);
        }

        [Fact]
        public void Static_distance_between_points_should_be_correct()
        {
            var point1 = new Point(-1, 2);
            var point2 = new Point(2, 6);

            var distance = Point.Distance(point1, point2);

            distance.Should().Be(5);
        }

        [Fact]
        public void ToString_should_return_valid_representation()
        {
            var point = new Point(-2, 7);

            point.ToString().Should().Be("(-2,7)");
        }

        [Fact]
        public void ReflectionType_should_be_available()
        {
            var x = Point.ReflectionType.X;
            var y = Point.ReflectionType.Y;
            var origin = Point.ReflectionType.Origin;
        }

        [Fact]
        public void Reflect_should_reflect_correctly()
        {
            var x = new Point(3, 5);

            var reflection = x.Reflect(Point.ReflectionType.X);

            reflection.X.Should().Be(3);
            reflection.Y.Should().Be(-5);
        }
    }
}
