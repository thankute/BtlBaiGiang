﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BtlBaiGiang.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BaiGiangDBEntities : DbContext
    {
        public BaiGiangDBEntities()
            : base("name=BaiGiangDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<LectureReview> LectureReviews { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}