using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Controllers;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BlogApp.Tests.Controllers
{
    public class PostsControllerTests
    {
        [Fact]
        public async Task GetPosts_ReturnsPosts()
        {
            // Arrange
            var posts = new List<Post>
            {
                new Post { Id = 1, Title = "Post 1" },
                new Post { Id = 2, Title = "Post 2" }
            };

            var mockDbContext = new Mock<BlogDbContext>();
            mockDbContext.Setup(c => c.Posts.Include(p => p.Comments)).Returns(posts.AsQueryable().Include(p => p.Comments));

            var controller = new PostsController(mockDbContext.Object);

            // Act
            var result = await controller.GetPosts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPosts = Assert.IsAssignableFrom<IEnumerable<Post>>(okResult.Value);
            Assert.Equal(posts.Count, returnedPosts.Count());
        }

        [Fact]
        public async Task CreatePost_CreatesPost()
        {
            // Arrange
            var post = new Post { Id = 1, Title = "New Post" };
            var mockDbContext = new Mock<BlogDbContext>();

            var controller = new PostsController(mockDbContext.Object);

            // Act
            var result = await controller.CreatePost(post);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedPost = Assert.IsAssignableFrom<Post>(createdAtActionResult.Value);
            Assert.Equal(post.Title, returnedPost.Title);
        }

        // Add more test methods for UpdatePost, DeletePost, GetPost, and other actions

        private IQueryable<T> GetQueryableMockDbSet<T>(List<T> data) where T : class
        {
            var queryableData = data.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryableData.GetEnumerator());
            return mockDbSet.Object;
        }
    }
}
