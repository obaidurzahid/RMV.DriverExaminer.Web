using Newtonsoft.Json;
namespace RMV.DriverExaminer.Services.Utilities
{
    public static class HttpResponseHelper
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(dataAsString);
        }

        
    }
}
