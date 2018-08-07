namespace VKart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMemberShipTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MemberShipTypeId");
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MyPropeMemberShipTypeIdrty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MyPropeMemberShipTypeIdrty", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MemberShipTypeId", newName: "MembershipType_Id");
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
