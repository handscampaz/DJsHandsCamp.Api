namespace DJsHandsCamp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HcMembers",
                c => new
                    {
                        HcMemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HcMemberCategory = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HcMemberId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsId = c.Int(nullable: false, identity: true),
                        HcMemberId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsId)
                .ForeignKey("dbo.HcMembers", t => t.HcMemberId, cascadeDelete: true)
                .Index(t => t.HcMemberId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ContactUs", new[] { "HcMemberId" });
            DropForeignKey("dbo.ContactUs", "HcMemberId", "dbo.HcMembers");
            DropTable("dbo.ContactUs");
            DropTable("dbo.HcMembers");
        }
    }
}
