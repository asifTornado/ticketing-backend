using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Eapproval.Models;
using Eapproval.services;
using ZstdSharp.Unsafe;
using Eapproval.Helpers;
using System.Xml.Serialization;

namespace Eapproval.Controllers
{

    [ApiController]
    [Route("/")]
    public class TeamController:Controller
    {

        TeamsService _teamsService;
        HelperClass _helperClass;
        UsersService _usersService;


        public TeamController(TeamsService teamsService, HelperClass helperClass, UsersService usersService)
        {
            _teamsService = teamsService;
            _helperClass = helperClass;
            _usersService = usersService;
        }


        [HttpPost]
        [Route("/createTeam")]
        public async Task<IActionResult> CreateTeam(IFormCollection data)
        {
            var team = JsonSerializer.Deserialize<Team>(data["team"]);
            if(team.HasServices == true)
            {
                foreach(var x in team.Services)
                {
                    x.ServiceLeader.UserType = "leader";
                    await _usersService.UpdateAsync(x.ServiceLeader.Id, x.ServiceLeader);

                    foreach(var y in x.Subordinates)
                    {
                        y.User.UserType = "support";
                        await _usersService.UpdateAsync(y.User.Id, y.User);
                    }
                    

                }
            }
            else
            {
                team.Leader.UserType = "leader";
                await _usersService.UpdateAsync(team.Leader.Id, team.Leader);
                foreach (var x in team.Subordinates)
                {
                    x.User.UserType = "support";
                    await _usersService.UpdateAsync(x.User.Id, x.User);
                }
            }
            await _teamsService.CreateTeam(team);
            return Ok(true);
        }


        [HttpPost]
        [Route("/getTeams")]
        public async Task<IActionResult> GetTeams(IFormCollection data)
        {
            
            var result = await _teamsService.GetAllTeams();
            return Ok(result);
        }



        [HttpPost]
        [Route("/getTeam")]
        public async Task<IActionResult> GetTeam(IFormCollection data)
        {
            var id = data["id"];
            var result = await _teamsService.GetTeamById(id);
            return Ok(result);
        }





        [HttpPost]
        [Route("/editTeam")]
        public async Task<IActionResult> EditTeam(IFormCollection data)
        {
            var team = JsonSerializer.Deserialize<Team>(data["team"]);


            if (team.HasServices == true)
            {
                team.Head.UserType = "departmentPower";
                await _usersService.UpdateAsync(team.Head.Id, team.Head);

                foreach (var x in team.Services)
                {
                    x.ServiceLeader.UserType = "leader";
                    await _usersService.UpdateAsync(x.ServiceLeader.Id, x.ServiceLeader);

                    foreach (var y in x.Subordinates)
                    {
                        y.User.UserType = "support";
                        await _usersService.UpdateAsync(y.User.Id, y.User);
                    }


                }
            }
            else
            {
                team.Leader.UserType = "leader";
                team.Head.UserType = "departmentPower";
                await _usersService.UpdateAsync(team.Leader.Id, team.Leader);
                await _usersService.UpdateAsync(team.Head.Id, team.Head);
                foreach (var x in team.Subordinates)
                {
                    x.User.UserType = "support";
                    await _usersService.UpdateAsync(x.User.Id, x.User);
                }
            }


             _teamsService.UpdateTeam(team.Id, team);
            return Ok(true);
        }




        [HttpPost]
        [Route("/deleteTeam")]
        public async Task<IActionResult> DeleteTeam(IFormCollection data)
        {
            var team = JsonSerializer.Deserialize<Team>(data["team"]);
            var id = team.Id;
            _teamsService.RemoveTeam(team.Id);
            return Ok(id);
        }



        [HttpPost]
        [Route("/updateRanks")]
        public async Task<IActionResult> UpdateRanks(IFormCollection data)
        {
            var team = JsonSerializer.Deserialize<Team>(data["team"]);
            var teams = await _teamsService.GetAllTeams();


           if(team.HasServices == true)
            {
                foreach (var x in team.Services) {
                    var leader = x.ServiceLeader;

                    var result = teams.Find((team) =>
                    {
                        bool outerResult;
                        if (team.HasServices == true)
                        {
                            var innerResult = team.Services.Any((service) => service.ServiceLeader.MailAddress == leader.MailAddress);
                            outerResult = innerResult;
                        }
                        else
                        {
                            var innerResult = team.Leader.MailAddress == leader.MailAddress;
                            outerResult = innerResult;
                        }

                        return outerResult;
                    });

                    if(result == null)
                    {
                        var newResult = teams.Find((team) =>
                        {
                            bool outerResult;
                            if (team.HasServices == true)
                            {
                                var innerResult = team.Services.Any((service) => service.Subordinates.Any((subordinate) => subordinate.User.MailAddress == leader.MailAddress));
                                outerResult = innerResult;
                            }
                            else
                            {
                                var innerResult = team.Subordinates.Any((subordinate) => subordinate.User.MailAddress == leader.MailAddress);
                                outerResult = innerResult;
                            }

                            return outerResult;
                        });

                        if(newResult == null)
                        {
                            leader.UserType = "normal";
                            await _usersService.UpdateAsync(leader.Id, leader);
                        }
                        else
                        {
                            await _usersService.UpdateAsync(leader.Id, leader);
                        }

                    }

                }
            }
            else
            {
                var leader = team.Leader;


                var result = teams.Find((team) =>
                {
                    bool outerResult;
                    if (team.HasServices == true)
                    {
                        var innerResult = team.Services.Any((service) => service.ServiceLeader.MailAddress == leader.MailAddress);
                        outerResult = innerResult;
                    }
                    else
                    {
                        var innerResult = team.Leader.MailAddress == leader.MailAddress;
                        outerResult = innerResult;
                    }

                    return outerResult;
                });

                if (result == null)
                {
                    var newResult = teams.Find((team) =>
                    {
                        bool outerResult;
                        if (team.HasServices == true)
                        {
                            var innerResult = team.Services.Any((service) => service.Subordinates.Any((subordinate) => subordinate.User.MailAddress == leader.MailAddress));
                            outerResult = innerResult;
                        }
                        else
                        {
                            var innerResult = team.Subordinates.Any((subordinate) => subordinate.User.MailAddress == leader.MailAddress);
                            outerResult = innerResult;
                        }

                        return outerResult;
                    });

                    if (newResult == null)
                    {
                        leader.UserType = "normal";
                        await _usersService.UpdateAsync(leader.Id, leader);
                    }
                    else
                    {
                        await _usersService.UpdateAsync(leader.Id, leader);
                    }

                }



            }



            //////////////////////////////////////

            if(team.HasServices == true)
            {
                foreach (var x in team.Services)
                {
                    foreach (var y in x.Subordinates)
                    {
                        var user = y.User;

                        var result = teams.Find((team) =>
                        {
                            bool result;
                            if(team.HasServices == true)
                            {
                                var outerResult = team.Services.Any((service) =>
                                {
                                    var innerResult = service.Subordinates.Any((subordinate) => subordinate.User.MailAddress == user.MailAddress);
                                    return innerResult;
                                });

                                 result = outerResult;
                            }
                            else
                            {
                                var outerResult = team.Subordinates.Any((subordinate) => subordinate.User.MailAddress == user.MailAddress);
                                result = outerResult;
                            }
                            return result;
                        });

                        if(result == null) {

                            user.UserType = "normal";
                            await _usersService.UpdateAsync(user.Id, user);



                        }
                    }
                }
            }
            else
            {
                foreach(var x in team.Subordinates)
                {
                    var user = x.User;

                    var result = teams.Find((team) =>
                    {
                        bool result;
                        if (team.HasServices == true)
                        {
                            var outerResult = team.Services.Any((service) =>
                            {
                                var innerResult = service.Subordinates.Any((subordinate) => subordinate.User.MailAddress == user.MailAddress);
                                return innerResult;
                            });

                            result = outerResult;
                        }
                        else
                        {
                            var outerResult = team.Subordinates.Any((subordinate) => subordinate.User.MailAddress == user.MailAddress);
                            result = outerResult;
                        }
                        return result;
                    });

                    if (result == null)
                    {

                        user.UserType = "normal";
                        await _usersService.UpdateAsync(user.Id, user);



                    }
                }
            };


            return Ok(true);

        }




        [HttpPost]
        [Route("/getSupport")]
        public async Task<IActionResult> GetSupport(IFormCollection data)
        {
            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);

            var result = await _helperClass.GetSupport(ticket);
            return Ok(result);
        }

        [HttpPost]
        [Route("/getSupportFromHead")]
        public async Task<IActionResult> GetSupportFromHead(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);

            var result = await _teamsService.GetSupportFromHead(user);
            return Ok(result);
        }



        [HttpPost]
        [Route("/demoteTemporaryLeader")]
        public async Task<IActionResult> DemoteTemporaryLeader(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            user.UserType = "support";

             await _usersService.UpdateAsync(user.Id, user);
            return Ok(true);
        }





    }
}
