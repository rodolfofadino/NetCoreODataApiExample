using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiODataExample.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ApiODataExample.Controllers
{
    public class ProdutosController : ODataController
    {
        private DataContext _context;

        public ProdutosController(DataContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            //exemplo de seed
            if (_context.Produtos.Count() == 0)
            {
                _context.Produtos.Add(new Produto() { Nome = "Livro ASP.NET", Sku = "livro_asp_new", Categoria = Categoria.Tecnologia });
                _context.Produtos.Add(new Produto() { Nome = "Livro SQL", Sku = "livro_sql", Categoria = Categoria.Tecnologia });
                _context.Produtos.Add(new Produto() { Nome = "Livro C#", Sku = "livro_csharp", Categoria = Categoria.Tecnologia });
                _context.Produtos.Add(new Produto() { Nome = "Livro VB", Sku = "livro_vb", Categoria = Categoria.Tecnologia });

                _context.SaveChanges();
            }
            //exemplo de seed 

            return Ok(_context.Produtos);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_context.Produtos.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody]Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Created(produto);
        }
    }
}
