using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet <Employee> Employees { get; set; }
        public DbSet <ItemModel> ItemModels { get; set; }
    }
}
