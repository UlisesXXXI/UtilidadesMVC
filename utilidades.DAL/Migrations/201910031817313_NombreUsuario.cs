namespace utilidades.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
    }
}
