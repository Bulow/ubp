using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Net;

namespace Ubp
{
    /// <summary>
    /// UBP: Unified Browser Protocol
    /// 
    /// Is a way for apps to open webpages in another "default" browser than internet explorer, by not telling the OS that this file is a webpage (http, https)
    /// </summary>
    public class UbpMapper : UriMapperBase
    {
        /// <summary>
        /// The name of the protocol as it is shown in encoded uris
        /// </summary>
        public const string PROTOCOL = "ubp";

        /// <summary>
        /// The key of the Uri query fragment that contains the url
        /// </summary>
        public const string QUERY_KEY = "ubpUrl";

        /// <summary>
        /// The "marker" that marks the beginning of the url in the navigation Uri given to MapUri(Uri uri)
        /// </summary>
        static string marker = QUERY_KEY + "=" + PROTOCOL + "%3A";

        /// <summary>
        /// The base uri of the page that recieves the url
        /// </summary>
        string baseUri;

        /// <summary>
        /// If the uri doesn't use the ubp protocol, the uri will be sent to this UriMapper
        /// </summary>
        public UriMapperBase secondaryUriMapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUri">The base uri of the page that recieves the url, eg: "/MainPage.xaml?url="</param>
        /// <param name="secondaryUriMapper">If the uri doesn't use the ubp protocol, the uri will be sent to this UriMapper</param>
        public UbpMapper(string baseUri, UriMapperBase secondaryUriMapper = null)
        {
            this.baseUri = baseUri;
            this.secondaryUriMapper = secondaryUriMapper;
        }



        public override Uri MapUri(Uri uri)
        {
            string encodedUriString = uri.ToString();
            

            //if the uri uses the ubp protocol
            if (encodedUriString.Contains(QUERY_KEY))
            {
                //Isolate the url
                string url = encodedUriString.Substring(encodedUriString.IndexOf(marker, StringComparison.InvariantCulture) + marker.Length);
                if (url.Contains("&")) url = url.Substring(0, url.IndexOf("&") + 1);

                Uri returnUri = new Uri(baseUri + HttpUtility.UrlDecode(url), UriKind.RelativeOrAbsolute);
                return returnUri;
            }

            else if (secondaryUriMapper != null)
            {
                //Map the uri with secondaryUriMapper, so the app can also handle other file types/protocols
                return secondaryUriMapper.MapUri(uri);
            }

            //No secondaryUriMapper supplied; return uri as it is
            return uri;
        }
    }
}
