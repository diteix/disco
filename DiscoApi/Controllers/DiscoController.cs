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
        private static readonly string DISCOGS_URL = "https://api.discogs.com/users/ausamerika/collection/folders/0/releases";
        private readonly IHttpClientFactory _httpClientFactory;  
  
        public DiscoController(IHttpClientFactory httpClientFactory)  
        {  
            _httpClientFactory = httpClientFactory;  
        }

        [HttpGet]
        [Route("{numberOfItems:range(1,5)?}")]
        public async Task<ActionResult<IEnumerable<Release>>> Get(int? numberOfItems = null) 
        {
            using(var httpClient = this._httpClientFactory.CreateClient("discogs")) 
            {
                var discogsResponse = await this.GetDiscogsData(httpClient);

                var indexes = this.IndexOfItemsToReturn(numberOfItems, discogsResponse.Pagination.Items);

                return Ok(await this.FindReleases(httpClient, indexes, discogsResponse.Releases));
            }
        }

        private async Task<DiscogsResponse> GetDiscogsData(HttpClient httpClient, int? page = null) {
            var url = DISCOGS_URL;

            if (page.HasValue) 
            {
                url += $"?page={page}";
            }

            var response = httpClient.GetStreamAsync(DISCOGS_URL);

            return await JsonSerializer.DeserializeAsync<DiscogsResponse>(await response);
        }

        private IEnumerable<int> IndexOfItemsToReturn(int? numberOfItems, int totalOfItems) 
        {
            var rng = new Random();

            if (!numberOfItems.HasValue || numberOfItems.Value <= 0 || numberOfItems.Value > 5) 
            {
                numberOfItems = rng.Next(1,5);
            }

            return Enumerable.Range(0, numberOfItems.Value).Select(s => rng.Next(0, totalOfItems - 1));
        }

        private async Task<IEnumerable<Release>> FindReleases(HttpClient httpClient, IEnumerable<int> indexes, IList<Release> releases) 
        {
            return await Task.WhenAll(indexes.Select(async i => 
            {
                if (i > releases.Count) 
                {
                    var page = (i / releases.Count);

                    var discogsResponse = await this.GetDiscogsData(httpClient, page  + 1);

                    return discogsResponse.Releases.ElementAt(i - page * releases.Count);
                }

                return releases.ElementAt(i);
            }));
        }
    }
}
