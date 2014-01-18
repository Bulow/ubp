using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Phone.Tasks
{
    public class AnyBrowserTask
    {
        
        #region Non-static
        //The non-static part is basically just to be consistent with Microsoft.Phone.Tasks.WebBrowserTask
        public string URL { get; set; }

        public Uri Uri
        {
            get
            {
                return new Uri(URL);
            }
            set
            {
                URL = value.ToString();
            }
        }
        
        public AnyBrowserTask(string url)
        {
            this.URL = url;
        }

        public AnyBrowserTask(Uri uri)
        {
            this.Uri = uri;
        }

        public async Task Show()
        {
            await AnyBrowserTask.Show(this.URL);
        }
        #endregion

        #region Static
        public static async Task Show(string url)
        {
            //Launch using UBP
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri(Ubp.UbpMapper.PROTOCOL + ":" + url, UriKind.Absolute));

            //If it failed, launch using IE.
            if (!result)
            {
                WebBrowserTask task = new WebBrowserTask();
                task.Uri = new Uri(url);
                task.Show();
            }
        }

        public static async Task Show(Uri uri)
        {
            await Show(uri.ToString());
        }
        #endregion
    }
}
