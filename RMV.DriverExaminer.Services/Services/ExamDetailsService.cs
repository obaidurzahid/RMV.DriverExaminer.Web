
using RMV.DriverExaminer.Services.Utilities;
using RMV.DriverExaminer.Services.Interfaces;
using RMV.DriverExaminer.Services.Models;
using RMV.DriverExaminer.Services.Services.Interfaces;

namespace RMV.DriverExaminer.Services.Services
{
    public class ExamDetailsService : IExamDetailsService
    {
       private readonly IAppClientsService _appClientsService;

        public ExamDetailsService(IAppClientsService appClientsService)
        {
            _appClientsService = appClientsService ?? throw new ArgumentNullException(nameof(appClientsService));
        }
        
        public async Task<PublicApiModel> GetExamData(string code)
        {
            CancellationTokenSource tokenSrc = new CancellationTokenSource();
            tokenSrc.CancelAfter(TimeSpan.FromSeconds(50));

            var response = await _appClientsService.GetData("api/ExamDetails/GetExamData", tokenSrc.Token);
            var result = await response.ReadContentAs<PublicApiModel>();
            ////var result = JsonSerializer.Deserialize<dynamic>(result.ToString());
            return result;
        }
        
        public Task<Response> CreateExamData(ExamDetailsModel examDetails)
        {
            throw new NotImplementedException();
        }
    }  
}
