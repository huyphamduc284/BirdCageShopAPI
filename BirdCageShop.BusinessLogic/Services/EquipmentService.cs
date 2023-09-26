



using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Equipment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IEquipmentService {
        public EquipmentViewModel CreateEquipment(CreateEquipmentRequestModel equipmentCreate);
        public EquipmentViewModel UpdateEquipment(UpdateEquipmentRequestModel equipmentUpdate);
        public bool DeleteEquipment(int idTmp);
        public List<EquipmentViewModel> GetAll();
        public EquipmentViewModel GetById(int idTmp);
    }

    public class EquipmentService : IEquipmentService {

      private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public EquipmentViewModel CreateEquipment(CreateEquipmentRequestModel equipmentCreate)
        {
            throw new NotImplementedException();
        }

        public EquipmentViewModel UpdateEquipment(UpdateEquipmentRequestModel equipmentUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteEquipment(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<EquipmentViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public EquipmentViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
