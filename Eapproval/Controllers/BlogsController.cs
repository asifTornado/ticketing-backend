using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eapproval.Services;
using Eapproval.services;
using Eapproval.Models;

using System.Text.Json;
using MongoDB.Driver;

namespace Eapproval.Controllers
{
    [Route("/")]
    [ApiController]
    public class BlogsController : Controller
   {
        private BlogsService _blogsService;
        private JwtTokenService _jwtTokenService;
        public BlogsController(BlogsService blogsService, JwtTokenService jwtTokenService)
        {
            _blogsService = blogsService;
            _jwtTokenService = jwtTokenService;
        
        }





        [HttpPost]
        [Route("getBlog")]
        public async Task<IActionResult> GetBlog(IFormCollection data)
        {
            var id = data["id"]; 
            var result = await _blogsService.GetBlog(id);
            return Ok(result);
        }


        [HttpPost]
        [Route("getAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _blogsService.GetAllBlogs();
            return Ok(result);
        }



        [HttpPost]
        [Route("getFilteredBlogs")]
        public async Task<IActionResult> GetFilteredBlogs(IFormCollection data)
        {

            
            List<Blogs> result;
            if (data["search"] == "" || data["search"] == " ")
            {
                result = await _blogsService.GetAllBlogs();
            }
            else
            {
                result = await _blogsService.GetFilteredBlogs(data["search"]);
            }


            return Ok(result);
        }


        [HttpPost]
        [Route("getBlogsForUser")]
        public async Task<IActionResult> GetBlogsForUser(IFormCollection data)
        {
            var user = _jwtTokenService.ParseToken(data["token"]);

            var result = await _blogsService.GetBlogsForUser(user);
            return Ok(result);
        }


        [HttpPost]
        [Route("getFilteredBlogsForUser")]
        public async Task<IActionResult> GetFilteredBlogsForUser(IFormCollection data)
        {

            var user = _jwtTokenService.ParseToken(data["token"]);
            List<Blogs> result;
            if (data["search"] == "" || data["search"] == " ")
            {
                result = await _blogsService.GetBlogsForUser(user);
            }
            else
            {
                result = await _blogsService.GetFilteredBlogsForUser(data["search"], user);
            }
            

            return Ok(result);
        }


        [HttpPost]
        [Route("createBlog")]
        public async Task<IActionResult> CreateBlog(IFormCollection data)
        {
            User user = _jwtTokenService.ParseToken(data["token"]);
            string content = data["content"];
            string headline = data["headline"];

            Blogs blog = new Blogs()
            {
                Authors = user,
                Content = content,
                Headline = headline
            };

       

            await _blogsService.InsertBlog(blog);
            return Ok(true);

        }



        [HttpPost]
        [Route("editBlog")]
        public async Task<IActionResult> EditBlog(IFormCollection data)
        {
         
            Blogs blog = JsonSerializer.Deserialize<Blogs>(data["blog"]);



            await _blogsService.EditBlog(blog);
            return Ok(blog);

        }



        [HttpPost]
        [Route("deleteArticle")]
        public async Task<IActionResult> DeleteBlog(IFormCollection data)
        {

            var id = data["id"];



            await _blogsService.DeleteBlog(id);
            return Ok(true);

        }



    }
}
