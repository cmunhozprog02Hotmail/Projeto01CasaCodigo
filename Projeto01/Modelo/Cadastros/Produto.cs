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

        [StringLength(100, ErrorMessage = "O nome do produto precisar conter no mínimo 10 caracteres")]
        [Required(ErrorMessage ="Informe o nome do produto")]
        public string Nome { get; set; }

        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Informe a data de cadastro do produto")]
        public long? CategoriaId { get; set; }

        [DisplayName("Categoria")]
        public long? FabricanteId { get; set; }

        [DisplayName("Fabricante")]
        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}