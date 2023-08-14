using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{   
    // This controller is used to manage comments for a post
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {   
        // The database context
        private readonly BlogDbContext _context;

        // Constructor
        public CommentsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/comments?postId={postId}
        [HttpGet]
        public async Task<IActionResult> GetCommentsForPost(int postId)
        {
            try
            {
                var post = await _context.Posts.FindAsync(postId);

                if (post == null)
                    return NotFound("Post not found");

                var comments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
                return Ok( new {message = "Comments retrieved successfully", comments});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve comments: " + ex.Message);
            }
        }

        // GET: api/comments
        [HttpGet("all")]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                var comments = await _context.Comments.ToListAsync();
                return Ok( new {message = "All comments retrieved successfully", comments});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve comments: " + ex.Message);
            }
        }

        // GET: api/comments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(id);

                if (comment == null)
                    return NotFound("Comment not found");

                return Ok( new {message = "Comment retrieved successfully", comment});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve comment: " + ex.Message);
            }
        }

        // POST: api/comments
        [HttpPost]
        public async Task<IActionResult> CreateCommentForPost(Comment comment)
        {
            try
            {
                var post = await _context.Posts.FindAsync(comment.PostId);

                if (post == null)
                    return NotFound("Post not found");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                comment.CreatedAt = DateTime.Now;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCommentsForPost), new { postId = comment.PostId }, comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to create comment: " + ex.Message);
            }
        }

        // PUT: api/comments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Comment updatedComment)
        {
            try
            {
                var existingComment = await _context.Comments.FindAsync(id);

                if (existingComment == null)
                    return NotFound("Comment not found");

                existingComment.Content = updatedComment.Content;
                await _context.SaveChangesAsync();
                return Ok( new {message = "Comment updated successfully", existingComment});
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Failed to update comment: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to update comment: " + ex.Message);
            }
        }

        // DELETE: api/comments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(id);

                if (comment == null)
                    return NotFound("Comment not found");

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return Ok( new {message = "Comment deleted successfully"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to delete comment: " + ex.Message);
            }
        }
    }
}