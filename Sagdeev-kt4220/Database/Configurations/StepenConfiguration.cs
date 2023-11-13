using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sagdeev_kt4220.Database.Helpers;
using Sagdeev_kt4220.Models;

namespace Sagdeev_kt4220.Database.Configurations
{
    public class StepenConfiguration : IEntityTypeConfiguration<Stepen>
    {
        private const string TableName = "cd_stepen";

        public void Configure(EntityTypeBuilder<Stepen> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.StepenId)
                .HasName($"pk_{TableName}_stepen_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.StepenId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.StepenId)
                .HasColumnName("stepen_id")
                .HasComment("Идентификатор записи степени");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.StepenName)
                .IsRequired()
                .HasColumnName("c_stepen_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название степени");

            builder.ToTable(TableName);
        }

    }
}
