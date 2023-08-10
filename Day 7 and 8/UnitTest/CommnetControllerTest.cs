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
    public class CommentControllerTests : IDisposable
    {
        private readonly BlogDbContext _dbContext;
        private readonly CommentsController _commentsController;

        public CommentControllerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<BlogDbContext>(options => options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();

            _dbContext = serviceProvider.GetRequiredService<BlogDbContext>();
            _commentsController = new CommentsController(_dbContext);
        }

        [Fact]
        public async Task Test_CreateCommentForPost()
        {
            // Arrange
            var post = new Post { Title = "Test Post", Content = "This is a test post." };
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            var newComment = new Comment { Content = "Test Comment", PostId = post.Id };

            // Act
            var createResult = await _commentsController.CreateCommentForPost(post.Id, newComment) as CreatedAtActionResult;
            var createdComment = createResult.Value as Comment;

            // Assert
            Assert.Equal(201, createResult.StatusCode);
            Assert.Equal(newComment.Content, createdComment.Content);
            Assert.Equal(post.Id, createdComment.PostId);
        }

        [Fact]
        public async Task Test_GetCommentsForPost()

        {
            // Arrange
            var post = new Post { Title = "Test Post", Content = "This is a test post." };
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            var comments = new List<Comment>
            {
                new Comment { Content = "Comment 1", PostId = post.Id },
                new Comment { Content = "Comment 2", PostId = post.Id }
            };
            await _dbContext.Comments.AddRangeAsync(comments);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _commentsController.GetCommentsForPost(post.Id) as OkObjectResult;
            var retrievedComments = result.Value as List<Comment>;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(comments.Count, retrievedComments.Count);
        }

        [Fact]
        public async Task Test_UpdateComment()
        {
            // Arrange
            var post = new Post { Title = "Test Post", Content = "This is a test post." };
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            var commentToUpdate = new Comment { Content = "Original Comment", PostId = post.Id };
            await _dbContext.Comments.AddAsync(commentToUpdate);
            await _dbContext.SaveChangesAsync();

            var updatedComment = new Comment { Content = "Updated Comment", PostId = post.Id };

            // Act
            var updateResult = await _commentsController.UpdateComment(post.Id, commentToUpdate.Id, updatedComment) as NoContentResult;

            // Assert
            Assert.Equal(204, updateResult.StatusCode);

            var retrievedComment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == commentToUpdate.Id);
            Assert.Equal(updatedComment.Content, retrievedComment.Content);
        }

        [Fact]
        public async Task Test_DeleteComment()
        {
            // Arrange
            var post = new Post { Title = "Test Post", Content = "This is a test post." };
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            var commentToDelete = new Comment { Content = "Comment to Delete", PostId = post.Id };
            await _dbContext.Comments.AddAsync(commentToDelete);
            await _dbContext.SaveChangesAsync();

            // Act
            var deleteResult = await _commentsController.DeleteComment(post.Id, commentToDelete.Id) as NoContentResult;

            // Assert
            Assert.Equal(204, deleteResult.StatusCode);

            var deletedComment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == commentToDelete.Id);
            Assert.Null(deletedComment);
        }

        // Add more tests for CommentsController...

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
