using Sagdeev_kt4220.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sagdeev_kt4220.Models;

namespace Sagdeev_kt4220.Database.Configurations
{
    public class DoljnostConfiguration : IEntityTypeConfiguration<Doljnost>
    {
        private const string TableName = "cd_doljnost";

        public void Configure(EntityTypeBuilder<Doljnost> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.DoljnostId)
                .HasName($"pk_{TableName}_doljnost_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.DoljnostId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.DoljnostId)
                .HasColumnName("doljnost_id")
                .HasComment("Идентификатор записи должности");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.DoljnostName)
                .IsRequired()
                .HasColumnName("c_doljnost_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }
}
