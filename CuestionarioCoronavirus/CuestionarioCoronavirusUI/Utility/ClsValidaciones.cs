using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuestionarioCoronavirusUI.Utility
{
    public class ClsValidaciones
    {
		/// <summary>
		/// sirve para validar un dni
		/// </summary>
		/// <param name="dni">el dni que queremos validar</param>
		/// <returns>true si es válidi y false si no</returns>
		/// 

		//lo he hecho ,pero no lo uso
		public bool ValidarDNI(String dni)
		{
			bool ret = false;
			String caracteres="TRWAGMYFPDXBNJZSQVHLCKE";
			string letra = "";
			string dniGenerado = "";
			int res = 0;

			if (dni.Length == 8)
			{
				res = (Convert.ToInt32(dni)) % 23;
				letra = caracteres[res].ToString();
				dniGenerado = dni + letra;

				if (dni == dniGenerado)
				{
					ret = true;
				}
			}
			return ret;
		}
    }
}