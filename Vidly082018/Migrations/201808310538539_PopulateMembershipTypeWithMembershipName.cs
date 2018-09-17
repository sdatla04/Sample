namespace Vidly082018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeWithMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NAME = 'Pay As You Go' wHERE Id=1  ");
            Sql("UPDATE MembershipTypes SET NAME = 'Monthly' wHERE Id=2  ");
            Sql("UPDATE MembershipTypes SET NAME = 'Quaterly' wHERE Id=3  ");
            Sql("UPDATE MembershipTypes SET NAME = 'Yearly' wHERE Id=4  ");
        }
        
        public override void Down()
        {
        }
    }
}
