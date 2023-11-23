

using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Review;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/review")]
    public class ReviewController : ControllerBase
    {

        private IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<ReviewViewModel> CreateReview(CreateReviewRequestModel reviewCreate)
        {
            var reviewtCreated = _reviewService.CreateReview(reviewCreate);

            if (reviewtCreated == null)
            {
                return NotFound("Cannot rating or feedback");
            }
            return reviewtCreated;
        }
        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<ReviewViewModel>> GetAll()
        {
            var reviewList = _reviewService.GetAll();

            if (reviewList == null)
            {
                return NotFound("Not Found");
            }
            return reviewList;
        }


    }

}
