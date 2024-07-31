using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testeTecnico.Models
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Matricula { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Curso { get; set; }

        public DateTime DataCadastro { get; private set; }

        public Aluno (string nome, string matricula, string email, string curso)
        {
            this.Nome = nome;
            this.Matricula = matricula;
            this.Email = email;
            this.Curso = curso;
            this.DataCadastro = DateTime.Now;
        }


    }
}
