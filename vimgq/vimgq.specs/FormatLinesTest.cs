using Xunit;

namespace vimgq.specs
{
    public class FormatOneLineTest
    {
        [Fact]
        public void ForEmptyLineDoesNothing()
        {
            var formatted = FormatLines.OneLine(80, string.Empty);
            Assert.Equal(string.Empty, formatted);
        }

        [Fact]
        public void WithLengthEqualToTextWidthDoesNothing()
        {
            const string Unformatted = "Oh, what a rogue and peasant slave am I!";
            var formatted = FormatLines.OneLine(40, Unformatted);
            Assert.Equal(Unformatted, formatted);
        }

        [Fact]
        public void WithLengthOneGreaterThanTextWidthWraps()
        {
            const string Unformatted = "Oh what a rogue and peasant slave am I";
            var formatted = FormatLines.OneLine(37, Unformatted);
            Assert.Equal("Oh what a rogue and peasant slave am\nI", formatted);
        }

        [Fact]
        public void WrapTwoWords()
        {
            const string Unformatted = "Oh what a rogue and peasant slave am I";
            var formatted = FormatLines.OneLine(34, Unformatted);
            Assert.Equal("Oh what a rogue and peasant slave\nam I", formatted);
        }

        [Fact(Skip="This test jumped two steps ahead; I need an intermediate one")]
        public void WrapDoesNotSplitWords()
        {
            const string Unformatted = "Oh what a rogue and peasant slave am I";
            var formatted = FormatLines.OneLine(35, Unformatted);
            Assert.Equal("Oh what a rogue and peasant slave\nam I", formatted);
        }

        [Fact]
        public void WrapWithIndentBySpaces()
        {
            const string Unformatted = "    foo bar";
            var formatted = FormatLines.OneLine(8, Unformatted);
            Assert.Equal("    foo\n    bar", formatted);
        }

        [Fact]
        public void WithLengthMoreThanTwiceAsGreatAsTextWidthWrapsOntoThreeLines()
        {
            const string Unformatted = "Oh, what a rogue and peasant slave am I!";
            var formatted = FormatLines.OneLine(17, Unformatted);
            Assert.Equal("Oh, what a rogue\nand peasant slave\nam I!", formatted);
        }
    }
}
