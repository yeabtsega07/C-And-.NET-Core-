using System;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Controllers;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BlogApp.Tests
{
    public class PostControllerTests : IDisposable
    {
        private readonly BlogDbContext _dbContext;
        private readonly PostsController _postsController;

        public PostControllerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<BlogDbContext>(options => options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();

            _dbContext = serviceProvider.GetRequiredService<BlogDbContext>();
            _postsController = new PostsController(_dbContext);
        }

        [Fact]
        public async Task Test_CreatePost()
        {
            // Arrange
            var newPost = new Post { Title = "Test Post", Content = "This is a test post." };

            // Act
            var createResult = await _postsController.CreatePost(newPost) as CreatedAtActionResult;
            var createdPost = createResult.Value as Post;

            // Assert
            Assert.Equal(201, createResult.StatusCode);
            Assert.Equal(newPost.Title, createdPost.Title);
            Assert.Equal(newPost.Content, createdPost.Content);
        }

        [Fact]
        public async Task Test_GetPosts()
        {
            // Arrange
            var posts = new List<Post>
            {
                new Post { Title = "Post 1", Content = "Content 1" },
                new Post { Title = "Post 2", Content = "Content 2" }
            };
            await _dbContext.Posts.AddRangeAsync(posts);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _postsController.GetPosts() as OkObjectResult;
            var retrievedPosts = result.Value as List<Post>;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(posts.Count, retrievedPosts.Count);
        }

        [Fact]
        public async Task Test_UpdatePost()
        {
            // Arrange
            var originalPost = new Post { Title = "Original Post", Content = "Original Content" };
            await _dbContext.Posts.AddAsync(originalPost);
            await _dbContext.SaveChangesAsync();

            var updatedPost = new Post { Title = "Updated Post", Content = "Updated Content" };

            // Act
            var updateResult = await _postsController.UpdatePost(originalPost.Id, updatedPost) as NoContentResult;

            // Assert
            Assert.Equal(204, updateResult.StatusCode);

            var retrievedPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == originalPost.Id);
            Assert.Equal(updatedPost.Title, retrievedPost.Title);
            Assert.Equal(updatedPost.Content, retrievedPost.Content);
        }

        [Fact]
        public async Task Test_DeletePost()
        {
            // Arrange
            var postToDelete = new Post { Title = "Post to Delete", Content = "Content to Delete" };
            await _dbContext.Posts.AddAsync(postToDelete);
            await _dbContext.SaveChangesAsync();

            // Act
            var deleteResult = await _postsController.DeletePost(postToDelete.Id) as NoContentResult;

            // Assert
            Assert.Equal(204, deleteResult.StatusCode);

            var deletedPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postToDelete.Id);
            Assert.Null(deletedPost);
        }

        // Add more tests for PostsController...

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}


