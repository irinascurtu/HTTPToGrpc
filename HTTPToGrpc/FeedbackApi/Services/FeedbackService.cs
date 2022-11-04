using FeedbackApi.Data.Entities;
using FeedbackApi.Data.Repositories;

namespace FeedbackApi.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }


        public List<Feedback> GetAll()
        {
            return this.feedbackRepository.GetAll();
        }

        public Feedback GetById(int id)
        {
            return this.feedbackRepository.GetById(id);
        }

    }
}
