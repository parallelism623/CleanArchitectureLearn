﻿using CleanArchitecture.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Pesistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        public DbSet<AppUser> AppUsers { get; set; }    
        public DbSet<Domain.Entities.Identity.Action> Actions { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<ActionInFunction> ActionInFunctions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
