using RMV.DriverExaminer.Services.Utilities;
using RMV.DriverExaminer.Services.Models;

namespace RMV.DriverExaminer.Services.Interfaces
{
    public interface IExamDetailsService
    {
        Task<PublicApiModel> GetExamData(string code);
        Task<Response> CreateExamData(ExamDetailsModel examDetails);
        
    }
}
