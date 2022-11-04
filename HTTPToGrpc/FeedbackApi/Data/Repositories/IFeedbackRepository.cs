using FeedbackApi.Data.Entities;

namespace FeedbackApi.Data.Repositories
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAll();
        Feedback GetById(int id);
        IEnumerable<Feedback> GetForIds(IEnumerable<int> talkIds);
        List<Feedback> GetForTalk(int talkId);
    }
}