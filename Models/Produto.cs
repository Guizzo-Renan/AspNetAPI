public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public bool Promocao { get; set; }
    public string ImagemURL { get; set; }
    public string TipoProduto { get; set; }
    public int Vendas { get; set; } // Campo para representar o número de vendas

    public ProdutoAuxiliar ProdutoAuxiliar { get; set; }
    public List<Especificacao> Especificacoes { get; set; }
}