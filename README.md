# PelikanSmsNetSendApi
pelikansms.net Sms Send Api Class

Temel İstek Adresleri

		//Ana Kategori Linkleri...
        string urlsendmesaj = "https://panel.pelikansms.net/api/v1/sms/send?apikey=";
        string urlrapor = "https://panel.pelikansms.net/api/v1/sms/reports/";
        string urlkredisorgu = "https://panel.pelikansms.net/api/v1/user/profileDetails?apikey=";
		//Ana Kategori Linkleri...	
  
 Mesaj Yollama Metodu
 
  		//Mesaj Yollama Metodu....
        public string  EB_MesajYolla( string apikey, string encoding, string title, string numbers, string mesaj)
        {
            urlsendmesaj += "" + apikey + "&encoding=" + encoding + "&title=" + title + "&numbers=" + numbers + "&message=" + mesaj + "";
            return getistegiii(urlsendmesaj);
        }
		//Mesaj Yollama Metodu...	
  
  İstek Yollama Metodu
  
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
  
  Raporlama Metodu
   
     //Raporlama Metodu...
        public string  EB_MesajRaporla(string apikey,int RaporID)
        {
            urlrapor += RaporID + "?apikey=" + apikey;
            return getistegiii(urlrapor);
        }
		  //Raporlama Metodu...
   
  Kredi Sorgulama Metodu
  
  		//Kredi Sorgulama Metodu...
        public string  EB_Kredisorgula(string apikey)
        {
            urlkredisorgu +=  apikey;
            return getistegiii(urlkredisorgu);
        }
		//Kredi Sorgulama Metodu...
