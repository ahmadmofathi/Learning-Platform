using Acedify.Web.BL;
using Acedify.Web.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserManager _userManager1;
        private readonly IAdminManager _adminManager;
        private readonly IConfiguration _configuration;
        public UserController(UserManager<User> userManager, IConfiguration configuration, IAdminManager adminManager, IUserManager userManager1)
        {
            _userManager = userManager;
            _adminManager = adminManager;
            _configuration = configuration;
            _userManager1 = userManager1;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO registerDTO)
        {
            var existingUser = await _userManager.FindByNameAsync(registerDTO.Username!);
            if (existingUser != null)
            {
                return BadRequest("Username is already taken.");
            }

            var newUser = new User { };
            if(registerDTO.Role == "Admin")
            {
                newUser = new Admin { 
                Id = Guid.NewGuid().ToString(),
                UserName = registerDTO.Username,
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                Role = registerDTO.Role,
                };
            }
            else if(registerDTO.Role =="Super Admin")
            {
                newUser = new SuperAdmin
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = registerDTO.Username,
                    Name = registerDTO.Name,
                    Email = registerDTO.Email,
                    Role = registerDTO.Role,
                };
            }
            else if (registerDTO.Role == "Student")
            {
                newUser = new Student
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = registerDTO.Username,
                    Name = registerDTO.Name,
                    Email = registerDTO.Email,
                    Role = registerDTO.Role,
                };
            }
            else if (registerDTO.Role == "Technical Support")
            {
                newUser = new TechnicalSupport
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = registerDTO.Username,
                    Name = registerDTO.Name,
                    Email = registerDTO.Email,
                    Role = registerDTO.Role,
                };
            }
            else if (registerDTO.Role == "Teacher")
            {
                newUser = new Teacher
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = registerDTO.Username,
                    Name = registerDTO.Name,
                    Email = registerDTO.Email,
                    Role = registerDTO.Role,
                };
            }
            else
            {
                newUser = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = registerDTO.Username,
                    Name = registerDTO.Name,
                    Email = registerDTO.Email,
                    Role = registerDTO.Role,
                };
            }
            

            var creationResult = await _userManager.CreateAsync(newUser, registerDTO.Password!);
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            // Fetch the user from the database
            var createdUser = await _userManager.FindByNameAsync(newUser.UserName!);
            if (createdUser == null)
            {
                return BadRequest("User was not found after creation");
            }

            var userClaims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, newUser.UserName!),
    };

            // Now add the claims
            var claimsResult = await _userManager.AddClaimsAsync(newUser, userClaims);
            if (!claimsResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);
                return BadRequest(claimsResult.Errors);
            }
            return Ok(newUser);
        }



        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO credintials)
        {
            var user = await _userManager.FindByNameAsync(credintials.Username!);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            if (await _userManager.IsLockedOutAsync(user))
            {
                return BadRequest("Try Again Later, Your Profile is locked!");
            }
            var userClaims = await _userManager.GetClaimsAsync(user);
            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, credintials.Password!);
            if (!isAuthenticated)
            {
                await _userManager.AccessFailedAsync(user);
                return Unauthorized("Wrong Username or Password");
            }
            var exp = DateTime.Now.AddMinutes(750);
            var secretKey = _configuration.GetValue<string>("SecretKey");
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException("The secret key cannot be null or empty.");
            }
            var secretKeyBytes = Encoding.ASCII.GetBytes(secretKey);
            var Key = new SymmetricSecurityKey(secretKeyBytes);
            var methodGeneratingToken = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
            var jwt = new JwtSecurityToken(
                claims: userClaims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(120)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(jwt);
            return new TokenDTO
            {
                Token = tokenString,
                ExpiryDate = exp,
                Username = user.UserName,
                User_id = user.Id,
            };
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserAddDTO user)
        {
            var userId = _userManager1.AddUser(user);
            return Ok(new { UserId = userId });
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateUser(string id, UserDTO user)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_userManager1.UpdateUser(user));
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            var result = _userManager1.DeleteUser(userId);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(string userId)
        {
            var user = _userManager1.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userManager1.GetAllUsers();
            return Ok(users);
        }
    }
}
