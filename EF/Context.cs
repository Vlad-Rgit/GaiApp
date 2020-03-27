namespace GaiApp.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GaiApp.Models;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context4")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Auto> Autoes { get; set; }
        public virtual DbSet<AutoType> AutoTypes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Desicion> Desicions { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Infrigment> Infrigments { get; set; }
        public virtual DbSet<InfrigmentInDecision> InfrigmentInDecisions { get; set; }
        public virtual DbSet<InfrigmentKind> InfrigmentKinds { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Policeman> Policemen { get; set; }
        public virtual DbSet<PolicemenInPost> PolicemenInPosts { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Punishment> Punishments { get; set; }
        public virtual DbSet<PunishmentExecution> PunishmentExecutions { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ArticlesView> ArticlesViews { get; set; }
        public virtual DbSet<PunishmentsView> PunishmentsViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Desicions)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Infrigments)
                .WithMany(e => e.Articles)
                .Map(m => m.ToTable("InfrigmentsInArticle").MapLeftKey("ArticleCode").MapRightKey("InfrigmentId"));

            modelBuilder.Entity<Auto>()
                .HasMany(e => e.Desicions)
                .WithRequired(e => e.Auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AutoType>()
                .HasMany(e => e.Autoes)
                .WithRequired(e => e.AutoType)
                .HasForeignKey(e => new { e.MakeId, e.ModelId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Autoes)
                .WithRequired(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Desicion>()
                .HasMany(e => e.InfrigmentInDecisions)
                .WithRequired(e => e.Desicion)
                .HasForeignKey(e => e.DecisionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Desicion>()
                .HasMany(e => e.Punishments)
                .WithRequired(e => e.Desicion)
                .HasForeignKey(e => e.DecisionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.District)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.Autoes)
                .WithRequired(e => e.Driver)
                .HasForeignKey(e => e.DriverLicense)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.Desicions)
                .WithRequired(e => e.Driver)
                .HasForeignKey(e => e.DriverLicense)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Infrigment>()
                .Property(e => e.From)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Infrigment>()
                .Property(e => e.To)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Infrigment>()
                .HasMany(e => e.InfrigmentInDecisions)
                .WithRequired(e => e.Infrigment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InfrigmentInDecision>()
                .Property(e => e.Penalty)
                .HasPrecision(10, 2);

            modelBuilder.Entity<InfrigmentInDecision>()
                .HasOptional(e => e.Punishment)
                .WithRequired(e => e.InfrigmentInDecision);

            modelBuilder.Entity<Make>()
                .HasMany(e => e.AutoTypes)
                .WithRequired(e => e.Make)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.AutoTypes)
                .WithRequired(e => e.Model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Policeman>()
                .HasMany(e => e.Desicions)
                .WithRequired(e => e.Policeman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Policeman>()
                .HasMany(e => e.PolicemenInPosts)
                .WithRequired(e => e.Policeman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Policeman>()
                .HasMany(e => e.Punishments)
                .WithRequired(e => e.Policeman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PolicemenInPosts)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Punishment>()
                .HasOptional(e => e.PunishmentExecution)
                .WithRequired(e => e.Punishment);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Street)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArticlesView>()
                .Property(e => e.Минимум)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ArticlesView>()
                .Property(e => e.Максимум)
                .HasPrecision(12, 2);

            modelBuilder.Entity<PunishmentsView>()
                .Property(e => e.Размер_штрафа)
                .HasPrecision(10, 2);
        }
    }
}
