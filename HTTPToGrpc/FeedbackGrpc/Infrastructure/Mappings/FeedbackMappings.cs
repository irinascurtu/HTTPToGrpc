using AutoMapper;
using FeedbackApi.Data.Entities;

namespace FeedbackGrpc.Infrastructure.Mappings
{

    public class FeedbackMappings : Profile
    {

        public FeedbackMappings()
        {
            CreateMap<Feedback, FeedbackResponse>();
        }
    }
}
