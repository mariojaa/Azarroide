using Azarroide.Domain.Enums;

namespace Azarroide.Domain.Entities
{
    public class ColaboradorEntitie
    {
        public int Id { get; set; }
        public int MatriculaColaborador { get; set; }
        public string NomeCompletoColaborador { get; set; }
        public string EmailColaborador { get; set; }
        public string NomeEUltimoNomeColaborador { get; set; }
        public SetorColaboradorEnum SetorColaborador { get; set; }
        public int RamalColaborador { get; set; }
        public PerfilColaboradorEnum PerfilColaborador { get; set; }
    }
}