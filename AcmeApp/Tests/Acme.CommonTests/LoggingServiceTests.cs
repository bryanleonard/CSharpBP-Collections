using Xunit;

namespace Acme.Common.Tests
{

    public class LoggingServiceTests
    {
        [Fact]
        public void LogAction_Success()
        {
            // Arrange
            var expected = "Action: Test Action";

            // Act
            var actual = LoggingService.LogAction("Test Action");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}