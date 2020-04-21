using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using passenger_management.Models;
using passenger_management.Services;

namespace passenger_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerService _passengerService;

        public PassengerController(PassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        public ActionResult<List<Passenger>> Get()
        {
            return _passengerService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetPassenger")]
        public ActionResult<Passenger> Get(string id)
        {
            var passenger = _passengerService.Get(id);

            if (passenger == null) return NotFound();

            return passenger;
        }

        [HttpPost]
        public ActionResult<Passenger> Create(Passenger passenger)
        {
            _passengerService.Create(passenger);

            return CreatedAtRoute("GetPassenger", new {id = passenger.Id}, passenger);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Passenger> Update(string id, Passenger passengerIn)
        {
            var passenger = _passengerService.Get(id);

            if (passenger == null) return NotFound();

            _passengerService.Update(id, passengerIn);

            return passenger;
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult<Passenger> Delete(string id)
        {
            var passenger = _passengerService.Get(id);

            if (passenger == null) return NotFound();

            _passengerService.Remove(passenger.Id);

            return passenger;
        }
    }
}