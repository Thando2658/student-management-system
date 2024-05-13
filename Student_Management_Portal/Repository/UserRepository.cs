
using Microsoft.EntityFrameworkCore;

namespace Student_Management_Portal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentDbContext _context;

        public UserRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<Student> AddStudent(Student student)
        {
            var user = await GetUserById(student.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found.", nameof(student.UserId));
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Parent> AddParent(Parent parent)
        {
            var user = await GetUserById(parent.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found.", nameof(parent.UserId));
            }

            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();
            return parent;
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Parent> GetParentById(int id)
        {
            return await _context.Parents.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            SaveUserType(user);

            return user;
        }

        public async Task<User> DeleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser != null)
            {
                existingUser.First_Name = user.First_Name;
                existingUser.Last_Name = user.Last_Name;
                await _context.SaveChangesAsync();
            }
            return existingUser;
        }

        public bool IsUserCredentials(string password, string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user != null;
        }

        public bool IsUserNameTaken(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            return user != null;
        }
        private void SaveUserType(User user)
        {
            try
            {
                switch (user.UserType)
                {
                    case 0: // Parent
                        var parent = new Parent { UserId = user.UserId };
                        _context.Parents.Add(parent);
                        break;
                    case 1: // Student
                        var student = new Student { UserId = user.UserId };
                        _context.Students.Add(student);
                        break;
                    case 2: // Admin or other UserType
                        var admin = new Admin { UserId = user.UserId };
                        _context.Admins.Add(admin);
                        break;
                    default: // User does not exist
                        throw new Exception("Error saving user type: Error saving the user, User type: 0 for Parent, 1 for Student and 2 for Admin exists");
                }

                // Save changes after all entities are added
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, throw, etc.)
                Console.WriteLine($"Error saving user type: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

    }

}
