using System.Globalization;
using System.IO;
using Eapproval.Models;
using Eapproval.services;
using System.Text.Json;
using Org.BouncyCastle.Crypto.Operators;

namespace Eapproval.Helpers
{
    public class HelperClass
    {
        Dictionary<string, string> departmentHeads = new Dictionary<string, string>();
        UsersService _usersService;
        FileHandler _fileHandler;
        TeamsService _teamsService;

    

       
        public HelperClass(UsersService usersService, FileHandler fileHandler, TeamsService teamsService) {
            this._usersService = usersService;
            this._fileHandler = fileHandler;
            this._teamsService = teamsService;

            departmentHeads.Add("Administration", "Ticketing Head Admin");
            departmentHeads.Add("ERP", "Ticketing Head ERP");
            departmentHeads.Add("Information Technology", "Ticketing Head IT");


        }





        public string GetCurrentTime()
        {
            var currentDate = DateTime.Now;
            var options = new CultureInfo("en-US").DateTimeFormat;
         
            options.ShortDatePattern = "ddd, MMM d, yyyy";
            options.ShortTimePattern = "h:mm:ss tt";
            string time = currentDate.ToString("f", options);
            return time;
        }


        public async Task<List<File2>> GetFiles(IFormCollection data)
        {
            var fileNames = new List<File2>();
            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", "uploads")); ;
            if (data.Files.Count > 0)
            {

                foreach (var file in data.Files)
                {
                    var newName = _fileHandler.GetUniqueFileName(file.FileName);
                    await _fileHandler.SaveFile(path, newName, file);

                    fileNames.Add(new File2 { OriginalName = file.FileName, FileName = newName });


                }

                return fileNames;

            }

            return null;

        }


        public async Task<(User user, Tickets ticket, string comment, List<File2> fileNames, string info)> GetContent(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);
            var comment = data["comment"];
            var info = data["additionalInfo"];
            var fileNames = new List<File2>();

            Console.WriteLine("This is the comment");
            Console.WriteLine(comment);
            

            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", "uploads")); ;
            if (data.Files.Count > 0 )
            {
                
                    foreach (var file in data.Files)
                    {
                    var newName = _fileHandler.GetUniqueFileName(file.FileName);
                     _fileHandler.SaveFile(path, newName, file);

                     fileNames.Add(new File2 { OriginalName = file.FileName, FileName = newName });


                    }

            }
            else
            {
                fileNames = null;
            }
            return (user, ticket, comment, fileNames, info);
        }  


        public async Task<ActionObject> GetAction(List<ActionObject>? Actions, User raisedBy, User? forwardedTo, string comment, ActionType action, string? info = "Not Available" , List<File2> file = null)
        {
            int? serial;
            if(Actions.Count < 1) {
                serial = 1;
            }
            else
            {
            serial = Actions[Actions.Count - 1].Serial + 1;

            }
            var actionObject = new ActionObject
            {   Serial= serial,
                Time = this.GetCurrentTime(),
                Type = action,
                RaisedBy = raisedBy,
                ForwardedTo = forwardedTo,
                AdditionalInfo = info,
                Files = file,
                Comments = comment,

            };
            return actionObject;
        }

        public async Task<User?> GetTicketingHead(Tickets ticket)
        {

            string? departmentHead;
            List<SubordinatesClass>? subordinateList = new List<SubordinatesClass>();
            
            if (ticket.HasService == false)
            {
                departmentHead = ticket.Department;
            }
            else
            {
                departmentHead = ticket.ServiceType;
            }

              

                Team? result = await _teamsService.GetTeamByName(departmentHead);


             if(ticket.HasService == false)
            {
                var leader = await _usersService.GetOneUser(result.Leader.Id);

                if ( leader.Available == true)
                {
                    var user = leader;
                    return user;
                }
                else
                {
                    foreach (var x in result.Subordinates)
                    {
                        var subordinate = await _usersService.GetOneUser(x.User.Id);
                        if (subordinate.Available == true)
                        {
                            subordinateList.Add(x);
                        }
                    }

                    var sorted = subordinateList.OrderBy(x => x.Rank).ToArray();
                    var user = sorted[0].User;
                    user.UserType = "tLeader";
                    await _usersService.UpdateAsync(user.Id, user);
                    return user;
                }

            }
            else
            {
                var service = result.Services.Find(service => service.ServiceName == departmentHead);

                var serviceLeader = await _usersService.GetOneUser(service.ServiceLeader.Id);
                if (serviceLeader.Available == true)
                {
                    var user = serviceLeader;
                    return user;
                }
                else
                {
                    foreach (var x in service.Subordinates)
                    {
                        var serviceSubordinate = await _usersService.GetOneUser(x.User.Id);
                        if (serviceSubordinate.Available == true)
                        {
                            subordinateList.Add(x);
                        }
                    }

                    var sorted = subordinateList.OrderBy(x => x.Rank).ToArray();
                    var user = sorted[0].User;
                    user.UserType = "tLeader";
                    await _usersService.UpdateAsync(user.Id, user);
                    return user;
                   
                }



            }          

             
              
          
            }



        public async Task<List<SubordinatesClass?>> GetSupport(Tickets ticket)
        {

            string? departmentHead;
            List<SubordinatesClass>? subordinateList = new List<SubordinatesClass>();

            if (ticket.HasService == false)
            {
                departmentHead = ticket.Department;
            }
            else
            {
                departmentHead = ticket.ServiceType;
            }



            Team? result = await _teamsService.GetTeamByName(departmentHead);

        
            
            if (ticket.HasService == false)
            {
                return result.Subordinates.ToList();

            }
            else
            {
                var service = result.Services.Find(service => service.ServiceName == departmentHead);


                return service.Subordinates.ToList();


            }




        }

    }




    }

