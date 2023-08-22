using Microsoft.AspNetCore.Mvc;
using Eapproval.Models;
using Eapproval.services;

using System.Text.Json;
using Eapproval.Helpers;
using Eapproval.Services;

namespace Eapproval.Controllers
{
    [Route("/")]
    [ApiController]
    public class MainController : Controller
    {
        UsersService _usersService;
        UserApi _usersApi;
        LocationService _locationService;

        public MainController(UsersService usersService, UserApi userApi, LocationService locationService)
        {
            _locationService = locationService;
            _usersService = usersService;
            _usersApi = userApi;
        }




        [HttpPost]
        [Route("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersService.GetAllNormalUsers();
            return Ok(users);
            
        }


        [HttpGet]
        [Route("getLocations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _locationService.GetAllLocations();
            return Ok(locations);

        }


        [HttpPost]
        [Route("addLocation")]
        public async Task<IActionResult> addLocation(IFormCollection data)
        {
            var newLocation = new Location
            {
                Name = data["name"],
            };

             await _locationService.AddLocation(newLocation);
            return Ok(true);

        }


        [HttpPost]
        [Route("deleteLocation")]
        public async Task<IActionResult> DeleteLocation(IFormCollection data)
        {


            await _locationService.DeleteLocation(data["id"]);
            return Ok(true);

        }

        [HttpPost]
        [Route("deleteUser")]
        public async Task<IActionResult> DeleteUser(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            await _usersService.RemoveAsync(user.Id);
            return Ok(true);

        }


        [HttpPost]
        [Route("getUsersIncludingAdmin")]
        public async Task<IActionResult> GetUsersIncludingAdmin()
        {
            var users = await _usersService.GetUsersIncludingAdmin();
            return Ok(users);

        }


        [HttpPost]
        [Route("updateUserNormal")]
        public async Task<IActionResult> updateUserNormal(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            await _usersService.UpdateAsync(user.Id, user);

            return Ok(true);

        }



        [HttpGet]
        [Route("/api/getUsers")]
        public async Task<IActionResult> ApiUsers()
        {
            var results = await _usersApi.GetTeams();

            return Ok(results);

        }
    }
}
