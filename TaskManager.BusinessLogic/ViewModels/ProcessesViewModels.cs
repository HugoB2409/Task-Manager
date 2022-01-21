using SimpleMvvmToolkit.Express;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using TaskManager.BusinessLogic.Models;
using TaskManager.BusinessLogic.Services;

namespace TaskManager.BusinessLogic.ViewModels
{
    public class ProcessesViewModels : ModelBase<ProcessesViewModels>
    {
        private IProcessesService _processesService;
        private ProcessModel _selectedProcess;

        private List<ProcessModel> _processes = new List<ProcessModel>();

        public List<ProcessModel> Processes
        {
            get { return _processes; }
            set
            {
                _processes = value.OrderByDescending(p => p.Cpu).ToList();
                NotifyPropertyChanged(vm => vm.Processes);
            }
        }

        public ProcessModel SelectedProcess
        {
            get { return _selectedProcess; }
            set
            {
                _selectedProcess = value;
                NotifyPropertyChanged(vm => vm.SelectedProcess);
            }
        }

        private List<ProcessModel> ReturnProcesses(ProcessesViewModels vm)
        {
            return vm.Processes;
        }

        public ICommand KillProcessesCommand => new DelegateCommand(KillProcess, CanKillProcess);

        public ProcessesViewModels(IProcessesService processesService)
        {
            _processesService = processesService;
            Processes = _processesService.GetRunningProcesses();

            var workerThread = new Thread(GetProcessesData);
            workerThread.Start();
        }

        public void GetProcessesData()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Processes = _processesService.UpdateRunningProcesses(Processes);
            }
        }

        private bool CanKillProcess()
        {
            return true;
            //return (_selectedProcess != null); Ne fonctionne pas
        }

        private void KillProcess()
        {
            if(_selectedProcess != null)
            {
                _selectedProcess.Process.Kill();
                Processes.Remove(_selectedProcess);
            }
        }
    }
}
