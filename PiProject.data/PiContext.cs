namespace PiProject.data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using domain.entities;

	public partial class PiContext : DbContext
	{
		public PiContext()
			: base("name=PiContext")
		{
		}

		public virtual DbSet<C__migrationhistory> C__migrationhistory { get; set; }
		public virtual DbSet<t_answerobject> t_answerobject { get; set; }
		public virtual DbSet<t_answertestaffectation> t_answertestaffectation { get; set; }
		public virtual DbSet<t_collaborator> t_collaborator { get; set; }
		public virtual DbSet<t_criteria> t_criteria { get; set; }
		public virtual DbSet<t_developper> t_developper { get; set; }
		public virtual DbSet<t_evaluationguestaffectation> t_evaluationguestaffectation { get; set; }
		public virtual DbSet<t_evaluationtargetaffectation> t_evaluationtargetaffectation { get; set; }
		public virtual DbSet<t_evaluationtest> t_evaluationtest { get; set; }
		public virtual DbSet<t_feedback> t_feedback { get; set; }
		public virtual DbSet<t_manager> t_manager { get; set; }
		public virtual DbSet<t_performancenote> t_performancenote { get; set; }
		public virtual DbSet<t_possibleresponse> t_possibleresponse { get; set; }
		public virtual DbSet<t_testtype> t_testtype { get; set; }
		

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<C__migrationhistory>()
				.Property(e => e.MigrationId)
				.IsUnicode(false);

			modelBuilder.Entity<C__migrationhistory>()
				.Property(e => e.ContextKey)
				.IsUnicode(false);

			modelBuilder.Entity<C__migrationhistory>()
				.Property(e => e.ProductVersion)
				.IsUnicode(false);

			modelBuilder.Entity<t_answertestaffectation>()
				.HasMany(e => e.t_answerobject)
				.WithOptional(e => e.t_answertestaffectation)
				.HasForeignKey(e => new { e.affectedTo_idCollaborator, e.affectedTo_idEvaluationTest });

			modelBuilder.Entity<t_collaborator>()
				.Property(e => e.C_email)
				.IsUnicode(false);

			modelBuilder.Entity<t_collaborator>()
				.Property(e => e.C_Forname)
				.IsUnicode(false);

			modelBuilder.Entity<t_collaborator>()
				.Property(e => e.C_Lastname)
				.IsUnicode(false);

			modelBuilder.Entity<t_collaborator>()
				.Property(e => e.C_password)
				.IsUnicode(false);

			modelBuilder.Entity<t_collaborator>()
				.HasMany(e => e.t_answertestaffectation)
				.WithRequired(e => e.t_collaborator)
				.HasForeignKey(e => e.idCollaborator)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<t_collaborator>()
				.HasMany(e => e.t_evaluationtest)
				.WithOptional(e => e.t_collaborator)
				.HasForeignKey(e => e.creator_C_ID);

			modelBuilder.Entity<t_collaborator>()
				.HasOptional(e => e.t_manager)
				.WithRequired(e => e.t_collaborator);

			modelBuilder.Entity<t_collaborator>()
				.HasOptional(e => e.t_developper)
				.WithRequired(e => e.t_collaborator);

			modelBuilder.Entity<t_collaborator>()
				.HasMany(e => e.t_evaluationtargetaffectation)
				.WithRequired(e => e.t_collaborator)
				.HasForeignKey(e => e.idCollaborator)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<t_collaborator>()
				.HasMany(e => e.t_performancenote)
				.WithOptional(e => e.t_collaborator)
				.HasForeignKey(e => e.collaborator_C_ID);

			modelBuilder.Entity<t_collaborator>()
				.HasMany(e => e.t_evaluationguestaffectation)
				.WithRequired(e => e.t_collaborator)
				.HasForeignKey(e => e.idCollaborator)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<t_criteria>()
				.Property(e => e.Cr_Content)
				.IsUnicode(false);

			modelBuilder.Entity<t_criteria>()
				.Property(e => e.Cr_Description)
				.IsUnicode(false);

			modelBuilder.Entity<t_criteria>()
				.HasMany(e => e.t_possibleresponse)
				.WithOptional(e => e.t_criteria)
				.HasForeignKey(e => e.criteria_Cr_ID);

			modelBuilder.Entity<t_developper>()
				.Property(e => e.Function)
				.IsUnicode(false);

			modelBuilder.Entity<t_evaluationtest>()
				.Property(e => e.ET_Description)
				.IsUnicode(false);

			modelBuilder.Entity<t_evaluationtest>()
				.Property(e => e.ET_Type)
				.IsUnicode(false);

			modelBuilder.Entity<t_evaluationtest>()
				.Property(e => e.Et_tType)
				.IsUnicode(false);

			modelBuilder.Entity<t_evaluationtest>()
				.HasMany(e => e.t_answertestaffectation)
				.WithRequired(e => e.t_evaluationtest)
				.HasForeignKey(e => e.idEvaluationTest)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<t_evaluationtest>()
				.HasMany(e => e.t_criteria)
				.WithOptional(e => e.t_evaluationtest)
				.HasForeignKey(e => e.evaluationTest_ET_ID);

			modelBuilder.Entity<t_evaluationtest>()
				.HasMany(e => e.t_evaluationguestaffectation)
				.WithRequired(e => e.t_evaluationtest)
				.HasForeignKey(e => e.idEvaluationTest)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<t_evaluationtest>()
				.HasMany(e => e.t_evaluationtargetaffectation)
				.WithRequired(e => e.t_evaluationtest)
				.HasForeignKey(e => e.idEvaluationTest)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<t_feedback>()
				.Property(e => e.F_title)
				.IsUnicode(false);

			modelBuilder.Entity<t_feedback>()
				.Property(e => e.F_content)
				.IsUnicode(false);

			modelBuilder.Entity<t_feedback>()
				.HasMany(e => e.t_answertestaffectation)
				.WithOptional(e => e.t_feedback)
				.HasForeignKey(e => e.feedback_F_ID);

			modelBuilder.Entity<t_manager>()
				.HasMany(e => e.t_evaluationtest)
				.WithOptional(e => e.t_manager)
				.HasForeignKey(e => e.creator_id);

			modelBuilder.Entity<t_possibleresponse>()
				.Property(e => e.Pr_Content)
				.IsUnicode(false);

			modelBuilder.Entity<t_possibleresponse>()
				.Property(e => e.Pr_Description)
				.IsUnicode(false);

			modelBuilder.Entity<t_testtype>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<t_testtype>()
				.HasMany(e => e.t_evaluationtest)
				.WithOptional(e => e.t_testtype)
				.HasForeignKey(e => e.testType_id);
		}
	}
}
