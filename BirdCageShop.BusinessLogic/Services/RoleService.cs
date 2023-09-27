

using AutoMapper;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Role;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IRoleService {
        public RoleViewModel CreateRole(CreateRoleRequestModel roleCreate);
        public RoleViewModel UpdateRole(UpdateRoleRequestModel roleUpdate);
        public bool DeleteRole(int idTmp);
        public List<RoleViewModel> GetAll();
        public RoleViewModel GetById(int idTmp);
    }

    public class RoleService : IRoleService {

        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository , IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public RoleViewModel CreateRole(CreateRoleRequestModel roleCreate)
        {
            throw new NotImplementedException();
        }

        public RoleViewModel UpdateRole(UpdateRoleRequestModel roleUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<RoleViewModel> GetAll() 
        {
            var roles = _roleRepository.Get().ToList();
            return _mapper.Map<List<RoleViewModel>>(roles);
        }

        public RoleViewModel GetById(int idTmp) 
        {
            var role = _roleRepository.Get().SingleOrDefault(x => x.RoleId.Equals(idTmp));
            return _mapper.Map<RoleViewModel>(role);
        }

    }

}
