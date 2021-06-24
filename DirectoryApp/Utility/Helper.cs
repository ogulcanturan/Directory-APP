using DirectoryApp.Models;
using DirectoryApp.Models.GitHub;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DirectoryApp.Utility
{
    public class Helper
    {
        public static readonly HttpClient httpClient = new HttpClient();
        public const string projectApiUrl = "https://api.github.com/repos/ogulcanturan/DirectoryApp-WPF/";

        public static async Task<bool?> IsProjectUpToDateAsync(CancellationToken cancellationToken = default)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri($"{projectApiUrl}tags?per_page=1&page=1"),
                Method = HttpMethod.Get,
                Headers =
                {
                    { "accept", "application/vnd.github.v3+json" },
                    { "user-agent", "core.js" }
                }
            };

            try
            {
                Task<HttpResponseMessage> response = httpClient.SendAsync(httpRequestMessage, cancellationToken);
                var result = (await response).Content.ReadAsStringAsync();
                var lastTag = JsonSerializer.Deserialize<TagResponseModel[]>(await result)[0];
                return BuildInfo.Instance.Tag == lastTag.Name;
            }
            catch (HttpRequestException)
            {
                MessageBoxResult result = MessageBox.Show(
                "Internet connection isn't available or host not responding. Please try again later.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                return null;
            }
            catch (JsonException)
            {
                MessageBoxResult result = MessageBox.Show(
                "Too many requests have been applied. Therefore, you cannot check updates for now. Please try again later.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                return null;
            }
        }

    }
}
