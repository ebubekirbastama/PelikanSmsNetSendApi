using System.IO;
using System.Net;

  //Bu Class By & Ebubekir Bastama tarafın'dan 'pelikansms.net' sitesinin Sms Hizmetlerini rahat bir şekilde kullanabilmeniz için kodlanmıştır.
  //Crm'leriniz veya otomasyonlarınız'da kullanabilirsiniz. 
  //Ücretli Destek için 05554128854 ulaşabilirsiniz.
  //Whatshapp : https://pintimarket.com/syhmhf/
  //Twitter   : https://twitter.com/ebubekirbastama
  //Linkedin  : https://www.linkedin.com/in/ebubekirbastama/
  //Youtube   : https://www.youtube.com/user/yazilimegitim
namespace PelikanSmsApi
{
    public class Api
    {
		//Ana Kategori Linkleri...
        string urlsendmesaj = "https://panel.pelikansms.net/api/v1/sms/send?apikey=";
        string urlrapor = "https://panel.pelikansms.net/api/v1/sms/reports/";
        string urlkredisorgu = "https://panel.pelikansms.net/api/v1/user/profileDetails?apikey=";
		//Ana Kategori Linkleri...		
		//Mesaj Yollama Metodu....
        public string  EB_MesajYolla( string apikey, string encoding, string title, string numbers, string mesaj)
        {
            urlsendmesaj += "" + apikey + "&encoding=" + encoding + "&title=" + title + "&numbers=" + numbers + "&message=" + mesaj + "";
            return getistegiii(urlsendmesaj);
        }
		//Mesaj Yollama Metodu...		
		//İstek Yollama Metodu...
        private string  getistegiii(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
            string result;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            return result;
        }
		//İstek Yollama Metodu...
		//Raporlama Metodu...
        public string  EB_MesajRaporla(string apikey,int RaporID)
        {
            urlrapor += RaporID + "?apikey=" + apikey;
            return getistegiii(urlrapor);
        }
		//Raporlama Metodu...
		//Kredi Sorgulama Metodu...
        public string  EB_Kredisorgula(string apikey)
        {
            urlkredisorgu +=  apikey;
            return getistegiii(urlkredisorgu);
        }
		//Kredi Sorgulama Metodu...
    }
}
