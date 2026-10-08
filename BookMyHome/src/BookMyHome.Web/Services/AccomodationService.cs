using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class AccomodationService(HttpClient httpClient) : IAccomodationService
    {
        private readonly string baseUrl = "https://localhost:8010/accomodations-api/";


        async Task<int> IAccomodationService.Create(CreateAccomodationRequest createRequest, IBrowserFile? imageFile)
        {
            using var content = new MultipartFormDataContent();


            var requestContent = JsonContent.Create(createRequest);
            content.Add(requestContent,"data");


            if (imageFile != null)
            {
                const long maxFileSize = 5 * 1024 * 1024;
                var fileContent = new StreamContent(imageFile.OpenReadStream(maxFileSize));
                content.Add(fileContent, "file", imageFile.Name);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}")
            {
                Content = content
            };

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            return (int)response.StatusCode;
        }

        async Task<int> IAccomodationService.UpdateAccomodationAsync(Guid accomodationId, UpdateAccomodationRequest updateRequest, IBrowserFile? imageFile)
        {
            using var content = new MultipartFormDataContent();

            var requestContent = JsonContent.Create(updateRequest);
            content.Add(requestContent, "data");

            if (imageFile != null)
            {
                const long maxFileSize = 5 * 1024 * 1024;
                var fileContent = new StreamContent(imageFile.OpenReadStream(maxFileSize));
                content.Add(fileContent, "file", imageFile.Name);
            }


            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}{accomodationId}")
            {
                Content = content
            };

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            return (int)response.StatusCode;
        }

        async Task<AccomodationResponse?> IAccomodationService.GetAccomodationByIdAsync(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}{id}");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var accomodation = await response.Content.ReadFromJsonAsync<AccomodationResponse?>();

            if (accomodation == null)
                throw new InvalidOperationException("Could not deserialize accomodation");

            return accomodation;
        }

        async Task<IReadOnlyList<AccomodationTypeResponse>> IAccomodationService.GetAllAccomodationTypes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}types");

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var list = await response.Content.ReadFromJsonAsync<IReadOnlyList<AccomodationTypeResponse>>();

            if (list == null)
                throw new InvalidOperationException("Could not deserialize accomodation types");

            return list;
        }

        async Task<IReadOnlyList<AccomodationResponse>> IAccomodationService.GetCurrentUserAccomodationsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var accomodation = await response.Content.ReadFromJsonAsync<IReadOnlyList<AccomodationResponse>>();

            if (accomodation == null)
                throw new InvalidOperationException("Could not deserialize accomodation");

            return accomodation;
        }

        
    }
}
