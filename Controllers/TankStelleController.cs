using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GeoJSON.Net.Geometry;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GasStation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class GasStationController : ControllerBase
    {
        private static HttpClient _client;
        private const string URL = "https://geoportal.stadt-koeln.de/arcgis/rest/services/Gefahrgutstrecken/MapServer/0/query?where=objectid+is+not+null&text=&objectIds=&time=&geometry=&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelIntersects&relationParam=&outFields=*&returnGeometry=true&returnTrueCurves=false&maxAllowableOffset=&geometryPrecision=&outSR=4326&returnIdsOnly=false&returnCountOnly=false&orderByFields=&groupByFieldsForStatistics=&outStatistics=&returnZ=false&returnM=false&gdbVersion=&returnDistinctValues=false&resultOffset=&resultRecordCount=&f=pjson"; 
        public GasStationController(ILogger<GasStationController> logger)
        {
            _client = new HttpClient();
        }

        [HttpGet]
        [EnableQuery()]
        /// <summary>
        /// OData Endpoint for Gas Stations in Cologne
        /// </summary>
        /// <returns>A list of Gas Stations</returns>
        public async Task<IEnumerable<GasStationResult>> Get()
        {

            HttpResponseMessage response = await _client.GetAsync(URL);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            GasStationResponse tankstelle = JsonConvert.DeserializeObject<GasStationResponse>(jsonResponse);


            return tankstelle.features.Select(x => new GasStationResult(x.attributes.ADRESSE)
            {
                Id = x.attributes.OBJECTID,
                Latitude = string.Format("{0:0.00000}", x.geometry.x),
                Longtitude = string.Format("{0:0.00000}", x.geometry.y)
            }).ToList();
        }
    }
}
