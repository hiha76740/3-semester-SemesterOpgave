using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Components.Forms;

namespace BookMyHome.Web.ServiceInterfaces;

/// <summary>
/// 
/// </summary>
public interface IAccomodationService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="imageFile"></param>
    /// <returns></returns>
    Task<int> Create(CreateAccomodationRequest request, IBrowserFile? imageFile);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AccomodationResponse?> GetAccomodationByIdAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<AccomodationResponse>> GetCurrentUserAccomodationsAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="updateRequest"></param>
    /// <param name="imageFile"></param>
    /// <returns></returns>
    Task<int> UpdateAccomodationAsync(Guid accomodationId, UpdateAccomodationRequest updateRequest, IBrowserFile? imageFile);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<AccomodationTypeResponse>> GetAllAccomodationTypes();
}
