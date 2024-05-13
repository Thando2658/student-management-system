using Microsoft.AspNetCore.Mvc;
using Student_Management_Portal.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_Management_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("AddParent")]
        public async Task<ActionResult<Parent>> AddParent([FromBody] Parent parent)
        {
            try
            {
                var addedParent = await _userService.AddParent(parent);
                return Ok(addedParent); // Return HTTP 200 OK with the added parent
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return HTTP 400 Bad Request with error message
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return HTTP 500 Internal Server Error with error message
            }
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<Student>> AddStudent([FromBody] Student student)
        {
            try
            {
                var addedStudent = await _userService.AddStudent(student);
                return Ok(addedStudent); // Return HTTP 200 OK with the added student
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return HTTP 400 Bad Request with error message
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return HTTP 500 Internal Server Error with error message
            }
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _userService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("GetParentById/{id}")]
        public async Task<ActionResult<Parent>> GetParentById(int id)
        {
            var parent = await _userService.GetParentById(id);
            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody]User user)
        {
            var users = await _userService.AddUser(user);

            if (users == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(users);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUser(user, id);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            var user = await _userService.DeleteUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("checkCredentials")]
        public ActionResult<bool> IsUserCredentials(User model)
        {
            var result = _userService.IsUserCredentials(model.Password, model.UserName);
            return Ok(result);
        }

        [HttpGet("checkUserNameTaken/{userName}")]
        public ActionResult<bool> IsUserNameTaken(string userName)
        {
            var result = _userService.IsUserNameTaken(userName);
            return Ok(result);
        }
    }
}
