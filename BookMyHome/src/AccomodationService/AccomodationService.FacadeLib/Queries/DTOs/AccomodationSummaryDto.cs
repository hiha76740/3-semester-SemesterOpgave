namespace AccomodationService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="ListingName"></param>
/// <param name="ListingType"></param>
/// <param name="City"></param>
/// <param name="Country"></param>
public record AccomodationSummaryDto(string ListingName, string ListingType, string City, string Country);
