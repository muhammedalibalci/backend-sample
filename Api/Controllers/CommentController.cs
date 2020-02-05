using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("/comment")]
    public class CommentController : ControllerBase
    {
        ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("list")]
        public IActionResult GetList()
        {
            var result = commentService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var result = commentService.Get(id);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody]Comment comment)
        {
            var result = commentService.Add(comment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Comment comment)
        {            
            var result = commentService.Delete(comment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody]Comment post)
        {
            var result = commentService.Update(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
