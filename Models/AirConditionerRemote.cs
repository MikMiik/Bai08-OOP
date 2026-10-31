namespace Bai08.Models;

using Bai08.Enums;
public class AirConditionerRemote : TeachingDevice
{
    public string AssignedRoom { get; }
    public bool IsResponsive { get; private set; }

    public AirConditionerRemote(string id, string name, string assignedRoom)
    : base(id, name)
    {
        AssignedRoom = assignedRoom;
        IsResponsive = true;
    }
    public void UpdateResponseState(bool isResponsive)
    {
        bool oldState = IsResponsive;
        IsResponsive = isResponsive;
        if (oldState != IsResponsive && !IsResponsive)
        {
            RaiseAlert("Air conditioner is no longer responsive.", AlertSeverity.Critical);
        }
    }
}