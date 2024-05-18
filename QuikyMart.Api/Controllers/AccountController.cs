using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Api.Middleware;
using QuikyMart.Data.Entites.Accounting;
using QuikyMart.Service.Dtos;
using QuikyMart.Service.ExceptionsHandeling;
using QuikyMart.Service.ServicesJWT;
using System.Security.Claims;

namespace QuikyMart.Api.Controllers
{

    public class AccountController : BaseCont
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<AppUser> userManager , 
            SignInManager<AppUser> signInManager , 
            ITokenService tokenService,
            IConfiguration configuration,
            IMapper mapper 
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _configuration = configuration;
            _mapper = mapper;
        }
        #region Login

        [HttpPost("Login")]

        public async Task<ActionResult<UserDTO>> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var userPass = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, false);

            if (!userPass.Succeeded) return BadRequest(new ApiResponse(401));

            var userResult = new UserDTO()
            {
                Email = user.Email,
                FullName = user.FullName,
                Token = await _tokenService.CreateToken(user, _userManager, _configuration)

            };

            return Ok(userResult);


        }

        #endregion

        #region Register

        [HttpPost("Rigester")]
        public async Task<ActionResult<UserDTO>> Rigester(RegisterDTO registerDTO)
        {

            if (CheckUserExist(registerDTO.Email).Result.Value)
            {
                return BadRequest(new ApiResponse(400 , "Email is Already Exist"));
            }
            var user = new AppUser()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                FullName = registerDTO.FullName

            };
            var result = await _userManager.CreateAsync(user , registerDTO.Password);
            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400));

            var UserResult = new UserDTO()
            {
                Email = registerDTO.Email,
                FullName = registerDTO.FullName,
                Token = await _tokenService.CreateToken(user, _userManager, _configuration)
            };

            return Ok(UserResult);
        }
        #endregion

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var CurrentUser = User.FindFirstValue(ClaimTypes.Email);

            var UserEmail = await _userManager.FindByEmailAsync(CurrentUser);


            return Ok(new UserDTO()
            {
                FullName = UserEmail.FullName,
                Email = UserEmail.Email,
                Token = await _tokenService.CreateToken(UserEmail, _userManager , _configuration),
            });
        }

        [Authorize]
        [HttpGet("GetAddressUser")]
        public async Task<ActionResult<AddressDTO>> GetAddressUser()
        {


            var UserEmail = await _userManager.FineUserWithAddressAsync(User);


            var userAddMapper = _mapper.Map<Address, AddressDTO>(UserEmail.Addresss);

            return Ok(userAddMapper);
        }


        [Authorize]
        [HttpPut("UpdateAddressUser")]
        public async Task<ActionResult<AddressDTO>> UpdateAddressUser(AddressDTO model)
        {
            var UserEmail = await _userManager.FineUserWithAddressAsync(User);
            var Address = _mapper.Map<AddressDTO, Address>(model);

            UserEmail.Addresss = Address;


            var Result = await _userManager.UpdateAsync(UserEmail);

            if (!Result.Succeeded) return BadRequest(new ApiResponse(400));





            return Ok(model);
        }


        [HttpGet("CheckUserExist")]
        public async Task<ActionResult<bool>> CheckUserExist(string email)
        {
            var UserEmail = await _userManager.FineUserWithAddressAsync(User);
            if (UserEmail == null) return false;

            return true;
        }


    }
}
