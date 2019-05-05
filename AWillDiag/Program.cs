using System;
//using System.Diagnostics;
using System.Management;

namespace AWillDiag
{
    class Program
    {
        static int GetCoreCount()
        {
            int coreCount = 0;
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }
            return coreCount;
        }

        static int GetProcessorCount()
        {
            int processorCount = 0;
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                processorCount = int.Parse(item["NumberOfProcessors"].ToString());
            }
            return processorCount;
        }

        static int GetLogicalProcessorCount()
        {
            int processorCount = 0;
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                processorCount = int.Parse(item["NumberOfLogicalProcessors"].ToString());
            }
            return processorCount;
        }

        static void Main(string[] args)
        {
            //var machineName = Process.GetCurrentProcess().MachineName;
            //Console.WriteLine($"Hello World! [From {machineName}]");

            Console.WriteLine($"# Cores: {GetCoreCount()}");
            Console.WriteLine($"# Processors: {GetProcessorCount()}");
            Console.WriteLine($"# Logical Processors: {GetLogicalProcessorCount()} === {Environment.ProcessorCount}");
        }
    }
}
