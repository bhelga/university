using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_2
{
    class Computer
    {
        public double CPUFrequency { get; set; }
        public int NumberOfCores { get; set; }
        public int Memory { get; set; }
        public double HardDiskCapacity { get; set; }

        public Computer()
        {

        }

        public Computer(double cpu, int numOfCores, int memory, double hardDisk)
        {
            this.CPUFrequency = cpu;
            this.NumberOfCores = numOfCores;
            this.Memory = memory;
            this.HardDiskCapacity = hardDisk;
        }

        public virtual double GetDeviceCost()
        {
            return ((this.CPUFrequency * this.NumberOfCores) / 100 + (this.Memory / 80) + (this.HardDiskCapacity / 20));
        }

        public virtual bool GetDeviceSuitability()
        {
            return this.CPUFrequency >= 2000 && this.NumberOfCores >= 2 && this.Memory >= 2048 && this.HardDiskCapacity >= 320;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"COMPUTER\n\nCPU Frequency : {this.CPUFrequency} MHz\nNumber Of Cores : {this.NumberOfCores}\nMemory : {this.Memory} MB\nHard Disk Capaity : {this.HardDiskCapacity} GB\nCost : ${GetDeviceCost()}\nSituability : {GetDeviceSuitability()}\n");
        }
    }
}
