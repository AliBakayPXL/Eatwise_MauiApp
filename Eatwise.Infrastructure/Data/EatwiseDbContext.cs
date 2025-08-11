using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Eatwise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eatwise.Infrastructure.Data
{
    public class EatwiseDbContext : DbContext
    {
        public EatwiseDbContext(DbContextOptions<EatwiseDbContext> options)
           : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<DishIngredient> DishIngredients => Set<DishIngredient>();
        public DbSet<EatenItem> EatenItems => Set<EatenItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Composite key voor de koppeltabel
            modelBuilder.Entity<DishIngredient>()
                .HasKey(x => new { x.DishId, x.IngredientId });

            //Unieke namen (voorkomt dubbels)
            modelBuilder.Entity<Ingredient>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Dish>()
                .HasIndex(x => x.Name)
                .IsUnique();

            //Decimal precisie (voorkomt rare afrondingen)
            modelBuilder.Entity<Ingredient>()
                .Property(x => x.ProteinPer100g)
                .HasColumnType("decimal (5, 2)");

            modelBuilder.Entity<Ingredient>().Property(x => x.FatPer100g).HasColumnType("decimal (5, 2)");
            modelBuilder.Entity<Ingredient>().Property(x => x.SugarPer100g).HasColumnType("decimal (5, 2)");
            modelBuilder.Entity<User>().Property(x => x.Weightkg)
                .HasColumnType("decimal (5, 2)");

            modelBuilder.Entity<DishIngredient>().Property(x => x.QuantityGrams)
                .HasColumnType("decimal (6, 1)");

            modelBuilder.Entity<EatenItem>().Property(x => x.QuantityGrams)
                .HasColumnType("decimal (6, 1)");

            //Relaties en delete gedrag
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DishIngredient>()
               .HasOne(di => di.Dish!)
               .WithMany(d => d.DishIngredients)
               .HasForeignKey(di => di.DishId)
               .OnDelete(DeleteBehavior.Cascade);

            //Seed Data
            // Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "Chicken Breast",
                    CaloriesPer100g = 165,
                    ProteinPer100g = 31.00m,
                    FatPer100g = 3.60m,
                    SugarPer100g = 0.00m
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Cooked Rice",
                    CaloriesPer100g = 130,
                    ProteinPer100g = 2.70m,
                    FatPer100g = 0.30m,
                    SugarPer100g = 0.10m
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Olive Oil",
                    CaloriesPer100g = 884,
                    ProteinPer100g = 0.00m,
                    FatPer100g = 100.00m,
                    SugarPer100g = 0.00m
                }
            );

            // Dishes
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Chicken & Rice"
                }
            );

            // DishIngredients (hoeveelheid in gram)
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1, QuantityGrams = 150.0m }, 
                new DishIngredient { DishId = 1, IngredientId = 2, QuantityGrams = 200.0m }, 
                new DishIngredient { DishId = 1, IngredientId = 3, QuantityGrams = 10.0m }   
            );
        }
    }
}
