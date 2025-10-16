using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Mesas
{
    public class DbContext : IDisposable
    {
        private string xamppPath = @"C:\xampp\"; // Ajuste para a pasta do seu XAMPP
        private string connectionString = "server=127.0.0.1;port=3306;database=pesqueiro_senia;user=root";

        private static bool servidoresIniciados = false; // Garante que Apache/MySQL só iniciem uma vez

        public DbContext()
        {
            if (!servidoresIniciados)
            {
                IniciarXampp();
                servidoresIniciados = true;
            }
        }

        /// <summary>
        /// Retorna uma nova conexão. Não abre automaticamente.
        /// </summary>
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Inicia Apache e MySQL via XAMPP e espera ambos subirem
        /// </summary>

        private void IniciarXampp()
        {
            IniciarServidor(Path.Combine(xamppPath, @"apache\bin\httpd.exe"), "httpd");
            IniciarServidor(Path.Combine(xamppPath, @"mysql\bin\mysqld.exe"), "mysqld");
        }

        private void IniciarServidor(string caminhoExe, string nomeProcesso)
        {
            if (!Process.GetProcessesByName(nomeProcesso).Any())
            {
                var psi = new ProcessStartInfo
                {
                    FileName = caminhoExe,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(psi);
            }

            // Espera o processo subir
            int tentativas = 0;
            while (!Process.GetProcessesByName(nomeProcesso).Any())
            {
                Thread.Sleep(500);
                tentativas++;
                if (tentativas > 40)
                    throw new Exception($"{nomeProcesso} não conseguiu iniciar.");
            }
        }


        public void Dispose()
        {
            // Não precisa fechar aqui, cada GetConnection() retorna uma nova conexão
        }
    }
}
