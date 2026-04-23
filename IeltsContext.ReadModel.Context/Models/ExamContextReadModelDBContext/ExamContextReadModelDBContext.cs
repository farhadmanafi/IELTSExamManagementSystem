using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ExamContextReadModelDBContext : DbContext
    {
        public ExamContextReadModelDBContext()
        {
        }

        public ExamContextReadModelDBContext(DbContextOptions<ExamContextReadModelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<AspUser> AspUsers { get; set; }
        public virtual DbSet<BankTransaction> BankTransactions { get; set; }
        public virtual DbSet<BankTransactionType> BankTransactionTypes { get; set; }
        public virtual DbSet<ExamType> ExamTypes { get; set; }
        public virtual DbSet<IeltsExam> IeltsExams { get; set; }
        public virtual DbSet<IeltsExamParticipant> IeltsExamParticipants { get; set; }
        public virtual DbSet<IeltsExamParticipantsDetail> IeltsExamParticipantsDetails { get; set; }
        public virtual DbSet<IeltsExamParticipantsStatus> IeltsExamParticipantsStatuses { get; set; }
        public virtual DbSet<IeltsExamPrice> IeltsExamPrices { get; set; }
        public virtual DbSet<IeltsResualtLevel> IeltsResualtLevels { get; set; }
        public virtual DbSet<LevelScore> LevelScores { get; set; }
        public virtual DbSet<ListeningExam> ListeningExams { get; set; }
        public virtual DbSet<ListeningExamQuestionBlock> ListeningExamQuestionBlocks { get; set; }
        public virtual DbSet<ListeningExamSection> ListeningExamSections { get; set; }
        public virtual DbSet<ListeningQuestion> ListeningQuestions { get; set; }
        public virtual DbSet<ListeningQuestionAnswer> ListeningQuestionAnswers { get; set; }
        public virtual DbSet<ListeningQuestionType> ListeningQuestionTypes { get; set; }
        public virtual DbSet<ListeningUserAnswer> ListeningUserAnswers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PlacementExam> PlacementExams { get; set; }
        public virtual DbSet<PlacementExamParticipant> PlacementExamParticipants { get; set; }
        public virtual DbSet<PlacementExamParticipantsStatus> PlacementExamParticipantsStatuses { get; set; }
        public virtual DbSet<PlacementExamPrice> PlacementExamPrices { get; set; }
        public virtual DbSet<PlacementQuestion> PlacementQuestions { get; set; }
        public virtual DbSet<PlacementQuestionAnswer> PlacementQuestionAnswers { get; set; }
        public virtual DbSet<PlacementQuestionType> PlacementQuestionTypes { get; set; }
        public virtual DbSet<PlacementUserAnswer> PlacementUserAnswers { get; set; }
        public virtual DbSet<PlacementUserScore> PlacementUserScores { get; set; }
        public virtual DbSet<ReadingExam> ReadingExams { get; set; }
        public virtual DbSet<ReadingExamQuestionBlock> ReadingExamQuestionBlocks { get; set; }
        public virtual DbSet<ReadingExamSection> ReadingExamSections { get; set; }
        public virtual DbSet<ReadingQuestion> ReadingQuestions { get; set; }
        public virtual DbSet<ReadingQuestionAnswer> ReadingQuestionAnswers { get; set; }
        public virtual DbSet<ReadingQuestionType> ReadingQuestionTypes { get; set; }
        public virtual DbSet<ReadingUserAnswer> ReadingUserAnswers { get; set; }
        public virtual DbSet<SpeakingExam> SpeakingExams { get; set; }
        public virtual DbSet<SpeakingExamMeeting> SpeakingExamMeetings { get; set; }
        public virtual DbSet<SpeakingExamMeetingReserve> SpeakingExamMeetingReserves { get; set; }
        public virtual DbSet<UserPanelMenu> UserPanelMenus { get; set; }
        public virtual DbSet<UserResualt> UserResualts { get; set; }
        public virtual DbSet<WritingExam> WritingExams { get; set; }
        public virtual DbSet<WritingExamSection> WritingExamSections { get; set; }
        public virtual DbSet<WritingUserAnswer> WritingUserAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=185.88.154.174,1430;Initial Catalog=bpvielt1_bpvieltsdb;User ID=bpvielt1_bpvieltsuser;Password=bpvieltsuser@#2022!;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bpvielt1_bpvieltsuser")
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.ToTable("AspNetRoles", "Identity");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.ToTable("AspNetRoleClaims", "Identity");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "Identity");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("AspNetUserLogins", "Identity");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("AspNetUserRoles", "Identity");

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("AspNetUserTokens", "Identity");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspUser>(entity =>
            {
                entity.ToTable("AspUser", "Identity");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Birthday).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BankTransaction>(entity =>
            {
                entity.ToTable("BankTransaction");

                entity.HasIndex(e => e.BankTransactionTypeId, "IX_BankTransaction_BankTransactionTypeId");

                entity.HasIndex(e => e.ExamTypeId, "IX_BankTransaction_ExamTypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BankName).IsRequired();

                entity.Property(e => e.BankTransactionCode).IsRequired();

                entity.Property(e => e.CustomerAccountNumber).IsRequired();

                entity.HasOne(d => d.BankTransactionType)
                    .WithMany(p => p.BankTransactions)
                    .HasForeignKey(d => d.BankTransactionTypeId);

                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.BankTransactions)
                    .HasForeignKey(d => d.ExamTypeId);
            });

            modelBuilder.Entity<BankTransactionType>(entity =>
            {
                entity.ToTable("BankTransactionType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                entity.ToTable("ExamType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<IeltsExam>(entity =>
            {
                entity.ToTable("IeltsExam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<IeltsExamParticipant>(entity =>
            {
                entity.HasIndex(e => e.IeltsExamParticipantsStatusId, "IX_IeltsExamParticipants_IeltsExamParticipantsStatusId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.IeltsExamParticipantsStatus)
                    .WithMany(p => p.IeltsExamParticipants)
                    .HasForeignKey(d => d.IeltsExamParticipantsStatusId);
            });

            modelBuilder.Entity<IeltsExamParticipantsDetail>(entity =>
            {
                entity.ToTable("IeltsExamParticipantsDetail");

                entity.HasIndex(e => e.IeltsExamParticipantsId, "IX_IeltsExamParticipantsDetail_IeltsExamParticipantsId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IeltsExamParticipants)
                    .WithMany(p => p.IeltsExamParticipantsDetails)
                    .HasForeignKey(d => d.IeltsExamParticipantsId);
            });

            modelBuilder.Entity<IeltsExamParticipantsStatus>(entity =>
            {
                entity.ToTable("IeltsExamParticipantsStatus");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<IeltsExamPrice>(entity =>
            {
                entity.ToTable("IeltsExamPrice");

                entity.HasIndex(e => e.IeltsExamId, "IX_IeltsExamPrice_IeltsExamId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IeltsExam)
                    .WithMany(p => p.IeltsExamPrices)
                    .HasForeignKey(d => d.IeltsExamId);
            });

            modelBuilder.Entity<IeltsResualtLevel>(entity =>
            {
                entity.ToTable("IeltsResualtLevel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<LevelScore>(entity =>
            {
                entity.ToTable("LevelScore");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.LevelName).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ListeningExam>(entity =>
            {
                entity.ToTable("ListeningExam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ListeningExamQuestionBlock>(entity =>
            {
                entity.ToTable("ListeningExamQuestionBlock");

                entity.HasIndex(e => e.ListeningExamSectionId, "IX_ListeningExamQuestionBlock_ListeningExamSectionId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ListeningExamSection)
                    .WithMany(p => p.ListeningExamQuestionBlocks)
                    .HasForeignKey(d => d.ListeningExamSectionId);
            });

            modelBuilder.Entity<ListeningExamSection>(entity =>
            {
                entity.ToTable("ListeningExamSection");

                entity.HasIndex(e => e.ListeningExamId, "IX_ListeningExamSection_ListeningExamId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ListeningExam)
                    .WithMany(p => p.ListeningExamSections)
                    .HasForeignKey(d => d.ListeningExamId);
            });

            modelBuilder.Entity<ListeningQuestion>(entity =>
            {
                entity.ToTable("ListeningQuestion");

                entity.HasIndex(e => e.ListeningQuestionTypeId, "IX_ListeningQuestion_ListeningQuestionTypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ListeningQuestionType)
                    .WithMany(p => p.ListeningQuestions)
                    .HasForeignKey(d => d.ListeningQuestionTypeId);
            });

            modelBuilder.Entity<ListeningQuestionAnswer>(entity =>
            {
                entity.HasIndex(e => e.ListeningQuestionId, "IX_ListeningQuestionAnswers_ListeningQuestionId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsCorrect)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ListeningQuestion)
                    .WithMany(p => p.ListeningQuestionAnswers)
                    .HasForeignKey(d => d.ListeningQuestionId);
            });

            modelBuilder.Entity<ListeningQuestionType>(entity =>
            {
                entity.ToTable("ListeningQuestionType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ListeningUserAnswer>(entity =>
            {
                entity.ToTable("ListeningUserAnswer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Icon).IsRequired();

                entity.Property(e => e.PageName).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<PlacementExam>(entity =>
            {
                entity.ToTable("PlacementExam");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<PlacementExamParticipant>(entity =>
            {
                entity.HasIndex(e => e.PlacementExamParticipantsStatusId, "IX_PlacementExamParticipants_PlacementExamParticipantsStatusId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.PlacementExamParticipantsStatus)
                    .WithMany(p => p.PlacementExamParticipants)
                    .HasForeignKey(d => d.PlacementExamParticipantsStatusId);
            });

            modelBuilder.Entity<PlacementExamParticipantsStatus>(entity =>
            {
                entity.ToTable("PlacementExamParticipantsStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<PlacementExamPrice>(entity =>
            {
                entity.ToTable("PlacementExamPrice");

                entity.HasIndex(e => e.PlacementExamId, "IX_PlacementExamPrice_PlacementExamId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.PlacementExam)
                    .WithMany(p => p.PlacementExamPrices)
                    .HasForeignKey(d => d.PlacementExamId);
            });

            modelBuilder.Entity<PlacementQuestion>(entity =>
            {
                entity.ToTable("PlacementQuestion");

                entity.HasIndex(e => e.PlacementQuestionTypeId, "IX_PlacementQuestion_PlacementQuestionTypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.PlacementQuestionType)
                    .WithMany(p => p.PlacementQuestions)
                    .HasForeignKey(d => d.PlacementQuestionTypeId);
            });

            modelBuilder.Entity<PlacementQuestionAnswer>(entity =>
            {
                entity.HasIndex(e => e.PlacementQuestionId, "IX_PlacementQuestionAnswers_PlacementQuestionId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsCorrect)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.PlacementQuestion)
                    .WithMany(p => p.PlacementQuestionAnswers)
                    .HasForeignKey(d => d.PlacementQuestionId);
            });

            modelBuilder.Entity<PlacementQuestionType>(entity =>
            {
                entity.ToTable("PlacementQuestionType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CodeName).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<PlacementUserAnswer>(entity =>
            {
                entity.ToTable("PlacementUserAnswer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<PlacementUserScore>(entity =>
            {
                entity.ToTable("PlacementUserScore");

                entity.HasIndex(e => e.LevelScoreId, "IX_PlacementUserScore_LevelScoreId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.LevelScore)
                    .WithMany(p => p.PlacementUserScores)
                    .HasForeignKey(d => d.LevelScoreId);
            });

            modelBuilder.Entity<ReadingExam>(entity =>
            {
                entity.ToTable("ReadingExam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ReadingExamQuestionBlock>(entity =>
            {
                entity.ToTable("ReadingExamQuestionBlock");

                entity.HasIndex(e => e.ReadingExamSectionId, "IX_ReadingExamQuestionBlock_ReadingExamSectionId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ReadingExamSection)
                    .WithMany(p => p.ReadingExamQuestionBlocks)
                    .HasForeignKey(d => d.ReadingExamSectionId);
            });

            modelBuilder.Entity<ReadingExamSection>(entity =>
            {
                entity.ToTable("ReadingExamSection");

                entity.HasIndex(e => e.ReadingExamId, "IX_ReadingExamSection_ReadingExamId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ReadingText)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ReadingExam)
                    .WithMany(p => p.ReadingExamSections)
                    .HasForeignKey(d => d.ReadingExamId);
            });

            modelBuilder.Entity<ReadingQuestion>(entity =>
            {
                entity.ToTable("ReadingQuestion");

                entity.HasIndex(e => e.ReadingQuestionTypeId, "IX_ReadingQuestion_ReadingQuestionTypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ReadingQuestionType)
                    .WithMany(p => p.ReadingQuestions)
                    .HasForeignKey(d => d.ReadingQuestionTypeId);
            });

            modelBuilder.Entity<ReadingQuestionAnswer>(entity =>
            {
                entity.HasIndex(e => e.ReadingQuestionId, "IX_ReadingQuestionAnswers_ReadingQuestionId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsCorrect)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ReadingQuestion)
                    .WithMany(p => p.ReadingQuestionAnswers)
                    .HasForeignKey(d => d.ReadingQuestionId);
            });

            modelBuilder.Entity<ReadingQuestionType>(entity =>
            {
                entity.ToTable("ReadingQuestionType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ReadingUserAnswer>(entity =>
            {
                entity.ToTable("ReadingUserAnswer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<SpeakingExam>(entity =>
            {
                entity.ToTable("SpeakingExam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<SpeakingExamMeeting>(entity =>
            {
                entity.ToTable("SpeakingExamMeeting");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MeetingEndTime).IsRequired();

                entity.Property(e => e.MeetingStartTime).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<SpeakingExamMeetingReserve>(entity =>
            {
                entity.ToTable("SpeakingExamMeetingReserve");

                entity.HasIndex(e => e.SpeakingExamMeetingId, "IX_SpeakingExamMeetingReserve_SpeakingExamMeetingId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.SpeakingExamMeeting)
                    .WithMany(p => p.SpeakingExamMeetingReserves)
                    .HasForeignKey(d => d.SpeakingExamMeetingId);
            });

            modelBuilder.Entity<UserPanelMenu>(entity =>
            {
                entity.ToTable("UserPanelMenu");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Icon).IsRequired();

                entity.Property(e => e.PageName).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<UserResualt>(entity =>
            {
                entity.ToTable("UserResualt");

                entity.HasIndex(e => e.IeltsResualtLevelId, "IX_UserResualt_IeltsResualtLevelId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IeltsResualtLevel)
                    .WithMany(p => p.UserResualts)
                    .HasForeignKey(d => d.IeltsResualtLevelId);
            });

            modelBuilder.Entity<WritingExam>(entity =>
            {
                entity.ToTable("WritingExam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<WritingExamSection>(entity =>
            {
                entity.ToTable("WritingExamSection");

                entity.HasIndex(e => e.WritingExamId, "IX_WritingExamSection_WritingExamId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.WritingExam)
                    .WithMany(p => p.WritingExamSections)
                    .HasForeignKey(d => d.WritingExamId);
            });

            modelBuilder.Entity<WritingUserAnswer>(entity =>
            {
                entity.ToTable("WritingUserAnswer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AnswerText).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
