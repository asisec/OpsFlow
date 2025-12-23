using OpsFlow.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpsFlow.Services.Interfaces
{
    public interface IDatabaseConnectionService
    {
        AppDbContext CreateContext();
    }
}
