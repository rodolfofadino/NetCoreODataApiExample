using ApiODataExample.Models;
using System;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public string Sku{ get; set; }
}
