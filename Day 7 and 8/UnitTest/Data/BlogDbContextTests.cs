using System;
using System.Collections.Generic;
using System.Linq;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogApp.Tests.Data
{
    public class BlogDbContextTests
    {
        [Fact]
        public void DbSet_ContainsExpectedEntities()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            using (var context = new BlogDbContext(options))
            {
                // Create and add test data
                var testData = new List<Post>
                {
                    new Post { Id = 1, Title = "Test Post 1" },
                    new Post { Id = 2, Title = "Test Post 2" }
                };
                context.Posts.AddRange(testData);
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(options))
            {
                // Act
                var posts = context.Posts.ToList();

                // Assert
                Assert.Equal(2, posts.Count);
                Assert.Equal("Test Post 1", posts[0].Title);
                Assert.Equal("Test Post 2", posts[1].Title);
            }
        }


    }
}
