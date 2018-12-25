using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : IdentityDbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //查找所有FluentAPI配置
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

            //应用FluentAPI
            foreach (var type in typesToRegister)
            {
                //dynamic使C#具有弱语言的特性，在编译时不对类型进行检查

                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);

            }
        }

        public DbSet<BookStore.Models.Book> Book { get; set; }

        public DbSet<BookStore.Models.Cart> Cart { get; set; }

        public DbSet<BookStore.Models.Order> Order { get; set; }

        public DbSet<BookStore.Models.OrderBook> OrderBook { get; set; }
    }

    public class OrderBookMap : IEntityTypeConfiguration<OrderBook>
    {
        public void Configure(EntityTypeBuilder<OrderBook> builder)
        {
            builder.HasKey(t => new { t.OrderId, t.BookId });

            ///<summary>
            ///
            /// 配置Order,OrderBook的一对多关系
            /// 
            /// EFCore中,新增默认级联模式为ClientSetNull
            /// 
            /// 依赖实体的外键会被设置为空，同时删除操作不会作用到依赖的实体上，依赖实体保持不变，同下
            /// 
            /// </summary>

            //配置Order,OrderBooks的一对多关系
            builder.HasOne(t => t.Order).WithMany(p => p.OrderBooks).HasForeignKey(t => t.OrderId).OnDelete(DeleteBehavior.Cascade);

            //配置Book ,Orderbook的一对多关系
            builder.HasOne(t => t.Book).WithMany(p => p.OrderBooks).HasForeignKey(t => t.BookId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
