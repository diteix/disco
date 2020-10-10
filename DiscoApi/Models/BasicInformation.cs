using System.Collections.Generic;
using System.Text.Json.Serialization;

public class BasicInformation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("master_id")]
    public int MasterId { get; set; }

    [JsonPropertyName("master_url")]
    public string MasterUrl { get; set; }

    [JsonPropertyName("resource_url")]
    public string ResourceUrl { get; set; }

    [JsonPropertyName("thumb")]
    public string Thumb { get; set; }

    [JsonPropertyName("cover_image")]
    public string CoverImage { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("formats")]
    public IList<Format> Formats { get; set; }

    [JsonPropertyName("labels")]
    public IList<Label> labels { get; set; }

    [JsonPropertyName("artists")]
    public IList<Artist> Artists { get; set; }

    [JsonPropertyName("genres")]
    public IList<string> Genres { get; set; }

    [JsonPropertyName("styles")]
    public IList<string> Styles { get; set; }
}