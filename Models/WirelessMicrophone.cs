namespace Bai08.Models;

using Bai08.Enums;

public class WirelessMicrophone : TeachingDevice
{
    public int BatteryLevel { get; private set; }
    public int SignalQuality { get; private set; }
    public WirelessMicrophone(string id, string name, int batteryLevel, int signalQuality)
        : base(id, name)
    {
        if (batteryLevel < 0 || batteryLevel > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(batteryLevel), "Battery level must be between 0 and 100.");
        }
        if (signalQuality < 0 || signalQuality > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(signalQuality), "Signal quality must be between 0 and 100.");
        }
        BatteryLevel = batteryLevel;
        SignalQuality = signalQuality;
    }
    public void UpdateBatteryLevel(int newLevel)
    {
        if (newLevel < 0 || newLevel > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(newLevel), "Battery level must be between 0 and 100.");
        }
        BatteryLevel = newLevel;
        CheckBatteryLevel();
    }
    public void UpdateSignalQuality(int newQuality)
    {
        if (newQuality < 0 || newQuality > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(newQuality), "Signal quality must be between 0 and 100.");
        }
        SignalQuality = newQuality;
        CheckSignalQuality();
    }

    public void CheckBatteryLevel()
    {
        if (BatteryLevel == 0)
        {
            RaiseAlert("Battery level is critical.", AlertSeverity.Critical);
        }
        if (BatteryLevel < 30)
        {
            RaiseAlert("Battery level is low.", AlertSeverity.Warning);
        }
    }

    public void CheckSignalQuality()
    {
        if (SignalQuality == 0)
        {
            RaiseAlert("Signal quality is critical.", AlertSeverity.Critical);
        }
        if (SignalQuality < 30)
        {
            RaiseAlert("Signal quality is low.", AlertSeverity.Warning);
        }
    }
}

