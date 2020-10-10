using System.Text.Json.Serialization;

public class Pagination
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    
    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("items")]
    public int Items { get; set; }

    [JsonPropertyName("urls")]
    public DiscogsUrl Urls { get; set; }
}