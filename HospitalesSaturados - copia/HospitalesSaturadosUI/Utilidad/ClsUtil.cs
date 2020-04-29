using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HospitalesSaturadosUI.Utilidad
{
    public class ClsUtil
    {
        /// <summary>
        /// sirve para ver si el codigo de médico introducido es válido
        /// </summary>
        /// <param name="codigoMedicoIntroducido"></param>
        /// <returns>true si el codigo es válido y false si no</returns>
        public bool IsCodigoMedicoValido(string codigoMedicoIntroducido)
        {
            bool res = false;

            if (codigoMedicoIntroducido != null)
            {
                if (codigoMedicoIntroducido.Length == 10 &&
                    Regex.IsMatch(codigoMedicoIntroducido.Substring(0, 3), @"(?:.*[0-9]){3}") &&
                    Regex.IsMatch(codigoMedicoIntroducido.Substring(3, 3), @"(?:.*[A-Z]){3}") &&
                    Regex.IsMatch(codigoMedicoIntroducido.Substring(6, 4), @"(?:.*[0-9]){4}"))
                {
                    res = true;
                }
            }

            return res;
        }


    }
}