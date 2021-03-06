namespace APIAcmeProdutos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncluirUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cliente = c.String(),
                        Nome = c.String(),
                        registration_id = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
