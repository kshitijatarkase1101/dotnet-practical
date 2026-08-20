using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
    public interface IUserService
    {
        void Register(User user);
        string Login(string username, string password);
    }
}
