using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Modelo.Cadastros
{
    public class Produto
    {
        [DisplayName("Id")]
        public long? ProdutoId { get; set; }

        [StringLength(100, 
            ErrorMessage = "O nome do produto precisar conter no mínimo 10 caracteres",
            MinimumLength = 10)]
        [Required(ErrorMessage ="Informe o nome do produto")]
        public string Nome { get; set; }

        [DisplayName("Categoria")]
        public long? CategoriaId { get; set; }

        [DisplayName("Fabricante")]
        public long? FabricanteId { get; set; }

        
        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}