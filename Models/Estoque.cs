public class Estoque
{
    public int IdEstoque { get; set; }
    public string CodigoLote { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }

    public Produto Produto { get; set; }
}