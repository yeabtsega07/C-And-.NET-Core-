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
    [Route("api/posts/{postId}/comments")]
    public class CommentsController : ControllerBase
    {   
        // The database context
        private readonly BlogDbContext _context;

        // Constructor
        public CommentsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/posts/{postId}/comments
        [HttpGet]
        public async Task<IActionResult> GetCommentsForPost(int postId)
        {
            try
            {
                var post = await _context.Posts.FindAsync(postId);

                if (post == null)
                    return NotFound("Post not found");

                var comments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve comments: " + ex.Message);
            }
        }

        // GET: api/posts/{postId}/comments/{commentId}
        [HttpPost]
        public async Task<IActionResult> CreateCommentForPost(int postId, Comment comment)
        {
            try
            {
                var post = await _context.Posts.FindAsync(postId);

                if (post == null)
                    return NotFound("Post not found");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                comment.CreatedAt = DateTime.Now;
                comment.PostId = postId;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCommentsForPost), new { postId }, comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to create comment: " + ex.Message);
            }
        }

        // PUT: api/posts/{postId}/comments/{commentId}

        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateComment(int postId, int commentId, Comment updatedComment)
        {
            try
            {
                var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId && c.PostId == postId);

                if (existingComment == null)
                    return NotFound("Comment not found");

                existingComment.Content = updatedComment.Content;
                await _context.SaveChangesAsync();
                return NoContent();
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

        // DELETE: api/posts/{postId}/comments/{commentId}

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int postId, int commentId)
        {
            try
            {
                var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId && c.PostId == postId);

                if (comment == null)
                    return NotFound("Comment not found");

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to delete comment: " + ex.Message);
            }
        }
    }
}