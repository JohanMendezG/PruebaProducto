using Productos.Entities;
using Productos.Interfaces;

namespace Productos.Utilities
{
    public class Log : ILog
    {
        private readonly string fileName;

        public Log()
        {
            fileName = "FileLog.txt";
            if (!File.Exists(fileName))
            {
                using var file = File.Create(fileName);
            }
        }

        public void AddLog(string message)
        {
            var log = CreateLog(message);
            File.AppendAllText(fileName, log);
        }

        private static string CreateLog(string message)
        {
            var data = new ELog
            {
                Detalle = message,
                Fecha = DateTime.Now
            };

            return @$"{data.Fecha} :: {data.Detalle}{Environment.NewLine}";
        }
    }
}
