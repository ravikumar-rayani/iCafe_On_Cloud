namespace iCafe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iCafeDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemCategories", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemCategories", "Image");
        }
    }
}
