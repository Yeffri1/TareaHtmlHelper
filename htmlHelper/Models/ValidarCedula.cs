using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace htmlHelper.Models
{
    public class ValidarCedula
    {
        /// <summary>
        /// Valida si el documento de identidad "cedula dominicana" es valida.
        /// </summary>
        /// <param name="cedula">CEDULA DOMINICANA</param>
        /// <returns>Retorna true si es verdadera y false si no.</returns>
        public static bool EsValid(string cedula)
        {

            string ced = cedula.Replace("-", "");
            if (!cedula.All(char.IsNumber))
            {
                return false;
            }
            int verificador = Convert.ToInt32(ced.Substring(ced.Length - 1, 1));
            string cedulax = ced.Substring(0, ced.Length - 1);
            int suma = 0;
            bool cedulaValida = false;
            int mod = 0;
            if (ced.Length < 11)
            {
                return false;
            }
            for (int i = 0; i < cedulax.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    mod = 1;
                }
                else
                {
                    mod = 2;
                }
                object res = Convert.ToInt32(ced.Substring(i, 1)) * mod;
                if ((int)res > 9)
                {
                    res = res.ToString();
                    int n1 = Convert.ToInt32(res.ToString().Substring(0, 1));
                    int n2 = Convert.ToInt32(res.ToString().Substring(1, 1));
                    res = n1 + n2;
                }
                suma += (int)res;
            }
            int numero = (10 - (suma % 10)) % 10;
            if (numero == verificador)
            {
                cedulaValida = true;
            }
            else
            {
                cedulaValida = false;
            }
            return cedulaValida;

        }
    }
}