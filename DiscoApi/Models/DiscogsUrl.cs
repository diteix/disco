using System.Text.Json.Serialization;

public class DiscogsUrl
{
    [JsonPropertyName("last")]
    public string Last { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }
}