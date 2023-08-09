using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public PostsController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _context.Posts.Include(p => p.Comments).ToListAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve posts: " + ex.Message);
            }
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPost(int postId)
        {
            try
            {
                var post = await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == postId);

                if (post == null)
                    return NotFound("Post not found");

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve post: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                post.CreatedAt = DateTime.Now;
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPost), new { postId = post.Id }, post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to create post: " + ex.Message);
            }
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, Post updatedPost)
        {
            try
            {
                var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);

                if (existingPost == null)
                    return NotFound("Post not found");

                existingPost.Title = updatedPost.Title;
                existingPost.Content = updatedPost.Content;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Failed to update post: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to update post: " + ex.Message);
            }
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);

                if (post == null)
                    return NotFound("Post not found");

                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to delete post: " + ex.Message);
            }
        }

        [HttpGet("summaries")]
        public async Task<IActionResult> GetPostSummaries()
        {
            try
            {
                var posts = await _context.Posts.Select(p => new
                {
                    p.Id,
                    p.Title,
                    Summary = p.Content.Length > 100 ? p.Content.Substring(0, 100) + "..." : p.Content
                }).ToListAsync();

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve post summaries: " + ex.Message);
            }
        }

        [HttpGet("{postId}/details")]
        public async Task<IActionResult> GetPostDetails(int postId)
        {
            try
            {
                var post = await _context.Posts
                    .Include(p => p.Comments)
                    .FirstOrDefaultAsync(p => p.Id == postId);

                if (post == null)
                    return NotFound();

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve post details: " + ex.Message);
            }
        }
    }
}