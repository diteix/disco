using System.Collections.Generic;
using System.Text.Json.Serialization;

public class DiscogsResponse
{
    [JsonPropertyName("pagination")]
    public Pagination Pagination { get; set; }

    [JsonPropertyName("releases")]
    public IList<Release> Releases { get; set; }
}