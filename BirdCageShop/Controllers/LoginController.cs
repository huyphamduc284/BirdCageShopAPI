using BirdCageShop.BusinessLogic.Services;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BirdCageShop.Presentation.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/login")]
    public class LoginController : ControllerBase { 
        private ILoginService _loginService;
       
        public LoginController(ILoginService loginService)
        {
             _loginService = loginService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<LoginViewModel> CreateUser(LoginRequestModel loginRequest)
        {
            try
            {
                var user = _loginService.Authenticate(loginRequest);

                if (user == null)
                {
                    return NotFound("");
                }

                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
           
               
        }
    }
}
