using Estacionamento.Repositorio;
using Estacionamento.View;

namespace Estacionamento;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        // Inicializa o banco de dados
        using (var context = new EstacionamentoContext())
        {
            // Cria o banco de dados se não existir
            context.Database.EnsureCreated();
        }

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}