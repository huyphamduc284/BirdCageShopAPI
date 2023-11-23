
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Review;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services
{
    public interface IReviewService
    {
        public ReviewViewModel CreateReview(CreateReviewRequestModel reviewCreate);
        public ReviewViewModel UpdateReview(UpdateReviewRequestModel reviewUpdate);
        public List<ReviewViewModel> GetAll();
  

    }
    public class ReviewService : IReviewService
    {
      
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;

        }

        public ReviewViewModel CreateReview(CreateReviewRequestModel reviewCreate)
        {
            var review = _mapper.Map<Review>(reviewCreate);
            review.TimeStamp = DateTime.Now;


            return _mapper.Map<ReviewViewModel>(review);
        }

        public List<ReviewViewModel> GetAll()
        {
            var listReview = _reviewRepository.Get().ToList();
            if (listReview == null) return null;

            return _mapper.Map<List<ReviewViewModel>>(listReview);
        }

        public ReviewViewModel UpdateReview(UpdateReviewRequestModel reviewUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
