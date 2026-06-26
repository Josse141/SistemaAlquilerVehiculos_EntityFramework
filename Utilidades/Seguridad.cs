using System.Security.Cryptography;
using System.Text;

namespace SistemaAlquilerVehiculos.Utilidades
{
    // Contiene métodos básicos relacionados con la seguridad de credenciales.
    public static class Seguridad
    {
        // Genera el hash SHA-256 de una contraseña para no almacenarla como texto visible.
        public static string Encriptar(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] datos = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(datos);

                StringBuilder resultado = new StringBuilder();

                foreach (byte caracter in hash)
                {
                    resultado.Append(caracter.ToString("x2"));
                }

                return resultado.ToString();
            }
        }
    }
}
