using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DirectoryApp.Models.GitHub
{
    public class Commit
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
    public class TagResponseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("commit")]
        public Commit Commit { get; set; }
        [JsonPropertyName("zipball_url")]
        public string ZipballUrl { get; set; }
        [JsonPropertyName("tarball_url")]
        public string TarballUrl { get; set; }
        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }
    }
}