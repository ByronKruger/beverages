namespace Coffeeg.Exceptions
{
    public class CoffeegMissingConfigurationException : Exception
    {
        public string KeyName { get; }

        // 1. Parameterless constructor (good practice)
        public CoffeegMissingConfigurationException()
            : base("A required configuration value was missing.")
        {
        }

        // 2. Most commonly used – just the key
        public CoffeegMissingConfigurationException(string keyName)
            : base($"The configuration key '{keyName}' is required but was not found.")
        {
            KeyName = keyName;
        }

        // 3. Full constructor – allows chaining inner exceptions
        public CoffeegMissingConfigurationException(string keyName, Exception? innerException)
            : base($"The configuration key '{keyName}' is required but was not found.", innerException)
        {
            KeyName = keyName;
        }
    }
}
