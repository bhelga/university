using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_2
{
    class Tablet : Computer
    {
        public double Weight { get; set; }
        public Tablet() : base() { }
        public Tablet(double cpu, int numOfCores, int memory, double hardDisk, double weight) : base(cpu, numOfCores, memory, hardDisk)
        {
            this.Weight = weight;
        }
        public override double GetDeviceCost()
        {
            return base.GetDeviceCost() / 10;
        }
        public override void GetInfo()
        {
            Console.WriteLine($"TABLET\n\nCPU Frequency : {this.CPUFrequency} MHz\nNumber Of Cores : {this.NumberOfCores}\nMemory : {this.Memory} MB\nHard Disk Capaity : {this.HardDiskCapacity} GB\nCost : ${GetDeviceCost()}\nWeight : {this.Weight} kg\nSituability : {GetDeviceSuitability()}\n");
        }
    }
}
