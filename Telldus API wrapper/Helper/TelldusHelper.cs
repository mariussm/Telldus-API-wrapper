using DevDefined.OAuth.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Telldus_API_wrapper.Models;

namespace Telldus_API_wrapper.Helper
{
    public class TelldusHelper
    {
        String ConsumerKey, ConsumerSecret, Token, TokenSecret;

        public TelldusHelper(String ConsumerKey, String ConsumerSecret, String Token, String TokenSecret)
        {
            this.ConsumerKey = ConsumerKey;
            this.ConsumerSecret = ConsumerSecret;
            this.Token = Token;
            this.TokenSecret = TokenSecret;
        }
        private DevDefined.OAuth.Consumer.ConsumerRequest NewRequest()
        {
            DevDefined.OAuth.Consumer.OAuthConsumerContext context = new DevDefined.OAuth.Consumer.OAuthConsumerContext();
            context.ConsumerKey = ConsumerKey;
            context.ConsumerSecret = ConsumerSecret;
            context.SignatureMethod = DevDefined.OAuth.Framework.SignatureMethod.HmacSha1;

            DevDefined.OAuth.Framework.TokenBase accessToken = new DevDefined.OAuth.Framework.TokenBase();
            accessToken.ConsumerKey = ConsumerKey;
            accessToken.Token = Token;
            accessToken.TokenSecret = TokenSecret;

            OAuthSession session = new OAuthSession(context); // nullString, nullString, nullString);
            return (ConsumerRequest) session.Request(accessToken);
        }

        internal bool SetSwitchState(string id, string state)
        {
            ConsumerRequest request = NewRequest();
            request.Context.RequestMethod = "GET";
            request.Context.RawUri = GetUri("device/" + (state == "on" ? "turnOn" : "turnOff") + "?id=" + id);
            String body = DevDefined.OAuth.Consumer.ConsumerRequestExtensions.ReadBody(request);
            return body.Contains("success"); // .Equals("{\"status\":\"success\"}");
        }

        internal TelldusDeviceList GetDevices()
        {
            ConsumerRequest request = NewRequest();
            request.Context.RequestMethod = "GET";
            request.Context.RawUri = GetUri("devices/list?supportedMethods=19");

            String body = DevDefined.OAuth.Consumer.ConsumerRequestExtensions.ReadBody(request);
            return new JavaScriptSerializer().Deserialize<TelldusDeviceList>(body); 
        }

        internal TelldusSensor GetSensorData(string id)
        {
            ConsumerRequest request = NewRequest();
            request.Context.RequestMethod = "GET";
            request.Context.RawUri = GetUri("sensor/info?id=" + id);

            String body = DevDefined.OAuth.Consumer.ConsumerRequestExtensions.ReadBody(request);
            return new JavaScriptSerializer().Deserialize<TelldusSensor>(body);
        }

        //public String GetSensors()
        public TelldusSensorList GetSensors()
        {
            ConsumerRequest request = NewRequest();
            request.Context.RequestMethod = "GET";
            request.Context.RawUri = GetUri("sensors/list");

            String body = DevDefined.OAuth.Consumer.ConsumerRequestExtensions.ReadBody(request);
            return new JavaScriptSerializer().Deserialize<TelldusSensorList>(body);
            //return body;
        }

        public Uri GetUri(string suffix)
        {
            //return new Uri("http://api.telldus.com/xml/" + suffix);
            return new Uri("http://api.telldus.com/json/" + suffix);
        }
    }
}