using JemmaAPI.Entities.Companies;
using JemmaAPI.Entities.Customers;
using JemmaAPI.Entities.Invites;
using JemmaAPI.Entities.Items;
using JemmaAPI.Entities.OrderItems;
using JemmaAPI.Entities.Orders;
using JemmaAPI.Entities.Payments;
using JemmaAPI.Entities.Services;
using JemmaAPI.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JemmaAPI.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)

{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Invite> Invites { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}