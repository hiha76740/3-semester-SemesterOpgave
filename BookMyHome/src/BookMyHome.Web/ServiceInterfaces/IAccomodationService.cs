using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Components.Forms;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IAccomodationService
    {
        Task<int> Create(CreateAccomodationRequest request, IBrowserFile? imageFile);
        Task<AccomodationResponse?> GetAccomodationByIdAsync(Guid id);
        Task<IReadOnlyList<AccomodationResponse>> GetCurrentUserAccomodationsAsync();

        Task<int> UpdateAccomodationAsync(Guid accomodationId, UpdateAccomodationRequest updateRequest, IBrowserFile? imageFile);

        Task<IReadOnlyList<AccomodationTypeResponse>> GetAllAccomodationTypes();
    }
}
