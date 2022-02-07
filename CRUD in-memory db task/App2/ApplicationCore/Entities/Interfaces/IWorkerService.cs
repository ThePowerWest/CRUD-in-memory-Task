using ApplicationCore.Entities.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Interfaces
{
    public interface IWorkerService
    {
         Task UpdateAsync(Worker worker);
    }
}
