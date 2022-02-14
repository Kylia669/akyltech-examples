namespace ExceptionUnitTesting
{
    public class InputModel
    {
        public string Name { get; set; }
    }

    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception ex) : base(message, ex) { }

    }

    public class Validator
    {
        public void Validate(InputModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ValidationException("invalid name");
            }
        }

        public Task ValidateAsync(InputModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ValidationException("invalid name");
            }

            return Task.CompletedTask;
        }
    }
}