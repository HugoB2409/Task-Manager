using System.Collections.Generic;
using TaskManager.BusinessLogic.Models;

namespace TaskManager.BusinessLogic.Services
{
    public interface IProcessesService
    {
        List<ProcessModel> GetRunningProcesses();
        List<ProcessModel> UpdateRunningProcesses(List<ProcessModel> processes);
    }
}
