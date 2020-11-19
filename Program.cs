using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace NestedJsonTestPomelo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=Blogs;User=root;Password=root;";
            //var serverVersion = ServerVersion.AutoDetect(connectionString);
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseMySql(connectionString, options => 
            {
                options.UseNewtonsoftJson();
            });

            var context = new BlogContext(optionsBuilder.Options);

            context.Database.EnsureCreated();
            context.Database.Migrate();

            var blog = new Blog
            {
                BlogId = Guid.NewGuid().ToString(),
                Metadata = JObject.Parse(JsonConvert.SerializeObject(new 
                {
                    title = "My new Blog"
                }))
            };

            context.Add(blog);
            context.SaveChanges();

            var blogInDb = context.Blogs.Where(b => b.Metadata["title"].Value<string>() == "My new Blog").FirstOrDefault();
            Console.WriteLine(JsonConvert.SerializeObject(blogInDb));
        }
    }
}
