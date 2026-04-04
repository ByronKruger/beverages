namespace Coffeeg.Exceptions
{
    public class CoffeegInvalidaConfigurationException : Exception
    {
        public CoffeegInvalidaConfigurationException()
            : base("A required configuration value is invalid.")
        {
        }

        public CoffeegInvalidaConfigurationException(string details)
            : base($"A required configuration value is invalid: {details}.")
        {
        }

        public CoffeegInvalidaConfigurationException(string details, Exception? innerException)
            : base($"The configuration value is not valid: {details}", innerException)
        {
        }
    }
}
