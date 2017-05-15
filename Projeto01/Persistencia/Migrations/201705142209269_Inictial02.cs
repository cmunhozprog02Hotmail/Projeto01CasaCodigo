namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inictial02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Produto", "CategoriaId", c => c.Long(nullable: false));
            CreateIndex("dbo.Produto", "CategoriaId");
            AddForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria", "CategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            AlterColumn("dbo.Produto", "CategoriaId", c => c.Long());
            AlterColumn("dbo.Produto", "Nome", c => c.String());
            CreateIndex("dbo.Produto", "CategoriaId");
            AddForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria", "CategoriaId");
        }
    }
}
