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
            throw new InvalidDeviceReadingException(id, batteryLevel);
        }
        BatteryLevel = batteryLevel;
    }
    public void UpdateBatteryLevel(int newLevel)
    {
        if (newLevel < 0 || newLevel > 100)
        {
            throw new InvalidDeviceReadingException(Id, newLevel);
        }
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