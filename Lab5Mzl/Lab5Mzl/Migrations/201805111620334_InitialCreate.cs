namespace Lab5Mzl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "store.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorSurname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "store.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("store.Books");
            DropTable("store.Authors");
        }
    }
}
