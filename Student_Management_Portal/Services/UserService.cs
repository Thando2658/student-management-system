
using Student_Management_Portal.Repository;

namespace Student_Management_Portal.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<Student> GetStudentById(int id)
    {
        return await _userRepository.GetStudentById(id);
    }

    public async Task<Parent> GetParentById(int id)
    {
        return await _userRepository.GetParentById(id);
    }

    public async Task<User> AddUser(User user)
    {
        return await _userRepository.AddUser(user);
    }

    public async Task<User> DeleteUserById(int id)
    {
        return await _userRepository.DeleteUserById(id);
    }

    public async Task<User> UpdateUser(User user, int id)
    {
        return await _userRepository.UpdateUser(user, id);
    }

    public bool IsUserCredentials(string password, string userName)
    {
        return _userRepository.IsUserCredentials(password, userName);
    }

    public bool IsUserNameTaken(string userName)
    {
        return _userRepository.IsUserNameTaken(userName);
    }

    public async Task<Parent> AddParent(Parent parent)
    {
        try
        {
            var addedParent = await _userRepository.AddParent(parent);
            return addedParent;
        }
        catch (ArgumentException ex)
        {
            // Handle the case where the user with the specified ID is not found
            // You can log the error or perform other error handling actions
            throw new ArgumentException("User not found.", ex);
        }
    }

    public async Task<Student> AddStudent(Student student)
    {
        try
        {
            var addedStudent = await _userRepository.AddStudent(student);
            return addedStudent;
        }
        catch (ArgumentException ex)
        {
            // Handle the case where the user with the specified ID is not found
            // You can log the error or perform other error handling actions
            throw new ArgumentException("User not found.", ex);
        }
    }
}
