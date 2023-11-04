
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
        public ReviewViewModel UpdateProduct(UpdateReviewRequestModel reviewUpdate);
  

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

        public ReviewViewModel UpdateProduct(UpdateReviewRequestModel reviewUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
