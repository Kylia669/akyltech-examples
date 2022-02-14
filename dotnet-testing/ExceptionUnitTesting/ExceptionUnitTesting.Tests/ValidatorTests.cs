using FluentAssertions;
using NUnit.Framework;

namespace ExceptionUnitTesting.Tests
{
    public class ValidatorTests
    {
        private readonly Validator _validator = new Validator();

        [Test]
        public void Validate_ShouldNotThrow_WhenModeIsValid()
        {
            // Arrange
            var model = new InputModel
            {
                Name = "name"
            };

            // Act 
            Action validate = () => _validator.Validate(model);

            // Assert
            validate.Should().NotThrow();
        }

        [TestCase("")]
        [TestCase(null)]
        public void Validate_ShouldThrow_WhenInvalidName(string name)
        {
            // Arrange
            var model = new InputModel
            {
                Name = name
            };

            // Act 
            Action validate = () => _validator.Validate(model);

            // Assert
            validate.Should().Throw<ValidationException>("invalid name");
        }

        [Test]
        public void ValidateAsync_ShouldNotThrow_WhenModeIsValid()
        {
            // Arrange
            var model = new InputModel
            {
                Name = "name"
            };

            // Act 
            Func<Task> validate = () => _validator.ValidateAsync(model);

            // Assert
            validate.Should().NotThrowAsync();
        }

        [TestCase("")]
        [TestCase(null)]
        public void ValidateAsync_ShouldThrow_WhenInvalidName(string name)
        {
            // Arrange
            var model = new InputModel
            {
                Name = name
            };

            // Act 
            Func<Task> validate = () => _validator.ValidateAsync(model);

            // Assert
            validate.Should().ThrowAsync<ValidationException>("invalid name");
        }
    }
}