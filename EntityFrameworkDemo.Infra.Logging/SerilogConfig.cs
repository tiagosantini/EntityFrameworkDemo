using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;
using System;

namespace EntityFrameworkDemo.Infra.Logging
{
    public class SerilogConfig
    {
        private static LoggingLevelSwitch LevelSwitch { get; set; } = new LoggingLevelSwitch();

        static SerilogConfig()
        {
            // Configurando o nível de logging dinamicamente
            ConfigurarNivel(LogEventLevel.Verbose);
        }

        public static void CriarLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(LevelSwitch)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithEnvironmentUserName()
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "7vhi2xy0pSo6lsVGHzi2",
                    controlLevelSwitch: LevelSwitch)
                .CreateLogger();
        }

        public static void ConfigurarNivel(LogEventLevel nivel)
        {
            LevelSwitch.MinimumLevel = nivel;
        }
    }
}
