using System.ComponentModel.DataAnnotations;
namespace CursoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo é obrigatório")]
        public string Descricao { get; set; }
        public int  Quantidade { get; set; }
        public int  CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
   }
}