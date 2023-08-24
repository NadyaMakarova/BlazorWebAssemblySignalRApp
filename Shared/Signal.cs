namespace BlazorWebAssemblySignalRApp.Shared;

public class Signal
{
	public long Id { get; set; }

	public string? Formula { get; set; }

	public double Value { get; set; }

	public string? Quality { get; set; }

	public DateTime Date { get; set; }

	public TimeSpan Time { get; set; }

	public string? Type { get; set; }

	public string? Description { get; set; }

	public string? Procedure { get; set; }

	public string? Message { get; set; }

	public int? Sound { get; set; }
}
