namespace utilidades.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagenesEntipos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tipo", "TipoDato", c => c.String());
            AddColumn("dbo.Tipo", "Imagen", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tipo", "Imagen");
            DropColumn("dbo.Tipo", "TipoDato");
        }
    }
}
