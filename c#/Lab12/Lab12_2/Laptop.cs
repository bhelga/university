using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_2
{
    class Laptop : Computer
    {
        public int BatteryDuration { get; set; }
        public Laptop() : base() { }
        public Laptop(double cpu, int numOfCores, int memory, double hardDisk, int batteryDuration) : base(cpu, numOfCores, memory, hardDisk)
        {
            this.BatteryDuration = batteryDuration;
        }
        
        public override double GetDeviceCost()
        {
            return (base.GetDeviceCost() + this.BatteryDuration) / 10;
        }

        public override bool GetDeviceSuitability()
        {
            return base.GetDeviceSuitability() && this.BatteryDuration >= 60;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"LAPTOP\n\nCPU Frequency : {this.CPUFrequency} MHz\nNumber Of Cores : {this.NumberOfCores}\nMemory : {this.Memory} MB\nHard Disk Capaity : {this.HardDiskCapacity} GB\nCost : ${GetDeviceCost()}\nBattery Duration : {this.BatteryDuration} min\nSituability : {GetDeviceSuitability()}\n");
        }
    }
}
