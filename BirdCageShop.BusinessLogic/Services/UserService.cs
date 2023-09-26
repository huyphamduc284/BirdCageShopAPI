

using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IUserService {
        public UserViewModel CreateUser(CreateUserRequestModel userCreate);
        public UserViewModel UpdateUser(UpdateUserRequestModel userUpdate);
        public bool DeleteUser(string idTmp);
        public List<UserViewModel> GetAll();
        public UserViewModel GetById(string idTmp);
    }

    public class UserService : IUserService {

      private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserViewModel CreateUser(CreateUserRequestModel userCreate)
        {
            var user = _mapper.Map<User>(userCreate);
            user.UserId =Guid.NewGuid().ToString();
            user.Status = (int?)UserStatusEnum.Active;
            user.RoleId = (int?)UserRoleEnum.Customer;

            _userRepository.Create(user);
            _userRepository.Save();
            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel UpdateUser(UpdateUserRequestModel userUpdate) 
        {
            var user = _userRepository.Get().SingleOrDefault(x => x.UserId.Equals(userUpdate.UserId));
            if(user == null)
            {
                return null;
            }
            user.Username = userUpdate.Username;
            user.Password = userUpdate.Password;
            user.FirstName = userUpdate.FirstName;
            user.LastName = userUpdate.LastName;    
            user.PhoneNumber= userUpdate.PhoneNumber;
            user.Email = userUpdate.Email;

            _userRepository.Update(user);
            _userRepository.Save();
            return _mapper.Map<UserViewModel>(user);
        }

        public bool DeleteUser(string idTmp)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetAll() 
        {
          var users = _userRepository.Get().ToList();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public UserViewModel GetById(string idTmp) 
        {
            var user = _userRepository.Get().SingleOrDefault(x => x.UserId.Equals(idTmp));
            return _mapper.Map<UserViewModel>(user);
        }

    }

}
