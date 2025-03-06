using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AciesManagmentProject.Models;

public partial class AciesContext : DbContext
{
    public AciesContext()
    {
    }

    public AciesContext(DbContextOptions<AciesContext> options)
        : base(options)
    {
    }
 
    public virtual DbSet<AccountsPayable> AccountsPayables { get; set; }

    public virtual DbSet<cashholt> cashholts { get; set; }
    public virtual DbSet<breakdownYearly> breakdownYearlys { get; set; }
    public virtual DbSet<account_monthly> account_monthlys { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Incomeasset> Incomeassets { get; set; }
    public virtual DbSet<Intangible> Intangibles { get; set; }
    public virtual DbSet<Class> cc { get; set; }
    public virtual DbSet<BalanceCheckResult> BalanceCheckResults { get; set; }
    public virtual DbSet<TotalLevelResult> TotalLevelResults { get; set; }
    public virtual DbSet<Breakdown> Breakdowns { get; set; }
    public virtual DbSet<ControlPointSummary> ControlPointSummaries { get; set; }
    public virtual DbSet<rsk_by_account> rsk_by_accounts { get; set; }
    public virtual DbSet<viz_baddebt> viz_baddebts { get; set; }
    public virtual DbSet<FinStatSum> FinStatSums { get; set; }

    public virtual DbSet<AccountsReceivable> AccountsReceivables { get; set; }

    public virtual DbSet<AnlysCpsValue> AnlysCpsValues { get; set; }

    public virtual DbSet<AnlysManualEntry> AnlysManualEntries { get; set; }

    public virtual DbSet<AnlysReconcilliation> AnlysReconcilliations { get; set; }

    public virtual DbSet<AnlysRev> AnlysRevs { get; set; }

    public virtual DbSet<AnlysSuspeciousWord> AnlysSuspeciousWords { get; set; }

    public virtual DbSet<AnlysUnbalancedDbtsCrd> AnlysUnbalancedDbtsCrds { get; set; }

    public virtual DbSet<CompanySic> CompanySics { get; set; }

    public virtual DbSet<ComplexInstrument> ComplexInstruments { get; set; }

    public virtual DbSet<ControlPoint> ControlPoints { get; set; }

    public virtual DbSet<ControlPointCase> ControlPointCases { get; set; }

    public virtual DbSet<ControlPointV> ControlPointVs { get; set; }

    public virtual DbSet<ControlPointView> ControlPointViews { get; set; }

    public virtual DbSet<CopmanySictb> CopmanySictbs { get; set; }

    public virtual DbSet<CpsCount> CpsCounts { get; set; }

    public virtual DbSet<DefaultControlPoint> DefaultControlPoints { get; set; }

    public virtual DbSet<DefaultControlPointCase> DefaultControlPointCases { get; set; }

    public virtual DbSet<DefaultSusKeyword> DefaultSusKeywords { get; set; }

    public virtual DbSet< EngagmentTb> EngagmentTbs { get; set; }

    public virtual DbSet<EngagmentUserView> EngagmentUserViews { get; set; }

    public virtual DbSet<EngagmentView> EngagmentViews { get; set; }

    public virtual DbSet<FinancialMangmentSystemTb> FinancialMangmentSystemTbs { get; set; }

    public virtual DbSet<Gen> Gens { get; set; }

    public virtual DbSet<Gen2> Gen2s { get; set; }

    public virtual DbSet<GeneralLedger> GeneralLedgers { get; set; }

    public virtual DbSet<GeneralLedger1> GeneralLedgers1 { get; set; }

    public virtual DbSet<GeneralLedgerInternal> GeneralLedgerInternals { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<LibraryTb> LibraryTbs { get; set; }

    public virtual DbSet<ListAsset> ListAssets { get; set; }

    public virtual DbSet<ManualEntriesEntry> ManualEntriesEntries { get; set; }

    public virtual DbSet<ManualEntriesExecludedKeyword> ManualEntriesExecludedKeywords { get; set; }

    public virtual DbSet<ManualEntry> ManualEntries { get; set; }

    public virtual DbSet<ManualEntry1> ManualEntries1 { get; set; }

    public virtual DbSet<Mapping> Mappings { get; set; }

    public virtual DbSet<OrganizationTb> OrganizationTbs { get; set; }

    public virtual DbSet<OrganizationUserView> OrganizationUserViews { get; set; }

    public virtual DbSet<OrganizationView> OrganizationViews { get; set; }

    public virtual DbSet<OriginalAccountName> OriginalAccountNames { get; set; }

    public virtual DbSet<ReportingFrequencyTb> ReportingFrequencyTbs { get; set; }

    public virtual DbSet<RiskLevel> RiskLevels { get; set; }

    public virtual DbSet<SampleTransactionsLrg1> SampleTransactionsLrg1s { get; set; }

    public virtual DbSet<SuspeciousWord> SuspeciousWords { get; set; }

    public virtual DbSet<UserEngagmentTb> UserEngagmentTbs { get; set; }

    public virtual DbSet<UserOrganizationTb> UserOrganizationTbs { get; set; }

    public virtual DbSet<UserTb> UserTbs { get; set; }

    public virtual DbSet<Wordstoremove> Wordstoremoves { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<cashholt>().HasNoKey();
        modelBuilder.Entity<account_monthly>().HasNoKey();
        modelBuilder.Entity<FinStatSum>().HasNoKey();
        modelBuilder.Entity<Incomeasset>().HasNoKey();
        modelBuilder.Entity<Class>().HasNoKey();
        modelBuilder.Entity<BalanceCheckResult>().HasNoKey();
        modelBuilder.Entity<TotalLevelResult>().HasNoKey();
        modelBuilder.Entity<Breakdown>().HasNoKey();
        modelBuilder.Entity<breakdownYearly>().HasNoKey();
        modelBuilder.Entity<viz_baddebt>().HasNoKey();
        modelBuilder.Entity<rsk_by_account>().HasNoKey();
        modelBuilder.Entity<ControlPointSummary>().HasNoKey();
        modelBuilder.Entity<Intangible>().HasNoKey();

        modelBuilder.Entity<AccountsPayable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3213E83F7B1F1B2B");

            entity.ToTable("Accounts_Payable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.CompanyId).HasColumnName("companyID");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Debit).HasColumnName("DEBIT");
            entity.Property(e => e.Details).HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.Tt)
                .HasMaxLength(10)
                .HasColumnName("TT");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<AccountsReceivable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3213E83FC7E4331D");

            entity.ToTable("Accounts_Receivable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.CompanyId).HasColumnName("companyID");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Debit).HasColumnName("DEBIT");
            entity.Property(e => e.Details).HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.Tt)
                .HasMaxLength(10)
                .HasColumnName("TT");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<AnlysCpsValue>(entity =>
        {
            entity.ToTable("anlys_CPs_values");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpcase).HasColumnName("CPCase");
            entity.Property(e => e.Transid).HasColumnName("transid");
        });

        modelBuilder.Entity<AnlysManualEntry>(entity =>
        {
            entity.ToTable("anlys_ManualEntries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("colName");
            entity.Property(e => e.Entries)
                .IsRequired()
                .HasColumnName("entries");
            entity.Property(e => e.TransId).HasColumnName("trans_id");
        });

        modelBuilder.Entity<AnlysReconcilliation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("anlys_reconcilliation");

            entity.Property(e => e.Engagementid).HasColumnName("engagementid");
            entity.Property(e => e.Recon).HasColumnName("recon");
        });

        modelBuilder.Entity<AnlysRev>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("anlys_revs");

            entity.Property(e => e.CreditTransid).HasColumnName("credit_transid");
            entity.Property(e => e.DebitTransid).HasColumnName("debit_transid");
            entity.Property(e => e.Engagementid).HasColumnName("engagementid");
        });

        modelBuilder.Entity<AnlysSuspeciousWord>(entity =>
        {
            entity.ToTable("anlys_SuspeciousWords");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColName)
                .HasMaxLength(50)
                .HasColumnName("colName");
            entity.Property(e => e.Entries).HasColumnName("entries");
            entity.Property(e => e.TransId).HasColumnName("trans_id");
        });

        modelBuilder.Entity<AnlysUnbalancedDbtsCrd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("anlys_unbalanced_dbts_crds");

            entity.Property(e => e.CreditTransid).HasColumnName("credit_transid");
            entity.Property(e => e.DebitidTransid).HasColumnName("debitid_transid");
            entity.Property(e => e.Engagementid).HasColumnName("engagementid");
        });

        modelBuilder.Entity<CompanySic>(entity =>
        {
            entity.ToTable("CompanySIC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ComplexInstrument>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("complexInstruments");

            entity.Property(e => e.EngagementId).HasColumnName("engagementID");
            entity.Property(e => e.Instrument)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("instrument");
        });

        modelBuilder.Entity<ControlPoint>(entity =>
        {
            entity.HasKey(e => new { e.EngagementId, e.ControlPointId }).HasName("PK_ControlPoint_2");

            entity.ToTable("ControlPoint");

            entity.Property(e => e.EngagementId).HasColumnName("engagementID");

            entity.HasOne(d => d.ControlPointNavigation).WithMany(p => p.ControlPoints)
                .HasForeignKey(d => d.ControlPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlPoint_DefaultControlPoint");

            entity.HasOne(d => d.Engagement).WithMany(p => p.ControlPoints)
                .HasForeignKey(d => d.EngagementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlPoint_EngagmentTB");
        });

        modelBuilder.Entity<ControlPointCase>(entity =>
        {
            entity.HasKey(e => new { e.EngagementId, e.ControlPointId, e.ControlPointCaseId }).HasName("PK_ControlPointCase_1");

            entity.ToTable("ControlPointCase");

            entity.Property(e => e.EngagementId).HasColumnName("engagementID");
            entity.Property(e => e.ControlPointId).HasColumnName("ControlPointID");

            entity.HasOne(d => d.ControlPointCaseNavigation).WithMany(p => p.ControlPointCases)
                .HasForeignKey(d => d.ControlPointCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlPointCase_DefaultControlPointCase");

            entity.HasOne(d => d.ControlPoint).WithMany(p => p.ControlPointCases)
                .HasForeignKey(d => d.ControlPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlPointCase_DefaultControlPoint");

            entity.HasOne(d => d.Engagement).WithMany(p => p.ControlPointCases)
                .HasForeignKey(d => d.EngagementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlPointCase_EngagmentTB");
        });

        modelBuilder.Entity<ControlPointV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ControlPointV");

            entity.Property(e => e.ControlPointName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.EngagementId).HasColumnName("engagementID");
        });

        modelBuilder.Entity<ControlPointView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ControlPointView");

            entity.Property(e => e.ControlPointCaseName).HasMaxLength(200);
            entity.Property(e => e.ControlPointName).HasMaxLength(200);
            entity.Property(e => e.EngagementId).HasColumnName("engagementID");
        });

        modelBuilder.Entity<CopmanySictb>(entity =>
        {
            entity.HasKey(e => e.CopmanySicid);

            entity.ToTable("CopmanySICTB");

            entity.Property(e => e.CopmanySicid).HasColumnName("copmanySICId");
            entity.Property(e => e.CopmanySicdescription).HasColumnName("copmanySICDescription");
            entity.Property(e => e.CopmanySicindustry)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("copmanySICIndustry");
            entity.Property(e => e.CopmanySicname)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("copmanySICName");
        });

        modelBuilder.Entity<CpsCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("cps_counts");

            entity.Property(e => e.ControlPointName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Transcount).HasColumnName("transcount");
        });

        modelBuilder.Entity<DefaultControlPoint>(entity =>
        {
            entity.HasKey(e => e.ControlPointId).HasName("PK_ControlPoint");

            entity.ToTable("DefaultControlPoint");

            entity.Property(e => e.ControlPointName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Nature)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<DefaultControlPointCase>(entity =>
        {
            entity.HasKey(e => e.ControlPointCaseId).HasName("PK_ControlPointCase");

            entity.ToTable("DefaultControlPointCase");

            entity.Property(e => e.ControlPointCaseName)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.ControlPoint).WithMany(p => p.DefaultControlPointCases)
                .HasForeignKey(d => d.ControlPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefaultControlPointCase_DefaultControlPoint");
        });

        modelBuilder.Entity<DefaultSusKeyword>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Keywords).HasColumnName("keywords");
        });

        modelBuilder.Entity<EngagmentTb>(entity =>
        {
            entity.HasKey(e => e.EngagmentId);

            entity.ToTable("EngagmentTB");

            entity.Property(e => e.EngagmentId).HasColumnName("engagmentId");
            entity.Property(e => e.CopmanySicid).HasColumnName("copmanySICId");
            entity.Property(e => e.EngagmentCreatedDate).HasColumnName("engagmentCreatedDate");
            entity.Property(e => e.EngagmentDescription).HasColumnName("engagmentDescription");
            entity.Property(e => e.EngagmentFile).HasColumnName("engagmentFile");
            entity.Property(e => e.EngagmentName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("engagmentName");
            entity.Property(e => e.EngagmentStatus).HasColumnName("engagmentStatus");
            entity.Property(e => e.FinancialMangmentSystemId).HasColumnName("financialMangmentSystemId");
            entity.Property(e => e.LibraryId).HasColumnName("libraryId");
            entity.Property(e => e.OrganizationId).HasColumnName("organizationId");
            entity.Property(e => e.OwnerId).HasColumnName("ownerId");
            entity.Property(e => e.ReportingFrequencyId).HasColumnName("reportingFrequencyId");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.CopmanySic).WithMany(p => p.EngagmentTbs)
                .HasForeignKey(d => d.CopmanySicid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EngagmentTB_CopmanySICTB");

            entity.HasOne(d => d.FinancialMangmentSystem).WithMany(p => p.EngagmentTbs)
                .HasForeignKey(d => d.FinancialMangmentSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EngagmentTB_FinancialMangmentSystemTB");

            entity.HasOne(d => d.Library).WithMany(p => p.EngagmentTbs)
                .HasForeignKey(d => d.LibraryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EngagmentTB_LibraryTB");

            entity.HasOne(d => d.Organization).WithMany(p => p.EngagmentTbs)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_EngagmentTB_OrganizationTB");

            entity.HasOne(d => d.Owner).WithMany(p => p.EngagmentTbs)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EngagmentTB_UserTB");

            entity.HasOne(d => d.ReportingFrequency).WithMany(p => p.EngagmentTbs)
                .HasForeignKey(d => d.ReportingFrequencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EngagmentTB_ReportingFrequencyTB");
        });

        modelBuilder.Entity<EngagmentUserView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EngagmentUserView");

            entity.Property(e => e.EngagmentCreatedDate).HasColumnName("engagmentCreatedDate");
            entity.Property(e => e.EngagmentDescription).HasColumnName("engagmentDescription");
            entity.Property(e => e.EngagmentFile).HasColumnName("engagmentFile");
            entity.Property(e => e.EngagmentId).HasColumnName("engagmentId");
            entity.Property(e => e.EngagmentName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("engagmentName");
            entity.Property(e => e.EngagmentStatus).HasColumnName("engagmentStatus");
            entity.Property(e => e.OrganizationId).HasColumnName("organizationId");
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(100)
                .HasColumnName("organizationName");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserImage).HasColumnName("userImage");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<EngagmentView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EngagmentView");

            entity.Property(e => e.CopmanySicid).HasColumnName("copmanySICId");
            entity.Property(e => e.CopmanySicindustry)
                .HasMaxLength(100)
                .HasColumnName("copmanySICIndustry");
            entity.Property(e => e.CopmanySicname)
                .HasMaxLength(100)
                .HasColumnName("copmanySICName");
            entity.Property(e => e.EngagmentCreatedDate).HasColumnName("engagmentCreatedDate");
            entity.Property(e => e.EngagmentDescription).HasColumnName("engagmentDescription");
            entity.Property(e => e.EngagmentFile).HasColumnName("engagmentFile");
            entity.Property(e => e.EngagmentId).HasColumnName("engagmentId");
            entity.Property(e => e.EngagmentName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("engagmentName");
            entity.Property(e => e.EngagmentStatus).HasColumnName("engagmentStatus");
            entity.Property(e => e.FinancialMangmentSystemId).HasColumnName("financialMangmentSystemId");
            entity.Property(e => e.LibraryId)
                .HasMaxLength(100)
                .HasColumnName("libraryId");
            entity.Property(e => e.LibraryName)
                .HasMaxLength(100)
                .HasColumnName("libraryName");
            entity.Property(e => e.OrganizationId).HasColumnName("organizationId");
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(100)
                .HasColumnName("organizationName");
            entity.Property(e => e.ReportingFrequencyId).HasColumnName("reportingFrequencyId");
            entity.Property(e => e.ReportingFrequencyName)
                .HasMaxLength(100)
                .HasColumnName("reportingFrequencyName");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserImage).HasColumnName("userImage");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<FinancialMangmentSystemTb>(entity =>
        {
            entity.HasKey(e => e.FinancialMangmentSystemId);

            entity.ToTable("FinancialMangmentSystemTB");

            entity.Property(e => e.FinancialMangmentSystemId).HasColumnName("financialMangmentSystemId");
            entity.Property(e => e.FinancialMangmentSystemDescription).HasColumnName("financialMangmentSystemDescription");
            entity.Property(e => e.FinancialMangmentSystemName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("financialMangmentSystemName");
        });

        modelBuilder.Entity<Gen>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("gen");

            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CompanyId).HasColumnName("companyID");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Debit).HasColumnName("DEBIT");
            entity.Property(e => e.Details)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Notes)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Reference)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Tt)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("TT");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Gen2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("gen2");

            entity.Property(e => e.Account).HasColumnType("ntext");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Bank)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Branch)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Created_Date");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Created_user");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nominal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpareDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpareNum)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpareText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransId).HasColumnName("trans_id");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("Transaction_Date");
            entity.Property(e => e.Tt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TT");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeneralLedger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_General_Ledger_1");

            entity.ToTable("General_Ledger");

            entity.HasIndex(e => e.Credit, "idx_GeneralLedger_credit");

            entity.HasIndex(e => e.Debit, "idx_GeneralLedger_debit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(200);
            entity.Property(e => e.EngagementId).HasColumnName("engagementID");
            entity.Property(e => e.Nominal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Riskpercent).HasColumnName("riskpercent");
            entity.Property(e => e.TotalCp).HasColumnName("totalCP");
            entity.Property(e => e.Tt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TT");

            entity.HasOne(d => d.AccountNavigation).WithMany(p => p.GeneralLedgers)
                .HasForeignKey(d => d.Account)
                .HasConstraintName("FK_General_Ledger_Original_Account_Names");

            entity.HasOne(d => d.Engagement).WithMany(p => p.GeneralLedgers)
                .HasForeignKey(d => d.EngagementId)
                .HasConstraintName("FK_General_Ledger_EngagmentTB");
        });

        modelBuilder.Entity<GeneralLedger1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__General___3213E83F7DE4DAAD");

            entity.ToTable("General_Ledger_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.CompanyId).HasColumnName("companyID");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Debit).HasColumnName("DEBIT");
            entity.Property(e => e.Details).HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.Tt)
                .HasMaxLength(10)
                .HasColumnName("TT");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<GeneralLedgerInternal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__General___3213E83F88ECCDC4");

            entity.ToTable("General_Ledger_Internal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.CompanyId).HasColumnName("companyID");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Debit).HasColumnName("DEBIT");
            entity.Property(e => e.Details).HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.Tt)
                .HasMaxLength(10)
                .HasColumnName("TT");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Industry");

            entity.Property(e => e.CompanySic).HasColumnName("CompanySIC");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<LibraryTb>(entity =>
        {
            entity.HasKey(e => e.LibraryId);

            entity.ToTable("LibraryTB");

            entity.Property(e => e.LibraryId).HasColumnName("libraryId");
            entity.Property(e => e.LibraryDescription).HasColumnName("libraryDescription");
            entity.Property(e => e.LibraryName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("libraryName");
        });

        modelBuilder.Entity<ListAsset>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Assets)
                .HasMaxLength(10)
                .HasColumnName("assets");
        });

        modelBuilder.Entity<ManualEntriesEntry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ManualEntries_Entries");

            entity.Property(e => e.Entry).HasMaxLength(100);
            entity.Property(e => e.ManualEntryId).HasColumnName("ManualEntryID");

            entity.HasOne(d => d.ManualEntry).WithMany()
                .HasForeignKey(d => d.ManualEntryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManualEntries_Entries_ManualEntries");
        });

        modelBuilder.Entity<ManualEntriesExecludedKeyword>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ManualEntries_execluded_keywords");

            entity.Property(e => e.Keyword)
                .HasMaxLength(100)
                .HasColumnName("keyword");
            entity.Property(e => e.ManualEntryId).HasColumnName("ManualEntryID");

            entity.HasOne(d => d.ManualEntry).WithMany()
                .HasForeignKey(d => d.ManualEntryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManualEntries_execluded_keywords_ManualEntries");
        });

        modelBuilder.Entity<ManualEntry>(entity =>
        {
            entity.ToTable("Manual_entries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("col_name");
            entity.Property(e => e.EngId).HasColumnName("eng_id");
            entity.Property(e => e.Entries)
                .IsRequired()
                .HasColumnName("entries");
            entity.Property(e => e.ExcludedKeywords).HasColumnName("excluded_keywords");
        });

        modelBuilder.Entity<ManualEntry1>(entity =>
        {
            entity.ToTable("ManualEntries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColumnName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.EngagementId).HasColumnName("engagementID");
            entity.Property(e => e.ExecludedKeywords).HasColumnName("Execluded_keywords");
        });

        modelBuilder.Entity<Mapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Mapping_1");

            entity.ToTable("Mapping");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Account)
                .IsRequired()
                .HasColumnType("ntext");
            entity.Property(e => e.Category).HasMaxLength(100);
        });

        modelBuilder.Entity<OrganizationTb>(entity =>
        {
            entity.HasKey(e => e.OrganizationId);

            entity.ToTable("OrganizationTB");

            entity.Property(e => e.OrganizationId).HasColumnName("organizationId");
            entity.Property(e => e.CopmanySicid).HasColumnName("copmanySICId");
            entity.Property(e => e.FinancialMangmentSystemId).HasColumnName("financialMangmentSystemId");
            entity.Property(e => e.OrganizationCreatedDate).HasColumnName("organizationCreatedDate");
            entity.Property(e => e.OrganizationDescription).HasColumnName("organizationDescription");
            entity.Property(e => e.OrganizationName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("organizationName");
            entity.Property(e => e.OrganizationStatus).HasColumnName("organizationStatus");
            entity.Property(e => e.OwnerId).HasColumnName("ownerId");
            entity.Property(e => e.ReportingFrequencyId).HasColumnName("reportingFrequencyId");

            entity.HasOne(d => d.CopmanySic).WithMany(p => p.OrganizationTbs)
                .HasForeignKey(d => d.CopmanySicid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationTB_CopmanySICTB");

            entity.HasOne(d => d.FinancialMangmentSystem).WithMany(p => p.OrganizationTbs)
                .HasForeignKey(d => d.FinancialMangmentSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationTB_FinancialMangmentSystemTB");

            entity.HasOne(d => d.Owner).WithMany(p => p.OrganizationTbs)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_OrganizationTB_UserTB");

            entity.HasOne(d => d.ReportingFrequency).WithMany(p => p.OrganizationTbs)
                .HasForeignKey(d => d.ReportingFrequencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationTB_ReportingFrequencyTB");
        });

        modelBuilder.Entity<OrganizationUserView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrganizationUserView");

            entity.Property(e => e.OrganizationCreatedDate).HasColumnName("organizationCreatedDate");
            entity.Property(e => e.OrganizationDescription).HasColumnName("organizationDescription");
            entity.Property(e => e.OrganizationId).HasColumnName("organizationId");
            entity.Property(e => e.OrganizationName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("organizationName");
            entity.Property(e => e.OrganizationStatus).HasColumnName("organizationStatus");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserImage).HasColumnName("userImage");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<OrganizationView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrganizationView");

            entity.Property(e => e.CopmanySicid).HasColumnName("copmanySICId");
            entity.Property(e => e.CopmanySicindustry)
                .HasMaxLength(100)
                .HasColumnName("copmanySICIndustry");
            entity.Property(e => e.CopmanySicname)
                .HasMaxLength(100)
                .HasColumnName("copmanySICName");
            entity.Property(e => e.FinancialMangmentSystemId).HasColumnName("financialMangmentSystemId");
            entity.Property(e => e.FinancialMangmentSystemName)
                .HasMaxLength(100)
                .HasColumnName("financialMangmentSystemName");
            entity.Property(e => e.OrganizationCreatedDate).HasColumnName("organizationCreatedDate");
            entity.Property(e => e.OrganizationDescription).HasColumnName("organizationDescription");
            entity.Property(e => e.OrganizationId).HasColumnName("organizationId");
            entity.Property(e => e.OrganizationName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("organizationName");
            entity.Property(e => e.OrganizationStatus).HasColumnName("organizationStatus");
            entity.Property(e => e.ReportingFrequencyId).HasColumnName("reportingFrequencyId");
            entity.Property(e => e.ReportingFrequencyName)
                .HasMaxLength(100)
                .HasColumnName("reportingFrequencyName");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserImage).HasColumnName("userImage");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<OriginalAccountName>(entity =>
        {
            entity.ToTable("Original_Account_Names");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("account_name");
            entity.Property(e => e.Engagementid).HasColumnName("engagementid");
            entity.Property(e => e.MappedAccountId).HasColumnName("mapped_account_id");

            entity.HasOne(d => d.Engagement).WithMany(p => p.OriginalAccountNames)
                .HasForeignKey(d => d.Engagementid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Original_Account_Names_EngagmentTB");

            entity.HasOne(d => d.MappedAccount).WithMany(p => p.OriginalAccountNames)
                .HasForeignKey(d => d.MappedAccountId)
                .HasConstraintName("FK_Original_Account_Names_Mapping");
        });

        modelBuilder.Entity<ReportingFrequencyTb>(entity =>
        {
            entity.HasKey(e => e.ReportingFrequencyId);

            entity.ToTable("ReportingFrequencyTB");

            entity.Property(e => e.ReportingFrequencyId).HasColumnName("reportingFrequencyId");
            entity.Property(e => e.ReportingFrequencyDescription).HasColumnName("reportingFrequencyDescription");
            entity.Property(e => e.ReportingFrequencyName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("reportingFrequencyName");
        });

        modelBuilder.Entity<RiskLevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("risk_levels");

            entity.Property(e => e.EndValue).HasColumnName("end_value");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StartValue).HasColumnName("start_value");
        });

        modelBuilder.Entity<SampleTransactionsLrg1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sample Transactions Lrg (1)");

            entity.Property(e => e.Account).HasColumnType("ntext");
            entity.Property(e => e.AccountId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("account_id");
            entity.Property(e => e.Bank)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Branch)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyNum).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Created_Date");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Created_user");
            entity.Property(e => e.Credit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Debit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nominal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpareDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpareNum)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpareText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("trans_id");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("Transaction_Date");
            entity.Property(e => e.Tt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TT");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SuspeciousWord>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EngagementId).HasColumnName("engagementID");
            entity.Property(e => e.Word)
                .IsRequired()
                .HasMaxLength(40);
        });

        modelBuilder.Entity<UserEngagmentTb>(entity =>
        {
            entity.HasKey(e => e.UserEngagmentId);

            entity.ToTable("UserEngagmentTB");

            entity.Property(e => e.UserEngagmentId).HasColumnName("userEngagmentId");
            entity.Property(e => e.EngagmentId).HasColumnName("engagmentId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Engagment).WithMany(p => p.UserEngagmentTbs)
                .HasForeignKey(d => d.EngagmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEngagmentTB_EngagmentTB");

            entity.HasOne(d => d.User).WithMany(p => p.UserEngagmentTbs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserEngagmentTB_UserTB");
        });

        modelBuilder.Entity<UserOrganizationTb>(entity =>
        {
            entity.HasKey(e => e.UserOrganizationId);

            entity.ToTable("UserOrganizationTB");

            entity.Property(e => e.UserOrganizationId).HasColumnName("userOrganizationId");
            entity.Property(e => e.OrganizationId).HasColumnName("organizationId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Organization).WithMany(p => p.UserOrganizationTbs)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserOrganizationTB_OrganizationTB");

            entity.HasOne(d => d.User).WithMany(p => p.UserOrganizationTbs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserOrganizationTB_UserTB");
        });

        modelBuilder.Entity<UserTb>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserTB");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserEmail)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserImage).HasColumnName("userImage");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("userName");
            entity.Property(e => e.UserPassword)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(50)
                .HasColumnName("userPhone");
        });
        modelBuilder.Entity<Category>().HasNoKey();
        modelBuilder.Entity<Wordstoremove>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("wordstoremove");

            entity.Property(e => e.Word)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("word");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
