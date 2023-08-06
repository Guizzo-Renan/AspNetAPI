public class ProdutoAuxiliar
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public string ImagemUrl1 { get; set; }
    public string ImagemUrl2 { get; set; }
    public string ImagemUrl3 { get; set; }
    public double Nota { get; set; }
    public int IdComentarios { get; set; }

    public Produto Produto { get; set; }
}

// Models/Especificacao.cs
public class Especificacao
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public string Detalhes { get; set; }

    public Produto Produto { get; set; }
}