
using AutoMapper;
using BirdCageShop.DataAccess.Models;
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
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public PaymentViewModel CreatePayment(CreatePaymentRequestModel paymentCreate)
        {
            var payment = _mapper.Map<Payment>(paymentCreate);
            payment.PaymentId = Guid.NewGuid().ToString();
            payment.PaymentMethod = paymentCreate.PaymentMethod;
            payment.CardNumber = paymentCreate.CardNumber;  
            payment.Cvv = paymentCreate.Cvv;
            payment.ExpirationDate = paymentCreate.ExpirationDate;

            _paymentRepository.Create(payment);
            _paymentRepository.Save();

            return _mapper.Map<PaymentViewModel>(payment);  
            
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
