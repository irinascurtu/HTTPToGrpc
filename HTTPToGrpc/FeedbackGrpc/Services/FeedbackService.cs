using AutoMapper;
using FeedbackApi.Data.Repositories;
using FeedbackGrpc;
using Grpc.Core;

namespace FeedbackGrpc.Services
{
    public class FeedbackService : FeedbackGrpcService.FeedbackGrpcServiceBase
    {
        private readonly IFeedbackRepository repository;
        private readonly IMapper mapper;

        public FeedbackService(IFeedbackRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override Task<FeedbackResponse> GetById(FeedbackRequest request, ServerCallContext context)
        {
            var item = repository.GetById(request.Id);
            if (item == null)
            {

            }
            FeedbackResponse response = mapper.Map<FeedbackResponse>(item);
            return Task.FromResult(response);
        }



        public override async Task GetAll(FeedbackRequestEmpty request, IServerStreamWriter<FeedbackResponse> responseStream, ServerCallContext context)
        {
            var items = repository.GetAll();
            if (items == null) { }
            List<FeedbackResponse> responseItems = mapper.Map<List<FeedbackResponse>>(items);


            for (int i = 0; i < responseItems.Count(); i++)
            {
                await responseStream.WriteAsync(responseItems[i]);
            }
           
        }
    }
}

