using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.DTOs.Time
{
    public class DtoDeTimesParticipantes
    {
        /// <summary>
        /// Código GUID do time.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
