using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BirdCageShop.BusinessLogic.Services
{
    public interface ILoginService
    {
            public LoginViewModel Authenticate(LoginRequestModel loginRequest);
        }
    public class LoginService : ILoginService {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public LoginService(IUserRepository userRepository, IMapper mapper,IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = optionsMonitor.CurrentValue;
        }

        public LoginViewModel Authenticate(LoginRequestModel loginRequest)
        {

            var user = _userRepository.Get().SingleOrDefault(x => x.Username.Equals(loginRequest.Username));

            if (user == null || user.Password != loginRequest.Password) return null;


            return _mapper.Map<LoginViewModel>(user);
        }
    /*    private string GenerateToken(User user)
        {
            var jwtTokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(_appSettings.SecretKey);


            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }*/
    

    }
    }
