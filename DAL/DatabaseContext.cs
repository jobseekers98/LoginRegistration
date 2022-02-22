using Microsoft.EntityFrameworkCore;
using MODEL;
using System;

namespace DAL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Student> tbl_Student { get; set; }

    }
}
