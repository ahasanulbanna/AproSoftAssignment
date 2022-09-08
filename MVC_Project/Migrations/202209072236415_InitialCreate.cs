namespace AdvMasterDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        TeamMemberId = c.Long(nullable: false, identity: true),
                        MemberName = c.String(),
                        Gender = c.String(),
                        DOB = c.DateTime(nullable: false),
                        ContactNo = c.String(),
                        TeamId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TeamMemberId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        IsApprovedByManager = c.Boolean(),
                        ManagerApproveHtmlCode = c.String(),
                        IsApprovedByDirector = c.Boolean(),
                        DirectorApproveHtmlCode = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMembers", "TeamId", "dbo.Teams");
            DropIndex("dbo.TeamMembers", new[] { "TeamId" });
            DropTable("dbo.Teams");
            DropTable("dbo.TeamMembers");
        }
    }
}
