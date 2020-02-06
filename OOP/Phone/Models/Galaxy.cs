using System;

namespace Phone.Models
{
    public class Galaxy : Phone, IRingable
    {
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone)
            : base(versionNumber, batteryPercentage, carrier, ringTone) { }
        public string Ring()
        {
            return $" {RingTone} ";
        }

        public string Unlock()
        {
            return $"Galaxy {VersionNumber} has been unlocked with face scanner";
        }
        public override void DisplayInfo()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine($"\nGalaxy {VersionNumber}\nBattery Level: {BatteryPercentage}%\nCarrier: {Carrier}\nRing Tone: {RingTone}\n");            
            Console.WriteLine(new string('*', 40));
        }
    }

}