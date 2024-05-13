namespace Student_Management_Portal.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<Student> GetStudentById(int id);
    Task<Parent> GetParentById(int id);
    Task<Parent> AddParent(Parent parent);
    Task<Student> AddStudent(Student student);
    Task<User> AddUser(User user);
    Task<User> DeleteUserById(int id);
    Task<User> UpdateUser(User user, int id);
    bool IsUserCredentials(string Password, string UserName);
    bool IsUserNameTaken(string UserName);
}
