using System.Text.Json.Serialization;

public class Label
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("catno")]
    public string Catno { get; set; }

    [JsonPropertyName("entity_type")]
    public string EntityType { get; set; }

    [JsonPropertyName("entity_type_name")]
    public string EntityTypeName { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("resource_url")]
    public string ResourceUrl { get; set; }
}