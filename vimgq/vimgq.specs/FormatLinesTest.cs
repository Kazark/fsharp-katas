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

        [Fact]
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
        public void DoNotWrapOneWordLineWithExcessiveIndent()
        {
            const string Unformatted = "                                                                                toolong";
            var formatted = FormatLines.OneLine(80, Unformatted);
            Assert.Equal(Unformatted, formatted);
        }

        [Fact]
        public void DoesNotBreakWordWhichIsLongerThanTextwidth()
        {
            const string Unformatted = "floccinaucinihilipilification";
            var formatted = FormatLines.OneLine(20, Unformatted);
            Assert.Equal(Unformatted, formatted);
        }

        [Fact]
        public void WithLengthMoreThanTwiceAsGreatAsTextWidthWrapsOntoThreeLines()
        {
            const string Unformatted = "Oh, what a rogue and peasant slave am I!";
            var formatted = FormatLines.OneLine(17, Unformatted);
            Assert.Equal("Oh, what a rogue\nand peasant slave\nam I!", formatted);
        }

        [Fact]
        public void WithComments()
        {
            const string Unformatted = "    // Here be dragons";
            var formatted = FormatLines.OneLine(20, Unformatted);
            Assert.Equal("    // Here be\n    // dragons", formatted);
        }

        [Fact]
        public void WithCommentsNoSpace()
        {
            const string Unformatted = "    //Here be dragons";
            var formatted = FormatLines.OneLine(20, Unformatted);
            Assert.Equal("    //Here be\n    //dragons", formatted);
        }

        [Fact]
        public void EdgeCase_CommentAlgorithmSafety()
        {
            const string Unformatted = "                    /";
            var formatted = FormatLines.OneLine(20, Unformatted);
            Assert.Equal(Unformatted, formatted);
        }
    }
}
