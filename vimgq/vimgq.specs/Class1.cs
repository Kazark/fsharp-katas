using Xunit;

namespace vimgq.specs
{
    public class FormatOneLineTest
    {
        [Fact]
        public void FormatOneEmptyLineDoesNothing()
        {
            var formatted = FormatLines.oneLine(string.Empty);
            Assert.Equal(string.Empty, formatted);
        }
    }
}
