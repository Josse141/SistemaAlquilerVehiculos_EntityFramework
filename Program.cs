using System;
using System.Data.Entity;
using System.Windows.Forms;
using SistemaAlquilerVehiculos.Datos;
using SistemaAlquilerVehiculos.Formularios;

namespace SistemaAlquilerVehiculos
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicializa la base de datos y registra los datos base del sistema.
            Database.SetInitializer(new InicializadorBaseDatos());

            using (AlquilerDbContext contexto = new AlquilerDbContext())
            {
                contexto.Database.Initialize(false);
            }

            Application.Run(new FrmLogin());
        }
    }
}
