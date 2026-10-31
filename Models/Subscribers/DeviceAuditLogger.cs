namespace Bai08.Models;

public class DeviceAuditLogger
{
    private readonly List<string> entries = new();
    public IReadOnlyList<string> Entries => entries.AsReadOnly();
    public void HandleStatusChanged(
    object? sender,
    DeviceStatusChangedEventArgs e)
    {
        entries.Add(
        $"{e.ChangedAt}: {e.DeviceId}, " +
        $"{e.OldStatus} -> {e.NewStatus}");
        Console.WriteLine($"Status changed: {e.ChangedAt}: {e.DeviceId}, {e.OldStatus} -> {e.NewStatus}");
    }
}
