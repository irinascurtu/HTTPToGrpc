using FeedbackApi.Data.Entities;

namespace FeedbackApi.Services
{
    public interface IFeedbackService
    {
        List<Feedback> GetAll();
        Feedback GetById(int id);
    }
}