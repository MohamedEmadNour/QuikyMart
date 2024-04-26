using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.Entites.Accounting;
using QuikyMart.Service.Dtos;
using QuikyMart.Service.ExceptionsHandeling;

namespace QuikyMart.Api.Controllers
{

    public class AccountController : BaseCont
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        #region Login

        #endregion

        #region Register

        [HttpPost("Rigester")]
        public async Task<ActionResult<UserDTO>> Rigester(RegisterDTO registerDTO)
        {
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
                Token = "Token Ya hamada"
            };

            return Ok(UserResult);
        }
        #endregion
    }
}
