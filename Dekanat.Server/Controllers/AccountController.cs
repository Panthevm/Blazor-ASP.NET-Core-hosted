using Dekanat.Server.Models;
using Dekanat.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dekanat.Server.Controllers {
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Registration
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            User user = new User { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) {
                await _signInManager.SignInAsync(user, false);
                return Ok(model);
            }
            else {
                return StatusCode(500);
            }
        }
        #endregion Registration

        #region Login
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded) {
                return BadRequest("Неправильный логин и (или) пароль");
            }
            else {
                return Ok(model);
            }

        }

        [HttpPost]
        [Route("LogOff")]
        public async Task<IActionResult> LogOff() {
            await _signInManager.SignOutAsync();
            return Ok();
        }
        #endregion Login

        #region Profile
        [HttpGet]
        [Route("Authorized")]
        public bool IsAuthirized() {
            return User.Identity.IsAuthenticated;
        }

        [Authorize]
        [HttpGet]
        [Route("Profile")]
        public async Task<ProfileViewModel> GetUserAsync() {
            ProfileViewModel model = new ProfileViewModel();

            User user = await _userManager.GetUserAsync(User);

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.SurName = user.SurName;

            model.Email = user.Email;
            model.Roles = "Role";

            return model;
        }

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> ProfileEdit([FromBody] ProfileViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null) {
                return NotFound();
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.SurName = model.SurName;
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) {
                return Ok(model);
            }
            else {
                return BadRequest();
            }
            
        }

        #endregion Profile
    }
}