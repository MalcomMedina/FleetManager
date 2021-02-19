using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Helpers.Utils
{
    public static class MethodsLibrary
    {
        //get current date
        public static DateTime DateTimeNow => DateTime.Now;



        #region ENCRIPTACIÓN

        //MÉTODO DE ENCRIPTACIÓN PARA CONTRASEÑAS
        public static string GetSha256(string str)
        {
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (var i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        #endregion
    }
}
