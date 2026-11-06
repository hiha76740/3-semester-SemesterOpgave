using BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.Entities;

/// <summary>
/// 
/// </summary>
public class Facility
{
    /// <summary>
    /// 
    /// </summary>
    public FacilityId Id { get; init; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; init; } = string.Empty;

    internal Facility(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Facility name can not be empty");

        Id = new FacilityId(Guid.NewGuid());
        Name = name;
    }

    private Facility() { }
}
