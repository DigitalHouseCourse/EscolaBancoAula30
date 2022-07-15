namespace Escola.Models
{
    public class Instituicao
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string cnpj { get; set; }
        public virtual ICollection<Aluno> alunos { get; set; } = new List<Aluno>();
    }
}
