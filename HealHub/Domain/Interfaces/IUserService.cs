using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;

namespace HealHub.Domain.Interfaces
{
    public interface IUserService
    {
        Result<List<User>> getAllUsers();

        Result<User> createUser(User user);

        Result<User> updateUser(int id, User user);

        Result<bool> deleteUser(int id);
    }
}
