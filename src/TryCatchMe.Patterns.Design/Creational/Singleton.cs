using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchMe.Patterns.Design.Creational
{
    public class Logger
    {
        private static Logger _instance;

        private static object _syncLock = new object();

        protected Logger()
        {
            
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }   
                    }
                }

                return _instance;
            }
        }
    }
}
