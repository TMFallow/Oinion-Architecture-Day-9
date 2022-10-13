using OA.Data;

namespace OA.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUser();
        User GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }
}