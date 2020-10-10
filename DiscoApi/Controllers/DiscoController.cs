using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DiscoApi.Controllers
{
    [ApiController]
    [Route("")]
    public class DiscoController : ControllerBase
    {
        private static readonly string DiscogsUrl = "https://api.discogs.com/users/ausamerika/collection/folders/0/releases";
        private static readonly HttpClient httpClient = new HttpClient();

        [HttpGet]
        [Route("{numberOfItems:range(1,5)?}")]
        public async Task<IEnumerable<Release>> Get(int? numberOfItems = null)
        {
            var discogsResponse = await this.GetDiscogsData();

            var indexes = this.IndexOfItemsToReturn(numberOfItems, discogsResponse.Pagination.Items);

            return await this.FindReleases(indexes, discogsResponse.Releases);
        }

        private async Task<DiscogsResponse> GetDiscogsData(int? page = null) {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "DiscoApi/0.1 +https://github.com/diteix/disco");

            var url = DiscogsUrl;

            if (page.HasValue) {
                url += $"?page={page}";
            }

            var response = httpClient.GetStreamAsync(DiscogsUrl);

            return await JsonSerializer.DeserializeAsync<DiscogsResponse>(await response);
        }

        private IEnumerable<int> IndexOfItemsToReturn(int? numberOfItems, int totalOfItems) {
            var rng = new Random();

            if (!numberOfItems.HasValue) {
                numberOfItems = rng.Next(1,5);
            }

            return Enumerable.Range(0, numberOfItems.Value).Select(s => rng.Next(0, totalOfItems - 1));;
        }

        private async Task<IEnumerable<Release>> FindReleases(IEnumerable<int> indexes, IList<Release> releases) {
            return await Task.WhenAll(indexes.Select(async i => {
                if (i > releases.Count) {
                    var page = (i / releases.Count);

                    var discogsResponse = await this.GetDiscogsData(page  + 1);

                    return discogsResponse.Releases.ElementAt(i - page * releases.Count);
                }

                return releases.ElementAt(i);
            }));
        }
    }
}
