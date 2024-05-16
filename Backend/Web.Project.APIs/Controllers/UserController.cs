using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinalProject.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khadamati
{
    [ApiController]
    public class UserController:Controller
    {
        public UserManager<User> UserManager;
        private readonly IConfiguration _configuration;
        public IUserManger UserManger;

        public UserController(IConfiguration configuration, UserManager<User> userManager, IUserManger User)
        {
            _configuration = configuration; 
            UserManager = userManager;
            UserManger = User;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<UserReadDto>> GetAll()
        {
            return UserManger.GetAll();
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<UserReadDto>> GetAllUsers()
        {
            return UserManger.GetAllUsers();
        }
        [HttpGet]
        [Route("GetAllAdmins")]
        public ActionResult<List<UserReadDto>> GetAllAdmins()
        {
            return UserManger.GetAllAdmins();
        }
        [HttpGet]
        [Route("GetbyID")]
        public ActionResult<UserReadDto> GetbyID(string ID)
        {
            return UserManger.GetUser(ID);
        }
        [HttpGet]
        [Route("GetDetailsbyIDSync")]
        public ActionResult<UserDetailsDTO> GetDetailsbyID(string ID)
        {
            return UserManger.GetUserDetails(ID);
        }
        [HttpGet]
        [Route("GetDetailsbyID")]
        public async Task<ActionResult<UserDetailsDTO>> GetDetailsbyID()
        {
            var id = await UserManager.GetUserAsync(User);
            if(id==null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return UserManger.GetUserDetails(id.Id);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(UserUpdateDto userUpdate)
        {
            User? user = await UserManager.GetUserAsync(User);
            //string id = UserManager.GetUserId(User);
            UserManger.UpateUserData(user.Id, userUpdate);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete]
        [Route("Remove")]
        public ActionResult Remove(string id)
        {
            //string id = UserManager.GetUserId(User);
            UserManger.RemoveUser(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        [Route("login")]
        //=> /api/users/static-login
        public async Task<ActionResult<string>> Login(UserLoginDTO credentials)
        {
            #region Username and Password verification

            User? user = await UserManager.FindByNameAsync(credentials.username);
            if (user is null)
            {
                return StatusCode(0);
            }

            bool isPasswordCorrect = await UserManager.CheckPasswordAsync(user, credentials.password);
            if (!isPasswordCorrect)
            {
                return StatusCode(1);
            }

            #endregion

            #region Generate Token

            var claimsList = await UserManager.GetClaimsAsync(user);
            string secretKey = _configuration.GetValue<string>("SecretKey")!;
            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyInBytes);
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: claimsList,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMonths(3));
            var tokenHandler = new JwtSecurityTokenHandler();
            string t = tokenHandler.WriteToken(token);
            return Ok( new
            {
                usertoken = t,
                userclaims = claimsList.Select(i=>i.Value),
            }) ;

            #endregion
        }
        [HttpPost]
        [Route("User/Register")]
        public async Task<ActionResult> Register(UserAddDTO registerDto)
        {
            var User = new User
            {
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.Phone,
                Email = registerDto.Email,
                Location = registerDto.Location,
            };

            var result = await UserManager.CreateAsync(User, registerDto.Password);
           
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claimsLsit = new List<Claim>()
            { 
                new Claim(ClaimTypes.NameIdentifier,User.Id),
                new Claim(ClaimTypes.Role,"User")
            };

            await UserManager.AddClaimsAsync(User, claimsLsit);

            string secretKey = _configuration.GetValue<string>("SecretKey")!;
            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyInBytes);
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: claimsLsit,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMonths(3));
            var tokenHandler = new JwtSecurityTokenHandler();
            string t = tokenHandler.WriteToken(token);
            return Ok(new
            {
                usertoken = t
            });
        }
        [HttpPost]
        [Route("Admin/Register")]
        public async Task<ActionResult> AdminRegister(UserAddDTO registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.Phone,
                Email = registerDto.Email,
                Location = registerDto.Location,
            };
            var result = await UserManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            var claimsLsit = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"Admin")
            };
            await UserManager.AddClaimsAsync(user, claimsLsit);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        [Route("Manger/Register")]
        public async Task<ActionResult> MangerRegister(UserAddDTO registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.Phone,
                Email = registerDto.Email,
                Location = registerDto.Location,
            };
            var result = await UserManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            var claimsLsit = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Manger")
            };
            await UserManager.AddClaimsAsync(user, claimsLsit);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        [Route("AddBookmark")]
        public async Task<ActionResult> AddBookMark(int serviceID)
        {
            var user = await UserManager.GetUserAsync(User);
            UserManger.AddBookmark(user.Id, serviceID);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete]
        [Route("DeleteBookmark")]
        public async Task<ActionResult> RemoveBookMark(int serviceID)
        {
            var user = await UserManager.GetUserAsync(User);
            UserManger.RemoveBookmark(user.Id, serviceID);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        [Route("Claims")]
        public async Task<ActionResult> UserClaims()
        {
            var user = await UserManager.GetUserAsync(User);
            var claimsList = await UserManager.GetClaimsAsync(user);
            return Ok(new
            {
                userclaims = claimsList.Select(i => i.Value),
            });
        }

    }
}
