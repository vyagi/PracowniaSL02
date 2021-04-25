using System;
using FluentAssertions;
using MementoPattern;
using Xunit;

namespace MementoPatternTests
{
    public class DocumentTests
    {
        [Fact]
        public void Can_set_and_read_content()
        {
            var d = new Document();
            d.SetContent("Marcin");

            d.GetContent().Should().Be("Marcin");
        }

        [Fact]
        public void Can_save_and_retrieve_state()
        {
            var history = new History();

            var document = new Document();
            document.SetContent("Marcin");

            history.Save(document.CreateState());

            document.SetContent("Jagieła");

            document.Restore(history.Retrieve());

            document.GetContent().Should().Be("Marcin");
        }
    }
}
