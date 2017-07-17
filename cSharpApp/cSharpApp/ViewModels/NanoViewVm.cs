using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cSharpApp.ViewModels
{
    public class NanoViewVm
    {
        //TODO: Let the view set this...
        private string _ethUri = "https://api.etherscan.io/api?module=stats&action=ethprice&apikey=YourApiKeyToken";
        public string EthUri
        {
            get
            {
                return _ethUri;
            }
            set
            {
                _ethUri = value;
                //Notify property changed.
            }
        }

        public NanoViewVm()
        {
            GetCurrentEthPrice();
        }

        public void GetCurrentEthPrice()
        {
            using(var webClient = new WebClient())
            {
                var json = webClient.DownloadString(_ethUri);
            }
        }
    }
}
