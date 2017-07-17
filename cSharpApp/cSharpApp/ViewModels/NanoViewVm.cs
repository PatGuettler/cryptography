using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cSharpApp.ViewModels
{
    public class NanoViewVm
    {

        //TODO: Let the view set this...
        private string _ethUri = "https://api.etherscan.io/api?module=stats&action=ethprice&apikey=YourApiKeyToken";
        private string _sixHourAvgHash = "https://api.nanopool.org/v1/eth/avghashratelimited/replaceMe/6";
        private string _accountData = "https://api.nanopool.org/v1/eth/user/replaceMe";
        
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

        private string _accountNumber = string.Empty;
        public string AccountNumber { get { return _accountNumber; } }

        private string _ethUsd = string.Empty;
        public string EthUsd { get { return _ethUsd; } }

        private string _avgHash = string.Empty;
        public string AvgHash { get { return _avgHash; } }

        private string _accountBalance = string.Empty;
        public string AccountBalance { get { return _accountBalance; } }

        public NanoViewVm()
        {
            GetCurrentEthPrice();
            GetNanoPoolInfo();
            GetAccountData();
        }

        public void GetCurrentEthPrice()
        {
            using(var webClient = new WebClient())
            {
                var json = webClient.DownloadString(_ethUri);
                EthStuff ethStuff = JsonConvert.DeserializeObject<EthStuff>(json);
                _ethUsd = "$" + ethStuff.result.ethusd;                
            }
        }

        private void GetNanoPoolInfo()
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(_sixHourAvgHash);
                HashStuff hashStuff = JsonConvert.DeserializeObject<HashStuff>(json);
                var sub = hashStuff.data.Remove(hashStuff.data.Length - 12);
                _avgHash = sub + " MH/s";
            }
        }

        private void GetAccountData()
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(_accountData);
                AccountStuff accountStuff = JsonConvert.DeserializeObject<AccountStuff>(json);
                _accountBalance = accountStuff.data.balance;
            }
        }
    }

    internal class AccountStuff
    {
        public AccountData data {get; set;}
    }

    internal class AccountData
    {
        public string balance { get; set; }
    }

    internal class HashStuff
    {
        public string data { get; set; }
    }

    //TODO: Move this
    internal class EthStuff
    {
        public string status { get; set; }
        public string message { get; set; }
        public eth result { get; set; }
    }

    //TODO: Move this, too
    internal class eth
    {
        public string ethbtc { get; set; }
        public string ethusd { get; set; }
    }
}
