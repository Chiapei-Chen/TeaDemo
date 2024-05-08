using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeaProject.Models;


namespace TeaProject.DataAccess.Data;

public partial class TeaProject0504Context : DbContext
{
    public TeaProject0504Context()
    {
    }

    public TeaProject0504Context(DbContextOptions<TeaProject0504Context> options)
        : base(options)
    {
    }


    public virtual DbSet<Category> Categories { get; set; }
    //新增
    public  DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=Tea_project0504;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07E15D4861");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Product>().HasData(
       new Product
       {
           Id = 1,
           Name = "紅茶",
           Size = "大杯",
           Price = 30,
           Temperature = "熱飲",
           CategoryId = 1
       },
       new Product
       {
           Id = 2,
           Name = "綠茶",
           Size = "大杯",
           Price = 30,
           Temperature = "熱飲",
               CategoryId = 2
       },
       new Product
       {
           Id = 3,
           Name = "奶茶",
           Size = "大杯",
           Price = 40,
           Temperature = "熱飲",
           CategoryId = 1
       }
   );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
