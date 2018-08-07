namespace VKart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Free Trail' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Silver' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Gold' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Diamond' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
