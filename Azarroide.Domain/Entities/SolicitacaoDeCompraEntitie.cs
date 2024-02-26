using Azaroide.Domain.Enums;

namespace Azarroide.Domain.Entities
{
    public class SolicitacaoDeCompraEntitie
    {
        public int Id { get; set; }
        //public int NumeroDoPedido { get; set; } //Gerar Automaticamente?
        public ColaboradorEntitie ColaboradorSolicitacaoCompra { get; set; } //Relacionamento Solicitacao de compra com Colaborador
        public StatusSolicitacaoDeCompraEnum StatusSolicitacaoDeCompra { get; set; }
        public DateTime DataSolicitacaoDeCompra { get; set; } //DateTime.Now
        public DateTime DataPrevisaoDeEntregaDoProduto{ get; set; }
        public string ObservacaoDaCompra { get; set; } //entregar para X Setor /Conferir Todos Produtos no ato da Entrega
        public int QuantidadeDeProdutosParaCompra { get; set; }
    }
}