using System;
using System.Diagnostics;
using System.Threading;

namespace TaskManager.BusinessLogic.Models
{
    public class ProcessModel
    {
        private readonly PerformanceCounter CPUCounter;
        private readonly PerformanceCounter MemCounter;
        private readonly PerformanceCounter DiskCounter;

        public Process Process { get; set; }
        public double Cpu { get; set; }
        public double Memory { get; set; }
        public double Disk { get; set; }

        public ProcessModel(Process process)
        {
            Process = process;
            CPUCounter = new PerformanceCounter("Process", "% Processor Time", Process.ProcessName);
            MemCounter = new PerformanceCounter("Process", "Working Set", Process.ProcessName);
            DiskCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", Process.ProcessName);

            var workerThread = new Thread(UpdatePerf);
            workerThread.Start();
        }

        private void UpdatePerf()
        {
            while (true)
            {
                Thread.Sleep(1000);
                UpdateCpu();
                UpdateMem();
                UpdateDisk();
            }
        }

        private void UpdateCpu()
        {
            try
            {
                Cpu = Math.Round(CPUCounter.NextValue() / Environment.ProcessorCount, 1);
            }
            catch
            {
                Cpu = 0;
            }
        }

        private void UpdateMem()
        {
            try
            {
                Memory = Math.Round((MemCounter.NextValue() / 1024) / 1024, 1);
            }
            catch
            {
                Memory = 0;
            }
        }

        private void UpdateDisk()
        {
            try
            {
                Disk = Math.Round((DiskCounter.NextValue() / 1024) / 1024, 1);
            }
            catch
            {
                Disk = 0;
            }
        }
    }
}
