namespace SuperheroCreator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Superheroes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Superheroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AlterEgo = c.String(),
                        PrimaryAbility = c.String(),
                        SecondaryAbility = c.String(),
                        Catchphrase = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Superheroes");
        }
    }
}
