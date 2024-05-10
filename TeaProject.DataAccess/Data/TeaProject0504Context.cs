using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeaProject.Models;
using TeaProject.Models;
using TeaProject.Models.Models;



namespace TeaProject.DataAccess.Data;

public partial class TeaProject0504Context : IdentityDbContext<IdentityUser>
{                                       //繼承了處理身份驗證和授權所需的方法和屬性。
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

	public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ShoppingCart> ShoppingCart { get; set; }
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=Tea_project0504;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07E15D4861");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

		modelBuilder.Entity<Product>()
	   .Property(p => p.Price)
	   .HasColumnType("decimal(18,2)");

   
   

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
