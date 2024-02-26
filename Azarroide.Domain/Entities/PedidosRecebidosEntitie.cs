namespace Azarroide.Domain.Entities
{
    public class PedidosRecebidosEntitie
    {
        public int Id { get; set; }
        public string NomeDoProdutoRecebido { get; set; }
        //public ColaboradorEntitie ColaboradorRecebimentoDoProduto { get; set; } //Nome / Matricula do colaborador que recebeu o produto
        public DateTime DataRecebimentoDoProduto { get; set; }
        public string ObservacaoRececimentoDoProduto { get; set; }
    }
}
