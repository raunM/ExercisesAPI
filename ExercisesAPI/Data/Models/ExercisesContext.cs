using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExercisesAPI.Data.Models
{
    public partial class ExercisesContext : DbContext
    {
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExerciseCategory> ExerciseCategory { get; set; }
        public virtual DbSet<ExerciseTip> ExerciseTip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=RAUNAK-PC\SQLEXPRESS;Initial Catalog=Exercises;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExerciseCategory)
                    .WithMany(p => p.Exercise)
                    .HasForeignKey(d => d.ExerciseCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exercise_ExerciseCategory");
            });

            modelBuilder.Entity<ExerciseCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExerciseTip>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExerciseTip)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseTip_Exercise");
            });
        }
    }
}
