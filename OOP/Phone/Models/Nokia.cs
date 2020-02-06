using System;

namespace Phone.Models
{
    public class Nokia : Phone, IRingable
    {
        public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone)
            : base(versionNumber, batteryPercentage, carrier, ringTone) { }
        public string Ring()
        {
            return $"...{RingTone}...";
        }
        public string Unlock()
        {
            return $"Nokia {VersionNumber} has been unlocked";
        }
        public override void DisplayInfo()
        {
            Console.WriteLine(new string('#', 40));
            Console.WriteLine($"\nNokia {VersionNumber}\nBattery Level: {BatteryPercentage}%\nCarrier: {Carrier}\nRing Tone: {RingTone}\n");            
            Console.WriteLine(new string('#', 40));
        }
    }

}