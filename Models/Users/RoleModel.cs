using System;
using Microsoft.EntityFrameworkCore;

namespace Mummies.Models.Users
{
	public class RoleModel
	{
        public RoleModel()
        {
        }

        //public RoleModel(DbContextOptions<UsersDbContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Analysis> Analyses { get; set; }

        public virtual DbSet<AnalysisTextile> AnalysisTextiles { get; set; }
    }
}

