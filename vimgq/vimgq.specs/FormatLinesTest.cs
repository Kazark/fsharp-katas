using Xunit;

namespace vimgq.specs
{
    public class FormatOneLineTest
    {
        [Fact]
        public void FormatOneEmptyLineDoesNothing()
        {
            var formatted = FormatLines.oneLine(80, string.Empty);
            Assert.Equal(string.Empty, formatted);
        }

        [Fact]
        public void FormatOneLineWithLengthEqualToTextWidthDoesNothing()
        {
            const string Unformatted = "Oh, what a rogue and peasent slave am I!";
            var formatted = FormatLines.oneLine(40, Unformatted);
            Assert.Equal(Unformatted, formatted);
        }

        [Fact]
        public void FormatOneLineWithLengthOneGreaterThanTextWidthWraps()
        {
            const string Unformatted = "Oh what a rogue and peasent slave am I";
            var formatted = FormatLines.oneLine(37, Unformatted);
            Assert.Equal("Oh what a rogue and peasent slave am\nI", formatted);
        }
    }
}
