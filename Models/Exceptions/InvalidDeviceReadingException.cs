namespace Bai08.Models;

public class InvalidDeviceReadingException : Exception
{
    public string DeviceId { get; }
    public int InvalidValue { get; }
    public InvalidDeviceReadingException(string deviceId, int invalidValue)
        : base($"Thiết bị '{deviceId}' có giá trị đọc không hợp lệ: {invalidValue}. Giá trị phải nằm trong khoảng 0–100.")
    {
        DeviceId = deviceId;
        InvalidValue = invalidValue;
    }
}