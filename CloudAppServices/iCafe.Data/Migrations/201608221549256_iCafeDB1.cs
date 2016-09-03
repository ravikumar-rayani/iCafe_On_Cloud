namespace iCafe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iCafeDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ItemCategories", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemCategories", "Image", c => c.String());
        }
    }
}
