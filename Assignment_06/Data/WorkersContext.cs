using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_06.Models;

namespace Assignment_06.Data
{
    public class WorkersContext : DbContext
    {
        public WorkersContext (DbContextOptions<WorkersContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment_06.Models.PieceworkWorkerModel> PieceworkWorkerModel { get; set; } = default!;
    }
}
