    using AutoMapper;

    using BirdCageShop.DataAccess.Repositories;
    using Ecommerce.BusinessLogic.RequestModels.User;
    using Ecommerce.BusinessLogic.ViewModels;
   

    namespace BirdCageShop.BusinessLogic.Services
    {
        public interface ILoginService
        {
            public LoginViewModel Authenticate(LoginRequestModel loginRequest);
        }
        public class LoginService : ILoginService{

            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public LoginService(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public LoginViewModel Authenticate(LoginRequestModel loginRequest)
            {
          
                var user =  _userRepository.Get().SingleOrDefault(x => x.Username.Equals(loginRequest.Username));

                if (user == null || user.Password != loginRequest.Password) return null;
            
           
                return _mapper.Map<LoginViewModel>(user);
            }

       
        }
    }
