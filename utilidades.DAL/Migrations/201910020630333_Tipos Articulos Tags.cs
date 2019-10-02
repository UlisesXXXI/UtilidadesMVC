namespace utilidades.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TiposArticulosTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 500),
                        Contenido = c.String(),
                        TipoId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaModificacion = c.DateTime(nullable: false),
                        UsuarioModificacion = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo", t => t.TipoId)
                .Index(t => t.TipoId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagsArticulo",
                c => new
                    {
                        ArticuloId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticuloId, t.TagId })
                .ForeignKey("dbo.Articulo", t => t.ArticuloId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ArticuloId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articulo", "TipoId", "dbo.Tipo");
            DropForeignKey("dbo.TagsArticulo", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagsArticulo", "ArticuloId", "dbo.Articulo");
            DropIndex("dbo.TagsArticulo", new[] { "TagId" });
            DropIndex("dbo.TagsArticulo", new[] { "ArticuloId" });
            DropIndex("dbo.Articulo", new[] { "TipoId" });
            DropTable("dbo.TagsArticulo");
            DropTable("dbo.Tipo");
            DropTable("dbo.Tags");
            DropTable("dbo.Articulo");
        }
    }
}
