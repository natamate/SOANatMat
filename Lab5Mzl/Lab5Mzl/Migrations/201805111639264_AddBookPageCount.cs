namespace Lab5Mzl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookPageCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("store.Books", "PageCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("store.Books", "PageCount");
        }
    }
}
