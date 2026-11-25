using NumGameSOLID.Users;

namespace NumGameSOLID.Users;

public interface IUserStorage
{
    List<User> LoadUsers();

    void SaveUsers(List<User> users);
}