﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sagdeev_kt4220.Database;

#nullable disable

namespace Sagdeev_kt4220.Migrations
{
    [DbContext(typeof(PrepodDbcontext))]
    partial class PrepodDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sagdeev_kt4220.Models.Doljnost", b =>
                {
                    b.Property<int>("DoljnostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("doljnost_id")
                        .HasComment("Идентификатор записи должности");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoljnostId"));

                    b.Property<string>("DoljnostName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_doljnost_name")
                        .HasComment("Название должности");

                    b.HasKey("DoljnostId")
                        .HasName("pk_cd_doljnost_doljnost_id");

                    b.ToTable("cd_doljnost", (string)null);
                });

            modelBuilder.Entity("Sagdeev_kt4220.Models.Kafedra", b =>
                {
                    b.Property<int>("KafedraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("kafedra_id")
                        .HasComment("Идентификатор записи кафедры");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KafedraId"));

                    b.Property<string>("KafedraName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_kafedra_name")
                        .HasComment("Название кафедры");

                    b.HasKey("KafedraId")
                        .HasName("pk_cd_kafedra_kafedra_id");

                    b.ToTable("cd_kafedra", (string)null);
                });

            modelBuilder.Entity("Sagdeev_kt4220.Models.Prepod", b =>
                {
                    b.Property<int>("PrepodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("prepod_id")
                        .HasComment("Индетификатор записи преподавателя");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrepodId"));

                    b.Property<int>("DoljnostId")
                        .HasColumnType("int")
                        .HasColumnName("doljnost_id")
                        .HasComment("Индетификатор кафедры");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<int>("KafedraId")
                        .HasColumnType("int")
                        .HasColumnName("kafedra_id")
                        .HasComment("Индетификатор кафедры");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_middlename")
                        .HasComment("Отчество преподавателя");

                    b.Property<int>("StepenId")
                        .HasColumnType("int")
                        .HasColumnName("stepen_id")
                        .HasComment("Индетификатор степени");

                    b.HasKey("PrepodId")
                        .HasName("pk_cd_prepod_prepod_id");

                    b.HasIndex("DoljnostId");

                    b.HasIndex("KafedraId");

                    b.HasIndex(new[] { "StepenId" }, "idx_cd_prepod_fk_f_stepen_id");

                    b.ToTable("cd_prepod", (string)null);
                });

            modelBuilder.Entity("Sagdeev_kt4220.Models.Stepen", b =>
                {
                    b.Property<int>("StepenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("stepen_id")
                        .HasComment("Идентификатор записи степени");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StepenId"));

                    b.Property<string>("StepenName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_stepen_name")
                        .HasComment("Название степени");

                    b.HasKey("StepenId")
                        .HasName("pk_cd_stepen_stepen_id");

                    b.ToTable("cd_stepen", (string)null);
                });

            modelBuilder.Entity("Sagdeev_kt4220.Models.Prepod", b =>
                {
                    b.HasOne("Sagdeev_kt4220.Models.Doljnost", "Doljnost")
                        .WithMany()
                        .HasForeignKey("DoljnostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_doljnost_id");

                    b.HasOne("Sagdeev_kt4220.Models.Kafedra", "Kafedra")
                        .WithMany()
                        .HasForeignKey("KafedraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_kafedra_id");

                    b.HasOne("Sagdeev_kt4220.Models.Stepen", "Stepen")
                        .WithMany()
                        .HasForeignKey("StepenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_stepen_id");

                    b.Navigation("Doljnost");

                    b.Navigation("Kafedra");

                    b.Navigation("Stepen");
                });
#pragma warning restore 612, 618
        }
    }
}
