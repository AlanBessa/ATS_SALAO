using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Domain.SharedKernel.ValueObjects
{
    public class CEP
    {
        public string CepCod { get; private set; }
        public const int CepMaxLength = 8;

        protected CEP()
        {
        }

        public CEP(string cep)
        {
            CepCod = cep;
        }

        public string ObterCepFormatado()
        {
            if (CepCod == null)
                return "";

            while (CepCod.Length < 8)
                CepCod = "0" + CepCod;

            return CepCod.Substring(0, 5) + "-" + CepCod.Substring(5);
        }
    }
}
