using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.DomainLib.Entities;

public class Accomodation
{
    public AccomodationId Id { get; init; }
    public string Title { get; init; }



    public static Accomodation Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title can not be empty");

        var accomodation = new Accomodation(title);

        return accomodation;
    }


    private Accomodation(string title)
    {
        Id = new AccomodationId(Guid.NewGuid());
        Title = title;
    }

    // EF constructor
    private Accomodation() { }
}
