/**
 * Author: Sanya Singhal
 * Date: 01 December, 2022
 * Course: NETD 3202
 * Description: WorkersContext
 *              
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_05.Models;

namespace Assignment_05.Data
{
    public class WorkersContext : DbContext
    {
        public WorkersContext (DbContextOptions<WorkersContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment_05.Models.PieceworkWorkerModel> PieceworkWorkerModel { get; set; } = default!;
    }
}
