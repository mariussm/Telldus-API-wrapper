using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Telldus_API_wrapper.Helper;
using Telldus_API_wrapper.Models;

namespace Telldus_API_wrapper.Controllers
{
    public class DeviceController : ApiController
    {
        public TelldusDeviceList Get(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret)
        //public TelldusSensor[] Get(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret)
        {
            TelldusHelper Helper = new TelldusHelper(ConsumerKey, ConsumerSecret, Token, TokenSecret);
            TelldusDeviceList list = Helper.GetDevices();

            return list;
        }
    }
}
