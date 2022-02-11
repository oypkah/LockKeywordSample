using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockKeywordSample
{
    public class Logger
    {
        private static Logger _logger;
        private static object _lockObject = new object();

        //Made this so it wouldn't get inheritance from another class except this
        private Logger() { }


        //Create instance without lock
        public static Logger CreateWithoutLock()
        {
            if (_logger == null)
            {
                _logger = new Logger();
                Info($"{nameof(Logger)} created");
            }
            Info($"Exist {nameof(Logger)} returned");
            return _logger;
        }

        //Create instance with lock
        public static Logger CreateWithLock()
        {
            lock (_lockObject)
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                    Info($"{nameof(Logger)} created");
                }
                Info($"Exist {nameof(Logger)} returned");
                return _logger;
            }
        }

        public static void Info(string message) => Console.WriteLine($"Info --> {message}");
        //public void Error(string message) => Console.WriteLine($"Error --> {message}");
    }
}
