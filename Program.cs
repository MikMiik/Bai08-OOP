using Bai08.Models;
using Bai08.Enums;

/*  
202418946
Phạm Văn Minh
*/

ProjectorRemote projectorRemote = new("PR001", "Projector Remote", 50);
AirConditionerRemote airConditionerRemote = new("AC001", "Air Conditioner Remote", "Room 1");
WirelessMicrophone wirelessMicrophone = new("WM001", "Wireless Microphone", 80, 10);
DeviceMonitoringCoordinator coordinator = new([projectorRemote, airConditionerRemote, wirelessMicrophone],
    new ConsoleNotificationService(),
    new DeviceAuditLogger(),
    new MaintenanceService());
coordinator.Subscribe();
// Test Case 1: Đổi trạng thái thiết bị và lưu Audit Log
Console.WriteLine("Test Case 1: Đổi trạng thái thiết bị và lưu Audit Log");
projectorRemote.ChangeStatus(DeviceStatus.Borrowed);
airConditionerRemote.ChangeStatus(DeviceStatus.UnderMaintenance);
// Test Case 2: Bỏ qua phát sinh Event khi trạng thái không đổi
Console.WriteLine("Test Case 2: Bỏ qua phát sinh Event khi trạng thái không đổi");
projectorRemote.ChangeStatus(DeviceStatus.Borrowed);
// Test Case 3: Cảnh báo mức pin thấp của Remote máy chiếu
Console.WriteLine("Test Case 3: Cảnh báo mức pin thấp của Remote máy chiếu");
projectorRemote.UpdateBatteryLevel(15);
// Test Case 4: Xử lý cảnh báo AC không phản hồi
Console.WriteLine("Test Case 4: Xử lý cảnh báo thiết bị ngắt kết nối / không phản hồi");
airConditionerRemote.UpdateResponseState(false);
// Test Case 5: Cảnh báo đa điều kiện trên Wireless Microphone
Console.WriteLine("Test Case 5: Cảnh báo đa điều kiện trên Wireless Microphone");
wirelessMicrophone.UpdateBatteryLevel(5);
wirelessMicrophone.UpdateSignalQuality(0);
// Test Case 6: Lọc thông báo với Custom Delegate (FilteredAlertSubscriber)
Console.WriteLine("Test Case 6: Lọc thông báo với Custom Delegate (FilteredAlertSubscriber)");
WirelessMicrophone wirelessMicrophone2 = new("WM002", "Wireless Microphone", 70, 50);
FilteredAlertSubscriber filteredSubscriber = new(alert => alert.Severity == AlertSeverity.Critical, alert => Console.WriteLine($"ALERT: {alert.Message}"));
wirelessMicrophone2.AlertRaised += filteredSubscriber.HandleAlert;
wirelessMicrophone2.UpdateBatteryLevel(40);
wirelessMicrophone2.UpdateBatteryLevel(0);
// Test Case 7: Hủy đăng ký sự kiện và giải phóng tài nguyên (Unsubscribe & Dispose)
Console.WriteLine("Test Case 8: Hủy đăng ký sự kiện và giải phóng tài nguyên (Unsubscribe & Dispose)");
coordinator.Unsubscribe();
wirelessMicrophone.UpdateBatteryLevel(0);
// Test Case 8: Validation dữ liệu đầu vào và ném ngoại lệ InvalidDeviceReadingException
Console.WriteLine("Test Case 8: Validation dữ liệu đầu vào và ném ngoại lệ InvalidDeviceReadingException");
try
{
    wirelessMicrophone.UpdateBatteryLevel(150);
}
catch (InvalidDeviceReadingException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

