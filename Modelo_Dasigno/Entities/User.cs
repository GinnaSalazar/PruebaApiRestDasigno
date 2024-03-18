using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Dasigno.Entities
{
    public partial class User
    {
        [Key]
        public int IdUsuario { get; set; }
        [StringLength(50)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string PrimerNombre { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string SegundoNombre { get; set; }
        [StringLength(50)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string PrimerApellido { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string SegundoApellido { get; set; }
        [Required]
        public string FechaNacimiento { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sueldo { get; set; }
        public string FechaInsercion { get; set; }
        public string FechaActualizacion { get; set; } = string.Empty;

    }
}
