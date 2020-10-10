using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Format
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("qty")]
    public string Qty { get; set; }

    [JsonPropertyName("descriptions")]
    public IList<string> Descriptions { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}