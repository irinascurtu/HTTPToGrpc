// See https://aka.ms/new-console-template for more information
using FeedbackGrpc;
using Grpc.Core;

Console.WriteLine("Hello, World! I'm a grpc Client!");
Channel channel = new Channel("localhost:5006", ChannelCredentials.Insecure);

var client = new FeedbackGrpc.FeedbackGrpcService.FeedbackGrpcServiceClient(channel);

FeedbackRequest request = new FeedbackRequest() { Id = 2 };
Console.WriteLine($"sending: {request}");

var response = client.GetById(request);
Console.WriteLine(response.ToString());

Console.WriteLine("--------------------");

FeedbackRequestEmpty emptyRequest = new FeedbackRequestEmpty();
Console.WriteLine($"sending a request for GetAll(): {emptyRequest}");

using var streamingCall = client.GetAll(emptyRequest);

try
{
    await foreach (FeedbackResponse responseItem in streamingCall.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine($"{responseItem.ToString()}");
    }

}
catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
{
    Console.WriteLine("Your greetings timeout'd :)).");
}