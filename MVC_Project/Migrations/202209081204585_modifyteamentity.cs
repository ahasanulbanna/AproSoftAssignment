namespace AdvMasterDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyteamentity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teams", "ManagerApproveHtmlCode");
            DropColumn("dbo.Teams", "DirectorApproveHtmlCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "DirectorApproveHtmlCode", c => c.String());
            AddColumn("dbo.Teams", "ManagerApproveHtmlCode", c => c.String());
        }
    }
}
