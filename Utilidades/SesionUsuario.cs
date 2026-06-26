namespace SistemaAlquilerVehiculos.Utilidades
{
    // Mantiene los datos del usuario autenticado mientras la aplicación está abierta.
    public static class SesionUsuario
    {
        public static int IdUsuario { get; set; }
        public static string NombreCompleto { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Rol { get; set; }

        // Indica si el usuario de la sesión posee permisos administrativos.
        public static bool EsAdministrador()
        {
            return Rol == "ADMINISTRADOR";
        }

        // Elimina la información de la sesión cuando el usuario cierra sesión.
        public static void CerrarSesion()
        {
            IdUsuario = 0;
            NombreCompleto = null;
            NombreUsuario = null;
            Rol = null;
        }
    }
}
