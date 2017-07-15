namespace APIAcmeProdutos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using APIAcmeProdutos.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<APIAcmeProdutos.Models.APIAcmeProdutosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APIAcmeProdutos.Models.APIAcmeProdutosContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Produtos.AddOrUpdate(p => p.Nome,
                new Produto
                {
                    Nome = "Foguete",
                    Cliente = "coyote"
                },
                new Produto
                {
                    Nome = "Sapatos Velozes",
                    Cliente = "papa-leguas"
                });

        }
    }
}
