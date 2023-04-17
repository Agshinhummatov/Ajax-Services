using EntityFramework_Slider.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Slider.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Setting> Setting { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDelete); //bir defe yaziriq istifade edirik soft delete edirmik



            modelBuilder.Entity<Setting>()  // seeting key value tipinden bizden datalar isdeyir burdan yaziriq dusur table
           .HasData(
            new Setting
            {
                Id = 1,
                Key = "HeaderLogo",
                Value = "logo.png"
            },
            new Setting
            {
                Id = 2,
                Key = "Phone",
                Value = "35724544389953"
            },
            new Setting
            {
                Id = 3,
                Key = "Email",
                Value = "aqsin@code.edu.az"
            }
           );
        }







    }
}
