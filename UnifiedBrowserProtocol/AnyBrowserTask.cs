using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Phone.Tasks
{
    public class AnyBrowserTask
    {
        
        #region Dynamic
        string Url { get; set; }

        public AnyBrowserTask(string url)
        {
            this.Url = url;
        }

        public async Task Show()
        {
            await AnyBrowserTask.Show(this.Url);
        }
        #endregion

        #region Static
        public static async Task Show(string url)
        {
            
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri(Ubp.UbpMapper.PROTOCOL + ":" + url, UriKind.Absolute));
            if (!result)
            {
                WebBrowserTask t = new WebBrowserTask();
                t.URL = url;
                t.Show();
            }

            
        }

        #endregion
    }
}
