namespace DkGourmet.Entites;

public class Produto
{
    public Produto(string nome, double valor, bool ativo)
    {
        Nome = nome;    
        Valor = valor;
        Ativo = ativo;
    }
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nome { get; set; }
    public double Valor { get; set; }
    public bool Ativo { get; set; }
}