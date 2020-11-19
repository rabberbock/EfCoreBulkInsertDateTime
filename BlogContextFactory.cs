using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedJsonTestPomelo
{
    public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
         
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            var connectionString = "Server=localhost;Database=Blogs;User=root;Password=root;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => {
                options.UseNewtonsoftJson();
            });

            return new BlogContext(optionsBuilder.Options);
        }
    }
}
