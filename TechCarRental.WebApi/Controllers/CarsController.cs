using CarRental.Application.Dtos;
using CarRental.Application.Features.Command;
using CarRental.Application.Features.Querires;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechCarRental.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CarsController : ApiControllerBase
    {
        public CarsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ActionName("cars")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<CarViewDto>>>> GetCarsAsync()
        {
            var cars = await _mediator.Send(new GetAllCarQuery());
            
            return await SuccessResult("Cars data is selecte",cars);
        }

        [HttpPost]
        [ActionName("cars")]
        public async Task<ActionResult<ApiResponseModel<string>>> AddCars(AddCarCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Car added succesfully");
        }
    }
}
