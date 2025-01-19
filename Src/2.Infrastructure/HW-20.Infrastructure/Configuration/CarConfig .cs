using HW_20.Domain.Entites.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_20.Infrastructure.Configuration
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // تنظیم کلید اصلی
            builder.HasKey(c => c.Id);

            // تنظیم نام جدول
            builder.ToTable("Cars");

            // پیکربندی شماره پلاک (Number2)
            builder.Property(c => c.Number2)
                   .IsRequired()
                   .HasComment("شماره پلاک قسمت دوم خودرو");

            // پیکربندی شماره پلاک قسمت سوم (Number3)
            builder.Property(c => c.Number3)
                   .IsRequired()
                   .HasComment("شماره پلاک قسمت سوم خودرو");

            // رابطه با مدل خودرو
            builder.HasOne(c => c.Model)
                   .WithMany(c => c.Cars) // مدل خودرو می‌تواند چندین خودرو داشته باشد
                   .HasForeignKey(c => c.ModelId) //کلید خارجی مدل خودرو
                   .OnDelete(DeleteBehavior.Restrict);

            // رابطه با تولیدکننده خودرو
            builder.HasOne(c => c.Manufacturer)
                   .WithMany(c => c.Cars) // تولیدکننده می‌تواند چندین خودرو داشته باشد
                   .HasForeignKey(c => c.ManufacturerId) // کلید خارجی تولیدکننده خودرو
                   .OnDelete(DeleteBehavior.Restrict);

            // پیکربندی سال تولید خودرو
            builder.Property(c => c.ProductionYear)
                   .IsRequired()
                   .HasComment("سال تولید خودرو");

            // اضافه کردن محدودیت‌های خاص (در صورت نیاز)
            builder.Property(c => c.ProductionYear)
                   .IsRequired()
                   .HasColumnType("int"); // نوع عددی
        }
    }
}

