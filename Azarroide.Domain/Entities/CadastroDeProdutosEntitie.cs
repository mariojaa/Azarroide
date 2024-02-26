using Azarroide.Domain.Enums;

namespace Azarroide.Domain.Entities
{
    public class CadastroDeProdutosEntitie
    {
        public int Id { get; set; }
        public string NomeProdutoCadastrar { get; set; }
        public StatusCadastroDeProdutosEnum StatusDoCadastroDeProduto { get; set; }
        public ColaboradorEntitie? ColaboradorCadastroProduto { get; set; } //Relacionamento 1 pra muitos (1 colaborador = Varios cadastros de produtos)
        public EmpresaEntitie? EmpresaEntitieApi { get; set; } //Relacionamento muitos para muitos (varias empresas = varios produtos - mesmo produto)
    }
}
