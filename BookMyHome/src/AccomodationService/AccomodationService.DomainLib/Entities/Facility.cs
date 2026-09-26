using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.Entities;

public class Facility
{
    public FacilityId Id { get; init; } = null!;

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
