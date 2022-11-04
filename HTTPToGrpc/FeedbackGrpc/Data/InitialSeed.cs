using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApi.Data
{
    public static class InitialSeed
    {

        public static void EnsureSeedData(this FeedbacksDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Feedbacks.Any())
            {
                dbContext.Feedbacks.Add(new Entities.Feedback()
                {
                    Comments = "blabala",
                    Content = 3,
                    Delivery = 3,
                    TalkId = 2
                });
                dbContext.Feedbacks.Add(new Entities.Feedback()
                {
                    Comments = "blabala2",
                    Content = 5,
                    Delivery = 5,
                    TalkId = 2
                });

                dbContext.Feedbacks.Add(new Entities.Feedback()
                {
                    Comments = "blabala",
                    Content = 5,
                    Delivery = 3,
                    TalkId = 1
                });

                dbContext.SaveChanges();

            }
        }
    }
}