﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController] // used for controller validation
    [Authorize] // authorization required for all asks
    public class RestaurantController : ControllerBase
    {

        private IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPut("{Id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute]int id)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);                      //Controller validation 
            }
            _restaurantService.Update(Id, dto);*/

            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        [Authorize(Policy = "Atleast20")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantService.GetAll();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{Id}")]
        [AllowAnonymous] // this action is excluded from main authorization
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);

            return Ok(restaurant);
        }
    }
}
