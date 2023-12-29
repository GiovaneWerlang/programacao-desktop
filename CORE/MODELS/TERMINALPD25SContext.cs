using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace CORE.MODELS
{
    public partial class TERMINALPD25SContext : DbContext
    {
        private string _dbConnectionString;

        public TERMINALPD25SContext()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
#if DEBUG
            _dbConnectionString = configuration.GetConnectionString("BDLocal");
#endif
        }

        public TERMINALPD25SContext(DbContextOptions<TERMINALPD25SContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conta> Contas { get; set; }
        public virtual DbSet<Correntista> Correntistas { get; set; }
        public virtual DbSet<Lançamento> Lançamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(_dbConnectionString);

                //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TERMINALPD25S;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.Property(e => e.DataAbertura).HasColumnType("date");

                entity.Property(e => e.LimiteCredito).HasColumnType("money");

                entity.Property(e => e.Saldo).HasColumnType("money");

                entity.HasOne(d => d.Correntista)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.CorrentistaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CORRENTISTA_CONTA");
            });

            modelBuilder.Entity<Correntista>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lançamento>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Historico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.HasOne(d => d.Conta)
                    .WithMany(p => p.Lançamentos)
                    .HasForeignKey(d => d.ContaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTA_LANCAMENTO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
