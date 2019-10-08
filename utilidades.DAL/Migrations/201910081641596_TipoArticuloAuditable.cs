namespace utilidades.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoArticuloAuditable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tipo", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tipo", "UsuarioCreacion", c => c.String());
            AddColumn("dbo.Tipo", "FechaModificacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tipo", "UsuarioModificacion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tipo", "UsuarioModificacion");
            DropColumn("dbo.Tipo", "FechaModificacion");
            DropColumn("dbo.Tipo", "UsuarioCreacion");
            DropColumn("dbo.Tipo", "FechaCreacion");
        }
    }
}
