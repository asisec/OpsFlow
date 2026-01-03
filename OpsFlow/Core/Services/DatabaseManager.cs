using OpsFlow.Data.Context;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Core.Services
{
    public static class DatabaseManager
    {
        private static IDatabaseConnectionService? _instance;
        private static readonly object _lock = new object();

        public static IDatabaseConnectionService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseConnectionService();
                        }
                    }
                }
                return _instance;
            }
        }

        public static AppDbContext CreateContext()
        {
            return Instance.CreateContext();
        }

        public static void Reset()
        {
            lock (_lock)
            {
                _instance = null;
            }
        }
    }
}

