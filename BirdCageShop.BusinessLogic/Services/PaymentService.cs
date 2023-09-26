
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Payment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IPaymentService {
        public PaymentViewModel CreatePayment(CreatePaymentRequestModel paymentCreate);
        public PaymentViewModel UpdatePayment(UpdatePaymentRequestModel paymentUpdate);
        public bool DeletePayment(int idTmp);
        public List<PaymentViewModel> GetAll();
        public PaymentViewModel GetById(int idTmp);
    }

    public class PaymentService : IPaymentService {

      private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public PaymentViewModel CreatePayment(CreatePaymentRequestModel paymentCreate)
        {
            throw new NotImplementedException();
        }

        public PaymentViewModel UpdatePayment(UpdatePaymentRequestModel paymentUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeletePayment(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<PaymentViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public PaymentViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
