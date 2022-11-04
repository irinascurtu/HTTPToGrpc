using FeedbackApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApi.Data
{
    public class FeedbacksDbContext : DbContext
    {
        public FeedbacksDbContext(DbContextOptions<FeedbacksDbContext> options) : base(options)
        {

        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}

