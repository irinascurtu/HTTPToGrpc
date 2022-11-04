using FeedbackApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApi.Data.Repositories
{

    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbacksDbContext dbContext;

        public FeedbackRepository(FeedbacksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Feedback> GetAll()
        {
            return dbContext.Feedbacks.ToList();
        }


        public IEnumerable<Feedback> GetForIds(IEnumerable<int> talkIds)
        {
            return  dbContext.Feedbacks.Where(pr => talkIds.Contains(pr.TalkId));
        }

        public List<Feedback> GetForTalk(int talkId)
        {
            return dbContext.Feedbacks.Where(x => x.TalkId == talkId).ToList();
        }

        public Feedback GetById(int id)
        {
            return dbContext.Feedbacks.Find(id);
        }

    }
}
