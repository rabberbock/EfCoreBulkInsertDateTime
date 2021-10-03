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
            var connectionString = "Host=localhost;Database=Blogs;Username=postgres;Password=root;";
            optionsBuilder.UseNpgsql(connectionString,  options => {
                
            });

            return new BlogContext(optionsBuilder.Options);
        }
    }
}
