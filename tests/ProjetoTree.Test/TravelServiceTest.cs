using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using ProjetoTree.Business.Services;
using ProjetoTree.Data.Repository;
using Xunit;

namespace ProjetoTree.Test
{
    public class TravelServiceTest
    {
        [Fact]
        public void Should_Valid_When_NumberTravelsEqualsToNumberStarshipsVo()
        {
            var connectionMock = new Mock<IStarshipRepository>();

            connectionMock.Setup(p => p.GetAllData())
                .Returns(new List<StarshipVo>() { new StarshipVo(), new StarshipVo() });

            var repository = connectionMock.Object;

            TravelService travelService = new TravelService(connectionMock.Object);
            var travels = travelService.NumberOfStops(100);

            travels.Should().HaveCount(2);
        }

        [Fact]
        public void Should_ReturnNull_When_DistanceLessThanZero()
        {
            var connectionMock = new Mock<IStarshipRepository>();

            TravelService travelService = new TravelService(connectionMock.Object);
            var travels = travelService.FindStops(0, new Starship());

            travels.Should().Be(null);
        }

        [Fact]
        public void Should_NumberStops_When_DistanceGreaterThanZero()
        {
            double distance = 55;
            double _MGLT = 10;

            var connectionMock = new Mock<IStarshipRepository>();

            TravelService travelService = new TravelService(connectionMock.Object);
            var travels = travelService.FindStops(distance, new Starship() { MGLT = _MGLT });

            var stops = Math.Floor(distance / _MGLT);

            travels.stops.Should().Be(stops);
        }

        [Fact]
        public void Should_ReturnEmptyOrNull_When_SWAPIIsOff()
        {
            var connectionMock = new Mock<IRepository<StarshipVo>>();

            connectionMock.Setup(p =>p.GetAsyncRequestSWAPI())
                .Returns(new HttpResponseMessage(HttpStatusCode.NotFound));

            var repository = connectionMock.Object;
            var starships = repository.GetAllData();

            starships.Should().BeNullOrEmpty();
        }

        //[Fact]
        //public void Should_ReturnEmptyOrNull_When_SWAPIIsOn()
        //{
        //    var basegroup = new BaseGroups<StarshipVo>();
        //    basegroup.results = new List<StarshipVo>() { new StarshipVo() {name = "teste" } };

        //    string json = JsonConvert.SerializeObject(basegroup, Formatting.Indented);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    var httpresponse = new HttpResponseMessage();
        //    httpresponse.StatusCode = HttpStatusCode.OK;
        //    httpresponse.Content = content;

        //    var httpMock = new Mock<HttpClient>();
        //    httpMock.Setup(p => p.GetAsync("endpoint").Result)
        //    .Returns(httpresponse);

        //    var connectionMock = new Mock<IRepository<StarshipVo>>();

        //    connectionMock.Setup(p => p.GetAsyncRequestSWAPI())
        //        .Returns(httpMock.Object.GetAsync("endpoint").Result);

        //    var repository = connectionMock.Object;
        //    var starships = repository.GetAllData();

        //    starships.Should().NotBeNullOrEmpty();
        //}
    }
}
