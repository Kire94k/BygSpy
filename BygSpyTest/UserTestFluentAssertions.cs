using Xunit;
using Moq;
using BygSpy;
using FakeItEasy;
using FluentAssertions;

namespace BygSpyTest
{
//TODO move the top part of the code -> BygSpy project
    public class UserTestFluentAssertions
    {
        public interface IAuthService
        {
            bool Authenticate(string username, string password);
        }

        public class LoginController
        {
            private readonly IAuthService _authService;

            public LoginController(IAuthService authService)
            {
                _authService = authService;
            }

            public bool Login(string username, string password)
            {
                //throw new NotImplementedException();
                return _authService.Authenticate(username, password);
            }
        }

        [Fact]
        public void Login_ShouldReturnTrue_WhenAuthenticationSucceeds()
        {
            // Arrange
            var authService = A.Fake<IAuthService>();
            A.CallTo(() => authService.Authenticate("validUser", "validPassword")).Returns(true); // Configure the fake to return true for a specific username and password
            var loginController = new LoginController(authService);

            // Act
            var result = loginController.Login("validUser", "validPassword");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Login_ShouldReturnFalse_WhenAuthenticationFails()
        {
            // Arrange
            var authService = A.Fake<IAuthService>();
            A.CallTo(() => authService.Authenticate("invalidUser", "invalidPassword")).Returns(false); // Configure the fake to return false for a specific username and password
            var loginController = new LoginController(authService);

            // Act
            var result = loginController.Login("invalidUser", "invalidPassword");

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("validUser", "validPassword", true)]
        [InlineData("invalidUser", "invalidPassword", false)]
        public void Login_ShouldReturnExpectedResult(string username, string password, bool expectedResult)
        {
            // Arrange
            var authService = A.Fake<IAuthService>();
            A.CallTo(() => authService.Authenticate(A<string>._, A<string>._)).ReturnsLazily((string u, string p) => u == "validUser" && p == "validPassword");
            var loginController = new LoginController(authService);

            // Act
            var result = loginController.Login(username, password);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}