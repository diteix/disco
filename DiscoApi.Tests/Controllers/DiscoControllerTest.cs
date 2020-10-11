using Xunit;
using DiscoApi.Controllers;
using Moq;
using System.Net.Http;
using Moq.Protected;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DiscoApi.Tests
{
    public class DiscoControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public async Task Get_Qty_Equal_Number(int? numberOfItems)
        {
            var result =  await this.CreateController().Get(numberOfItems);  
  
            Assert.Equal(numberOfItems, ((IEnumerable<Release>)((OkObjectResult)result.Result).Value).Count());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(6)]
        public async Task Get_Random_Qty(int? numberOfItems)
        {
            var result =  await this.CreateController().Get(numberOfItems);  
  
            Assert.InRange<int>(((IEnumerable<Release>)((OkObjectResult)result.Result).Value).Count(), 1, 5);
        }

        private DiscoController CreateController() {
            var httpClientFactory = new Mock<IHttpClientFactory>();  
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())  
            .ReturnsAsync(new HttpResponseMessage  
            {  
                StatusCode = HttpStatusCode.OK,  
                Content = new StringContent("{\"pagination\": {\"page\": 1, \"pages\": 1, \"per_page\": 5, \"items\": 5, \"urls\": {\"last\": \"https://api.discogs.com/users/ausamerika/collection/folders/0/releases?per_page=5&page=340\", \"next\": \"https://api.discogs.com/users/ausamerika/collection/folders/0/releases?per_page=5&page=2\"}}, \"releases\": [{\"id\": 5565214, \"instance_id\": 221498471, \"date_added\": \"2017-03-26T18:58:36-07:00\", \"rating\": 0, \"basic_information\": {\"id\": 5565214, \"master_id\": 119112, \"master_url\": \"https://api.discogs.com/masters/119112\", \"resource_url\": \"https://api.discogs.com/releases/5565214\", \"thumb\": \"\", \"cover_image\": \"\", \"title\": \"Photographs & Memories: His Greatest Hits\", \"year\": 1985, \"formats\": [{\"name\": \"Cassette\", \"qty\": \"1\", \"descriptions\": [\"Compilation\"]}], \"labels\": [{\"name\": \"21 Records\", \"catno\": \"7 90467-4-Y\", \"entity_type\": \"1\", \"entity_type_name\": \"Label\", \"id\": 5795, \"resource_url\": \"https://api.discogs.com/labels/5795\"}, {\"name\": \"21 Records\", \"catno\": \"90467-4-Y\", \"entity_type\": \"1\", \"entity_type_name\": \"Label\", \"id\": 5795, \"resource_url\": \"https://api.discogs.com/labels/5795\"}], \"artists\": [{\"name\": \"Jim Croce\", \"anv\": \"\", \"join\": \"\", \"role\": \"\", \"tracks\": \"\", \"id\": 291337, \"resource_url\": \"https://api.discogs.com/artists/291337\"}], \"genres\": [\"Rock\"], \"styles\": [\"Folk Rock\"]}}, {\"id\": 1910042, \"instance_id\": 174261868, \"date_added\": \"2016-05-30T07:46:32-07:00\", \"rating\": 0, \"basic_information\": {\"id\": 1910042, \"master_id\": 34442, \"master_url\": \"https://api.discogs.com/masters/34442\", \"resource_url\": \"https://api.discogs.com/releases/1910042\", \"thumb\": \"\", \"cover_image\": \"\", \"title\": \"Four\", \"year\": 1994, \"formats\": [{\"name\": \"CD\", \"qty\": \"1\", \"descriptions\": [\"Album\", \"Club Edition\"]}], \"labels\": [{\"name\": \"A&M Records\", \"catno\": \"31454 0265 2\", \"entity_type\": \"1\", \"entity_type_name\": \"Label\", \"id\": 904, \"resource_url\": \"https://api.discogs.com/labels/904\"}], \"artists\": [{\"name\": \"Blues Traveler\", \"anv\": \"\", \"join\": \"\", \"role\": \"\", \"tracks\": \"\", \"id\": 288326, \"resource_url\": \"https://api.discogs.com/artists/288326\"}], \"genres\": [\"Rock\", \"Blues\"], \"styles\": [\"Alternative Rock\", \"Harmonica Blues\", \"Pop Rock\"]}}, {\"id\": 7564258, \"instance_id\": 171219123, \"date_added\": \"2016-05-07T13:35:07-07:00\", \"rating\": 0, \"basic_information\": {\"id\": 7564258, \"master_id\": 57940, \"master_url\": \"https://api.discogs.com/masters/57940\", \"resource_url\": \"https://api.discogs.com/releases/7564258\", \"thumb\": \"\", \"cover_image\": \"\", \"title\": \"The Six Wives Of Henry VIII\", \"year\": 2015, \"formats\": [{\"name\": \"CD\", \"qty\": \"1\", \"descriptions\": [\"Album\", \"Reissue\"]}, {\"name\": \"DVD\", \"qty\": \"1\", \"descriptions\": [\"DVD-Audio\", \"DVD-Video\", \"Multichannel\", \"NTSC\", \"Album\", \"Stereo\", \"Quadraphonic\"]}, {\"name\": \"All Media\", \"qty\": \"1\", \"text\": \"Four-panel Digipak.\", \"descriptions\": [\"Deluxe Edition\", \"Limited Edition\"]}], \"labels\": [{\"name\": \"A&M Records\", \"catno\": \"5356238\", \"entity_type\": \"1\", \"entity_type_name\": \"Label\", \"id\": 904, \"resource_url\": \"https://api.discogs.com/labels/904\"}], \"artists\": [{\"name\": \"Rick Wakeman\", \"anv\": \"\", \"join\": \"\", \"role\": \"\", \"tracks\": \"\", \"id\": 149420, \"resource_url\": \"https://api.discogs.com/artists/149420\"}], \"genres\": [\"Electronic\", \"Rock\"], \"styles\": [\"Art Rock\", \"Prog Rock\", \"Classic Rock\"]}}, {\"id\": 7564258, \"instance_id\": 171219131, \"date_added\": \"2016-05-07T13:35:08-07:00\", \"rating\": 0, \"basic_information\": {\"id\": 7564258, \"master_id\": 57940, \"master_url\": \"https://api.discogs.com/masters/57940\", \"resource_url\": \"https://api.discogs.com/releases/7564258\", \"thumb\": \"\", \"cover_image\": \"\", \"title\": \"The Six Wives Of Henry VIII\", \"year\": 2015, \"formats\": [{\"name\": \"CD\", \"qty\": \"1\", \"descriptions\": [\"Album\", \"Reissue\"]}, {\"name\": \"DVD\", \"qty\": \"1\", \"descriptions\": [\"DVD-Audio\", \"DVD-Video\", \"Multichannel\", \"NTSC\", \"Album\", \"Stereo\", \"Quadraphonic\"]}, {\"name\": \"All Media\", \"qty\": \"1\", \"text\": \"Four-panel Digipak.\", \"descriptions\": [\"Deluxe Edition\", \"Limited Edition\"]}], \"labels\": [{\"name\": \"A&M Records\", \"catno\": \"5356238\", \"entity_type\": \"1\", \"entity_type_name\": \"Label\", \"id\": 904, \"resource_url\": \"https://api.discogs.com/labels/904\"}], \"artists\": [{\"name\": \"Rick Wakeman\", \"anv\": \"\", \"join\": \"\", \"role\": \"\", \"tracks\": \"\", \"id\": 149420, \"resource_url\": \"https://api.discogs.com/artists/149420\"}], \"genres\": [\"Electronic\", \"Rock\"], \"styles\": [\"Art Rock\", \"Prog Rock\", \"Classic Rock\"]}}, {\"id\": 6586293, \"instance_id\": 137940751, \"date_added\": \"2015-08-15T19:37:06-07:00\", \"rating\": 0, \"basic_information\": {\"id\": 6586293, \"master_id\": 57940, \"master_url\": \"https://api.discogs.com/masters/57940\", \"resource_url\": \"https://api.discogs.com/releases/6586293\", \"thumb\": \"\", \"cover_image\": \"\", \"title\": \"The Six Wives Of Henry VIII\", \"year\": 2014, \"formats\": [{\"name\": \"Vinyl\", \"qty\": \"1\", \"descriptions\": [\"LP\", \"Album\", \"Reissue\"]}], \"labels\": [{\"name\": \"A&M Records\", \"catno\": \"5356248\", \"entity_type\": \"1\", \"entity_type_name\": \"Label\", \"id\": 904, \"resource_url\": \"https://api.discogs.com/labels/904\"}], \"artists\": [{\"name\": \"Rick Wakeman\", \"anv\": \"\", \"join\": \"\", \"role\": \"\", \"tracks\": \"\", \"id\": 149420, \"resource_url\": \"https://api.discogs.com/artists/149420\"}], \"genres\": [\"Electronic\", \"Rock\"], \"styles\": [\"Modern Classical\", \"Prog Rock\"]}}]}")
            });
            
            var client = new HttpClient(mockHttpMessageHandler.Object);   
            httpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(client);  
  
            return new DiscoController(httpClientFactory.Object);
        }
    }
}
