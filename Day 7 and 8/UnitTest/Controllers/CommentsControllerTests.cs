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
    public class CommentsControllerTests
    {
        [Fact]
        public async Task GetCommentsForPost_ReturnsComments()
        {
            // Arrange
            var postId = 1;
            var comments = new List<Comment>
            {
                new Comment { Id = 1, PostId = postId, Content = "Comment 1" },
                new Comment { Id = 2, PostId = postId, Content = "Comment 2" }
            };

            var mockDbContext = new Mock<BlogDbContext>();
            mockDbContext.Setup(c => c.Comments).Returns(new DbSet<Comment>(comments));
            mockDbContext.Setup(c => c.Posts.FindAsync(postId)).ReturnsAsync(new Post { Id = postId });

            var controller = new CommentsController(mockDbContext.Object);

            // Act
            var result = await controller.GetCommentsForPost(postId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedComments = Assert.IsAssignableFrom<IEnumerable<Comment>>(okResult.Value);
            Assert.Equal(comments.Count, returnedComments.Count());
        }

        [Fact]
        public async Task CreateCommentForPost_CreatesComment()
        {
            // Arrange
            var postId = 1;
            var comment = new Comment { Id = 1, PostId = postId, Content = "New Comment" };
            var mockDbContext = new Mock<BlogDbContext>();
            mockDbContext.Setup(c => c.Posts.FindAsync(postId)).ReturnsAsync(new Post { Id = postId });

            var controller = new CommentsController(mockDbContext.Object);

            // Act
            var result = await controller.CreateCommentForPost(postId, comment);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedComment = Assert.IsAssignableFrom<Comment>(createdAtActionResult.Value);
            Assert.Equal(comment.Content, returnedComment.Content);
        }

        // Add more test methods for UpdateComment and DeleteComment actions

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
