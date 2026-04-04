namespace Coffeeg.Dtos.User
{
    public record RegisterUser(
        string Username, 
        string Email, 
        string Password,
        string FirstName,
        string LastName);
}
