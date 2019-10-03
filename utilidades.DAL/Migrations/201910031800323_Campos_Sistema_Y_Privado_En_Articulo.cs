namespace utilidades.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Campos_Sistema_Y_Privado_En_Articulo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articulo", "Privado", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetRoles", "Sistema", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Sistema", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Imagen", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Imagen");
            DropColumn("dbo.AspNetUsers", "Sistema");
            DropColumn("dbo.AspNetRoles", "Sistema");
            DropColumn("dbo.Articulo", "Privado");
        }
    }
}
