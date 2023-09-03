using Eapproval.Helpers;
using Eapproval.Models;
using Eapproval.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eapproval.Controllers
{
    [Route("/")]
    [ApiController]
    public class ChatController : Controller
    {

        ChatService _chatService;
        FileHandler _fileHandler;
        public ChatController(ChatService chatService, FileHandler fileHandler) 
        {
            _chatService = chatService;

            _fileHandler = fileHandler;

        
        }



        [HttpPost]
        [Route("/getChat")]
        public async Task<IActionResult> GetChats(IFormCollection data)
        {
            var id = data["id"];    
            var result = await _chatService.getChat(id);
            return Ok(result);
        }




        [HttpPost]
        [Route("/uploadFiles")]
        public async Task<IActionResult> UploadFiles(IFormCollection data)
        {
            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", "uploads")); ;

            var fileNames = new List<File2>();
                foreach (var file in data.Files)
                {
                    var newName = _fileHandler.GetUniqueFileName(file.FileName);
                    _fileHandler.SaveFile(path, newName, file);

                    fileNames.Add(new File2 { OriginalName = file.FileName, FileName = newName });


                }

                

                return Ok(fileNames);

            
         
        }

    }
}
