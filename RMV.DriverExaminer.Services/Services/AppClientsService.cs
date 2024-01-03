using RMV.DriverExaminer.Services.Services.Interfaces;

namespace RMV.DriverExaminer.Services.Services
{
    public class AppClientsService : IAppClientsService
    {
        private readonly HttpClient _httpClient;

        public AppClientsService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("http://localhost:5099/");
        }

        public async Task<HttpResponseMessage> GetData(string apiAction, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(apiAction, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            return response;

        }
    }
}
