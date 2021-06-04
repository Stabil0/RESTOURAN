using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace restouran.Models
{
    public partial class restContext : DbContext
    {
        public restContext()
        {
        }

        public restContext(DbContextOptions<restContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=InsuranceCompany.db; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode);

                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_code");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("VARCHAR (20)");

                entity.Property(e => e.Old).HasColumnType("INT");

                entity.Property(e => e.PassportData)
                    .IsRequired()
                    .HasColumnType("VARCHAR (100)")
                    .HasColumnName("Passport_data");

                entity.Property(e => e.Phone).HasColumnType("INT");

                entity.Property(e => e.PositionId)
                    .HasColumnType("INT")
                    .HasColumnName("Position_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.DishCode);

                entity.ToTable("Menu");

                entity.Property(e => e.DishCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Dish_code");

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("Dish_name");

                entity.Property(e => e.IngredientCode1)
                    .HasColumnType("INT")
                    .HasColumnName("Ingredient_code_1");

                entity.Property(e => e.IngredientCode2)
                    .HasColumnType("INT")
                    .HasColumnName("Ingredient_code_2");

                entity.Property(e => e.IngredientCode3)
                    .HasColumnType("INT")
                    .HasColumnName("Ingredient_code_3");

                entity.Property(e => e.TimeForPreparing)
                    .IsRequired()
                    .HasColumnType("DateTime")
                    .HasColumnName("Time_for_preparing");

                entity.Property(e => e.Volume1)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("Volume_1");

                entity.Property(e => e.Volume2)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("Volume_2");

                entity.Property(e => e.Volume3)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("Volume_3");

                entity.HasOne(d => d.IngredientCode1Navigation)
                    .WithMany(p => p.MenuIngredientCode1Navigations)
                    .HasForeignKey(d => d.IngredientCode1)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IngredientCode2Navigation)
                    .WithMany(p => p.MenuIngredientCode2Navigations)
                    .HasForeignKey(d => d.IngredientCode2)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IngredientCode3Navigation)
                    .WithMany(p => p.MenuIngredientCode3Navigations)
                    .HasForeignKey(d => d.IngredientCode3)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.CustomersName);

                entity.ToTable("Order");

                entity.Property(e => e.Check)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)");

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .HasColumnName("Customer_id");

                entity.Property(e => e.CustomersName)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("customers_name");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.DishCode1)
                    .HasColumnType("INT")
                    .HasColumnName("Dish_code_1");

                entity.Property(e => e.DishCode2)
                    .HasColumnType("INT")
                    .HasColumnName("Dish_code_2");

                entity.Property(e => e.DishCode3)
                    .HasColumnType("INT")
                    .HasColumnName("Dish_code_3");

                entity.Property(e => e.Phone).HasColumnType("INT");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnType("DateTime");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DishCode1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.DishCode1)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DishCode2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.DishCode2)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DishCode3Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.DishCode3)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Position_id");

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("job_name");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("VARCHAR (100)");

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasColumnType("VARCHAR (100)");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.IngredientCode);

                entity.ToTable("Warehouse");

                entity.Property(e => e.IngredientCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Ingredient_code");

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("DateTime");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)")
                    .HasColumnName("Ingredient_Name");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)");

                entity.Property(e => e.ShelfLife)
                    .IsRequired()
                    .HasColumnType("DateTime")
                    .HasColumnName("Shelf_life");

                entity.Property(e => e.Volume)
                    .IsRequired()
                    .HasColumnType("VARCHAR (50)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
