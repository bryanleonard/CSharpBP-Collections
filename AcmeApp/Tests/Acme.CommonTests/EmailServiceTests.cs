using Xunit;

namespace Acme.Common.Tests
{
    public class EmailServiceTests
    {
        [Fact]
        public void SendMessage_Success()
        {
            // Arrange
            var email = new EmailService();
            var expected = "Message sent: Test Message";

            // Act
            var actual = email.SendMessage("Test Message",
                "This is a test message", "abc@abc.com");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}