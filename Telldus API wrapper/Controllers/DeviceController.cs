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

        public bool Post(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret, String id, String state)
        //public TelldusSensor[] Get(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret)
        {
            TelldusHelper Helper = new TelldusHelper(ConsumerKey, ConsumerSecret, Token, TokenSecret);
            return Helper.SetSwitchState(id, state);
                
        }

        public bool Post(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret, String id, int level)
        {
            TelldusHelper Helper = new TelldusHelper(ConsumerKey, ConsumerSecret, Token, TokenSecret);
            if (level >= 100)
            {
                return Helper.SetSwitchState(id, "on");
            }
            else if (level <= 0)
            {
                return Helper.SetSwitchState(id, "off");
            }
            else
            {
                double dlevel = (((double)level) / ((double)100))* ((double)255);
                return Helper.SetDimmerState(id, (int) dlevel);
            }

        }
    }
}
