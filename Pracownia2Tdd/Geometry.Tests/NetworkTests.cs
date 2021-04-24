using System;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
namespace Geometry.Tests
{
    public class NetworkTests
    {
        [Fact]
        public void Can_create_valid_network()
        {
            var network = new Network("192.168.0.0", 24);
            network.Bits.Should()
                .BeEquivalentTo(1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        [Theory]
        [MemberData(nameof(InvalidIpAddress))]
        public void Cannot_create_network_with_invalid_address(string address)
        {
            Action action = () => new Network(address, -1);
            
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Cannot_create_network_with_invalid_prefix_length()
        {
            Action action = () => new Network("10.0.0.0",-1);

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Cannot_create_network_when_address_is_not_a_network_address()
        {
            Action action = () => new Network("10.0.0.1", 24);

            action.Should().Throw<Exception>();
        }

        public static IEnumerable<object[]> InvalidIpAddress => new List<object[]>
        {
            new object[] {""},
            new object[] {"rubbish"},
            new object[] {"1.2.3.4.5"},
            new object[] {"300.10.0.2"},
            new object[] {"192,168,1,2"}
        };
    }
}
