using _13AugAssignment.Models;

namespace _13AugAssignment.Repository
{
    public interface IAuthService
    {
        Customer Register(Customer customer);
        string? Login(string username, string password);
    }
}
