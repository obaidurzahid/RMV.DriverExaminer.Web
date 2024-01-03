namespace RMV.DriverExaminer.Services.Services.Interfaces
{
    //https://johnthiriet.com/efficient-api-calls/
    public interface IAppClientsService
    {
        Task<HttpResponseMessage> GetData(string apiAction, CancellationToken cancellationToken);
    }
    
}
