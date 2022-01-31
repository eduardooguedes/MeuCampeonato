using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.DTOs.Time
{
    /// <summary>
    /// 
    /// </summary>
    public class DtoDeTime
    {
        /// <summary>
        /// Identificador GUID do time. Não utilizar em métodos POSTs.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nome do time.
        /// </summary>
        [Required]
        [StringLength(30, ErrorMessage ="Informe um nome com até 30 caracteres")]
        public string Nome { get; set; }

        /// <summary>
        /// Data e hora de criacao. NÂO utilizar em métodos POSTs.
        /// </summary>
        public DateTime? DataHoraCriado { get; set; }
    }
}
