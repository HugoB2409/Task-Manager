using System.Collections.Generic;
using System.Diagnostics;
using TaskManager.BusinessLogic.Models;

namespace TaskManager.BusinessLogic.Services
{
    class ProcessesService : IProcessesService
    {
        public List<ProcessModel> GetRunningProcesses()
        {
            Process[] processCollection = Process.GetProcesses();
            List<ProcessModel> processes = new List<ProcessModel>();
            foreach (Process p in processCollection)
            {
                ProcessModel process = new ProcessModel(p);
                processes.Add(process);
            }
            return processes;
        }

        public List<ProcessModel> UpdateRunningProcesses(List<ProcessModel> processes)
        {
            foreach (ProcessModel p in processes)
            {
                if(p.Process == null && p.Process.Id == 0)
                {
                    processes.Remove(p);
                }
            }
            return processes;
        }
    }
}
