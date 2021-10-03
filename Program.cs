using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Z.EntityFramework.Extensions;
using Npgsql;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NestedJsonTestPomelo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Host=localhost;Database=Blogs;Username=postgres;Password=root;";
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseNpgsql(connectionString, options => 
            {

            });

            var context = new BlogContext(optionsBuilder.Options);

            context.Database.Migrate();

            var blogRegularAdd = new Blog
            {
                BlogId = Guid.NewGuid().ToString(),
                InsertionTime = DateTime.UtcNow
            };

            context.Add(blogRegularAdd);
            context.SaveChanges();

            var blogBulk = new Blog
            {
                BlogId = Guid.NewGuid().ToString(),
                InsertionTime = DateTime.UtcNow
            };

            context.BulkInsert(new List<Blog> { blogBulk });
           
        }
    }
}
