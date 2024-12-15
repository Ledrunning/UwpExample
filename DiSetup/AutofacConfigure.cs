using System.IO;
using Windows.Storage;
using Autofac;
using Serilog;
using UwpExample.ViewModel;

namespace UwpExample.DiSetup
{
    public class AutofacConfigure
    {
        public static IContainer Container { get; set; }

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            RegisterLogger(builder);

            builder.RegisterType<MainMenuViewModel>().AsSelf();

            builder.RegisterType<MeasurementPageViewModel>().AsSelf();


            Container = builder.Build();
        }

        private static void RegisterLogger(ContainerBuilder builder)
        {
            const string FileOutputTemplate =
                "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}";
            var logPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Logs", "MyFirstDemoUwp-{Date}.log");


            builder.Register<ILogger>((c, p) => new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(logPath, outputTemplate: FileOutputTemplate)
                .WriteTo.Console()
                .CreateLogger()).SingleInstance();
        }
    }
}