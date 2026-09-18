using AccomodationService.FacadeLib.Commands.DTOs;
using AccomodationService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace AccomodationService.Api.Mapper
{
    public static class AccomodationMapper
    {
        public static AccomodationResponse AsResponse(this AccomodationDto Dto)
        {
            var output = new AccomodationResponse(
                Dto.AccomodationId,
                Dto.Title
                );

            return output;
        }


        public static CreateAccomodationCommand CreateRequestAsCommand(this CreateAccomodationRequest request, Guid id)
        {
            var output = new CreateAccomodationCommand(
                id,
                request.Title,
                request.Street,
                request.PostalCode,
                request.City
                );

            return output;
        }
    }
}
