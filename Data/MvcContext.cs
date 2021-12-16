using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models.Base;

namespace mvc.Data
{
    public class MvcContext : IdentityDbContext<IdentityUser>
    {
        public MvcContext(DbContextOptions<MvcContext> options)
            : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                
            }
        }
        //public DbSet<article> articles { get; set; }
        //public DbSet<feedback> feedbacks { get; set; }
        //public DbSet<savingModule> savingModules { get; set; }
        public DbSet<module> modules { get; set; }
        //public DbSet<news> news { get; set; }
        //public DbSet<optionsModule> optionsModules { get; set; }
        //public DbSet<optionsBlock> optionsBlocks { get; set; }
        public DbSet<page> pages { get; set; }
        //public DbSet<photo> photos { get; set; }
        //public DbSet<photoImg> photoimgs { get; set; }
        public DbSet<pageModule> pageModules { get; set; }
        //public DbSet<propertyTemplate> propertyTemplates { get; set; }
        //public DbSet<saveProperty> saveProperties { get; set; }
        //public DbSet<savePropertyOptionsBlock> savePropertyOptionsBlocks { get; set; }
        //public DbSet<site> sites { get; set; }
        //public DbSet<smtpOption> smtpOptions { get; set; }
        //public DbSet<template> templates { get; set; }
        //public DbSet<templatesOptionsBlock> templatesOptionsBlocks { get; set; }
        //public DbSet<userField> userFields { get; set; }
        //public DbSet<userImage> userImages { get; set; }
        //public DbSet<video> videos { get; set; }
        //public DbSet<videoList> videolists { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
