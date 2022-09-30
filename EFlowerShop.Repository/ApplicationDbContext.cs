using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFlowerShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<EFlowerShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<FlowerInShoppingCart> FlowerInShoppingCarts { get; set; }
        public virtual DbSet<FlowerInOrder> FlowerInOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Flower>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
               .Property(t => t.Id)
               .ValueGeneratedOnAdd();

            //builder.Entity<FlowerInShoppingCart>()
            //    .HasKey(t => new { t.FlowerId, t.ShoppingCartId });

            builder.Entity<FlowerInShoppingCart>()
                .HasOne(t => t.Flower)
                .WithMany(t => t.FlowerInShoppingCarts)
                .HasForeignKey(t => t.FlowerId);

            builder.Entity<FlowerInShoppingCart>()
                .HasOne(t => t.ShoppingCart)
                .WithMany(t => t.FlowerInShoppingCarts)
                .HasForeignKey(t => t.ShoppingCartId);

            builder.Entity<ShoppingCart>()
                .HasOne<EFlowerShopApplicationUser>(t => t.Owner)
                .WithOne(t => t.UserCart)
                .HasForeignKey<ShoppingCart>(t => t.OwnerId);

            //builder.Entity<FlowerInOrder>()
            //    .HasKey(t => new { t.FlowerId, t.OrderId });

            builder.Entity<FlowerInOrder>()
               .HasOne(t => t.Flower)
               .WithMany(t => t.Orders)
               .HasForeignKey(t => t.FlowerId);

            builder.Entity<FlowerInOrder>()
                .HasOne(t => t.Order)
                .WithMany(t => t.FlowerInOrders)
                .HasForeignKey(t => t.OrderId);

        }
    }
}
