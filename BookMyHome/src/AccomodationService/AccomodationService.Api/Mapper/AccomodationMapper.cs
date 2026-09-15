using AccomodationService.FacadeLib.Commands.DTOs;
using BookMyHome.ContractsLib.Requests;

namespace AccomodationService.Api.Mapper
{
    public static class AccomodationMapper
    {
        public static CreateAccomodationCommand CreateRequestAsCommand(this CreateAccomodationRequest request)
        {
            var output = new CreateAccomodationCommand(
                request.HostId,
                request.Title
                );

            return output;
        }
    }
}
