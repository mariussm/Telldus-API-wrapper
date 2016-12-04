using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Telldus_API_wrapper.Helper;
using Telldus_API_wrapper.Models;

namespace Telldus_API_wrapper.Controllers
{
    public class SensorController : ApiController
    {
        // GET: api/Sensor
        public TelldusSensorList Get(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret)
        //public TelldusSensor[] Get(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret)
        {
            TelldusHelper Helper = new TelldusHelper(ConsumerKey, ConsumerSecret, Token, TokenSecret);
            TelldusSensorList list =  Helper.GetSensors();

            return list;
        }

        /*
        // GET: api/Sensor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sensor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sensor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sensor/5
        public void Delete(int id)
        {
        }*/
    }
}
