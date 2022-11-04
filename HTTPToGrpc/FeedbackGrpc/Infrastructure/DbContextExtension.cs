using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FeedbackApi.Infrastructure
{
    public static class DbContextExtension
    {
        public static void EnsureSeeded(this FeedbacksDbContext context)
        {
            context.EnsureSeedData();
        }
    }

}

