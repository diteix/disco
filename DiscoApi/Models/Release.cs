using System;
using System.Text.Json.Serialization;

public class Release
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("instance_id")]
    public int InstanceId { get; set; }

    [JsonPropertyName("date_added")]
    public DateTime DateAdded { get; set; }

    [JsonPropertyName("rating")]
    public int Rating { get; set; }

    [JsonPropertyName("basic_information")]
    public BasicInformation BasicInformation { get; set; }
}