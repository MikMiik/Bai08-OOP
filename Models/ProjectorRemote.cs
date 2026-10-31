namespace Bai08.Models;

using Bai08.Enums;

public class ProjectorRemote : TeachingDevice
{
    public int BatteryLevel { get; private set; }

    public ProjectorRemote(string id, string name, int batteryLevel)
        : base(id, name)
    {
        if (batteryLevel < 0 || batteryLevel > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(batteryLevel), "Battery level must be between 0 and 100.");
        }
        BatteryLevel = batteryLevel;
    }
    public void UpdateBatteryLevel(int newLevel)
    {
        BatteryLevel = newLevel;
        CheckBatteryLevel();
    }

    public void CheckBatteryLevel()
    {
        if (BatteryLevel == 0)
        {
            RaiseAlert("Battery level is critical.", AlertSeverity.Critical);
        }
        if (BatteryLevel < 20)
        {
            RaiseAlert("Battery level is low.", AlertSeverity.Warning);
        }
    }

}