namespace Bai08.Models;

public class DeviceMonitoringCoordinator : IDisposable
{
    private readonly List<TeachingDevice> devices;
    private readonly ConsoleNotificationService notificationService;
    private readonly DeviceAuditLogger auditLogger;
    private readonly MaintenanceService maintenanceService;

    private bool isSubscribed;
    public DeviceMonitoringCoordinator(
    IEnumerable<TeachingDevice> devices,
    ConsoleNotificationService notificationService,
    DeviceAuditLogger auditLogger,
    MaintenanceService maintenanceService)
    {
        this.devices = devices.ToList();
        this.notificationService = notificationService;
        this.auditLogger = auditLogger;
        this.maintenanceService = maintenanceService;
    }
    public void Subscribe()
    {
        if (isSubscribed) return;
        foreach (var device in devices)
        {
            device.AlertRaised += maintenanceService.HandleCriticalAlert;
            device.StatusChanged += auditLogger.HandleStatusChanged;
            device.AlertRaised += notificationService.HandleAlert;
        }
        isSubscribed = true;
    }
    public void Unsubscribe()
    {
        if (!isSubscribed) return;
        foreach (var device in devices)
        {
            device.AlertRaised -= maintenanceService.HandleCriticalAlert;
            device.StatusChanged -= auditLogger.HandleStatusChanged;
            device.AlertRaised -= notificationService.HandleAlert;
        }
        isSubscribed = false;
    }
    public void Dispose()
    {
        Unsubscribe();
    }
}