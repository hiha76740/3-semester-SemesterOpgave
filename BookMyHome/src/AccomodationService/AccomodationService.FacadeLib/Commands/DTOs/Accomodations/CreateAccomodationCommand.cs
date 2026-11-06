namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="HostId"></param>
/// <param name="Title"></param>
/// <param name="Street"></param>
/// <param name="PostalCode"></param>
/// <param name="City"></param>
/// <param name="Country"></param>
/// <param name="FacilitiesIds"></param>
/// <param name="ImageStream"></param>
/// <param name="Extension"></param>
public record CreateAccomodationCommand(
    Guid HostId,
    string Title,
    string Street,
    string PostalCode,
    string City,
    string Country,
    List<Guid> FacilitiesIds,
    Stream? ImageStream,
    string? Extension
    );
