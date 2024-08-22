using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AppData.Context
{
    public class TStoreDb : DbContext
    {
        public TStoreDb()
        {
            
        }

        public TStoreDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
		public DbSet<BillDetail> BillDetails { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<CartDetail> CartDetails { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Models.Color> Colors { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<Producer> Producers { get; set; }
		public DbSet<ProductCatergory> ProductCatergories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductDetail> ProductDetails { get; set; }
		public DbSet<Models.Size> Sizes { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Voucher> Vouchers { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseSqlServer(@"Data Source=HuyKhoiTUF\SQLEXPRESS;Initial Catalog=DB_DATN_TStore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }


}
