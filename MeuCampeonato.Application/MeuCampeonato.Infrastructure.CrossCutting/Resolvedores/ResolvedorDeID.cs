using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.CrossCutting.Resolvedores
{
    public static class ResolvedorDeID
    {
        public static Guid GerarGuid()
        {
            return Guid.NewGuid();
        }
    }

}
