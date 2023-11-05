
using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IUserService {
        public UserViewModel CreateUser(CreateUserRequestModel userCreate);
        public UserViewModel UpdateUser(UpdateUserRequestModel userUpdate);
        public bool DeleteUser(string idTmp);
        public List<UserViewModel> GetAll();
        public UserViewModel GetById(string idTmp);
       /* public string GetCurrentUserId();*/
    }

    public class UserService : IUserService {

      private readonly IUserRepository _userRepository;
        /*private readonly IHttpContextAccessor _httpContextAccessor;*/
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper/*, IHttpContextAccessor _httpContextAccessor*/)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserViewModel CreateUser(CreateUserRequestModel userCreate)
        {
            var user = _mapper.Map<User>(userCreate);
            user.UserId = Guid.NewGuid().ToString();
            user.Status = (int?)UserStatusEnum.Active;
            user.RoleId = (int?)UserRoleEnum.Customer;
            user.CreateTime = DateTime.Now;

            _userRepository.Create(user);
            _userRepository.Save();

            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel UpdateUser(UpdateUserRequestModel userUpdate) 
        {
            var user = _userRepository.Get().SingleOrDefault(x => x.UserId.Equals(userUpdate.UserId));
            if(user == null) return null;
            
            user.UpdateTime = DateTime.Now;
            user.Username = userUpdate.Username;
            user.Password = userUpdate.Password;
            user.FirstName = userUpdate.FirstName;
            user.LastName = userUpdate.LastName;    
            user.PhoneNumber= userUpdate.PhoneNumber;
            user.Email = userUpdate.Email;
            user.Address = userUpdate.Address;
            user.Image = userUpdate.Image;

            _userRepository.Update(user);
            _userRepository.Save();

            return _mapper.Map<UserViewModel>(user);
        }

        public bool DeleteUser(string idTmp)
        {
            var user = _userRepository.Get().SingleOrDefault(x => x.UserId.Equals(idTmp));
            
            if(user == null) return false;
            user.Status = (int?)UserStatusEnum.InActive;

            _userRepository.Update(user);
            _userRepository.Save();
            return true;
        }

        public List<UserViewModel> GetAll() 
        {
          var users = _userRepository.Get().ToList();
            if (users == null) return null;
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public UserViewModel GetById(string idTmp) 
        {
            var user = _userRepository.Get().SingleOrDefault(x => x.UserId.Equals(idTmp));
            return _mapper.Map<UserViewModel>(user);
        }
      /*  public string GetCurrentUserId()
        {
            // Get current user's ID from the HttpContext or wherever the user information is stored
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }*/

    }

}
