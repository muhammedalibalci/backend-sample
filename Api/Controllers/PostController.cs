using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("post")]
    [ApiController]
    public class PostController:Controller
    {
        IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("list")]
        [Authorize(Roles ="Admin")]
        public  IActionResult GetList()
        {
            var result =postService.GetList();
            if (result.Success)
            {
                return  Ok(result.Data);
            }
            return  BadRequest(result.Message);
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var result = postService.Get(id);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody]Post post)
        {
            var result = postService.Add(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = postService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody]Post post)
        {
            var result = postService.Update(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }

}
