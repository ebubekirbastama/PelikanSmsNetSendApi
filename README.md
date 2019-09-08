# PelikanSmsNetSendApi
pelikansms.net Sms Send Api Class

Temel İstek Adresi: 
https://panel.pelikansms.net/api/v1/
Tüm istekleri buraya yapıyoruz. Bu adresin sonuna yapılacak işleme göre parametreler ekleniyor. Örneğin SMS göndermek için https://panel.pelikansms.net/api/v1/sms/send/normal şeklinde kullanmamız gerekiyor. 
Url Üzerin'den işlemler:
1.	Mesaj Gönderme.
2.	Rapor Sorgulama.
3.	Kredi Sorgulama.
4.	Dönüş bilgisi her zaman JSON'dır.
Standart BAŞARILI Dönüş
 Her istekten bir status parametresi döner ve eğer başarılıysa bu parametre success değerine sahiptir. 
Örneğin: { "status": "success" } 
Standart HATA dönüşü:
 Tüm isteklerden HTTP STATUS 200 döner ama içerdiği JSON ifadesinde hata bilgileri dönebilir. 
Örneğin: { "status": "error", "errorMessage": "Kullanıcı doğrulanamadı.", "errorCode": 3 }

SMS GÖNDERMEK
İstek Adresi:
 https://panel.pelikansms.net/api/v1/sms/send? 

Parametreler

 Apikey: string
Panelde Ayarlar / API Bilgileri menüsünde bulunan API key bilgisi. 
 encoding: string
tr   = Türkçe karakterli mesaj için yazmalısınız.
en =  ingilizce karakterli mesaj için  yazmalısınız.
title: string
 Onaylanan başlığınızı yazmalısınız. Başlıklar büyük küçük harf duyarlıdır.
numbers: string
Numaraları buraya yazmalısınız. Numaraların formatı önemli değildir, sistem 10 haneli formata çevirir. Numaraların arasında virgül olmalıdır. Örneğin 537 111 3344,0(555)111 22 33, 535 121 23 23 şeklinde gönderebilirsiniz.
message: string
Mesajınızı buraya yazmalısınız.
Dönüş Cevabı:
{"status":"success","queueId":99999}

Örnek Code
string urlsendmesaj = "https://panel.pelikansms.net/api/v1/sms/send?apikey=";

public string  MesajYolla( string apikey, string encoding, string title, string numbers, string mesaj)
{
urlsendmesaj += "" + apikey + "&encoding=" + encoding + "&title=" + title + "&numbers=" + numbers + "&message=" + mesaj + "";
return getistegiii(urlsendmesaj);
}
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




RAPOR SORGULAMA
İstek Adresi:
https://panel.pelikansms.net/api/v1/sms/reports/ 
Parametreler: 
queueId: integer
Mesaj gönderdikten sonra dönen queueId bilgisini buraya yazmalısınız. 
apikey: string 
Panelde Ayarlar / API Bilgileri menüsünde bulunan API key bilgisi.
( https://panel.pelikansms.net/ayarlar/api )
Dönüş Cevabı:
{
 "status": "success",
 "queue": {
 "queue_id": "112233",
 "queue_user_id": "1234",
 "queue_status": "completed",
 "queue_message": "Bu örnek bir mesajdır",
 "q_send_datetime": "2018-09-29 17:46:00",
 "q_total_credit": "2",
 "delivered_cnt": "2",
 "not_delivered_cnt": "0",
 "waiting_cnt": "0",
 "sent_cnt": "0",
 "total_numbers": "2",
 "st_title": "DEMO"
 },
 "numbers": [{
 "number": "5371112233",
 "status": "delivered",
 "sent_datetime": "2018-09-29 17:46:02",
 "updated_datetime": "2018-09-29 17:47:03"
 }, {
 "number": "5538354444",
 "status": "delivered",
 "sent_datetime": "2018-09-29 17:46:02",
 "updated_datetime": "2018-09-29 17:47:03"
 }]
}

Örnek Kod:
       string urlrapor = "https://panel.pelikansms.net/api/v1/sms/reports/"; 
       public string  MesajRaporla(string apikey,int RaporID)
        {
            urlrapor += RaporID + "?apikey=" + apikey;
            return getistegiii(urlrapor);
        }
       
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





KREDİ SORGULAMA
İstek Adresi:
https://panel.pelikansms.net/api/v1/user/profileDetails ?

Parametreler: 
apikey: string 
Panelde Ayarlar / API Bilgileri menüsünde bulunan API key bilgisi.
( https://panel.pelikansms.net/ayarlar/api )
Dönüş Cevabı:
{
 "status": "success",
 "id": "2",
 "top_id": "1",
 "user_type": "customer",
 "username": "5371112233",
$apiResult = file_get_contents("https://panel.pelikansms.net/api/v1/sms/send?apikey=mysecret
$apiResult = json_decode( $apiResult ); 
 "register_datetime": "2016-10-06 16:56:07",
 "active": "1",
 "firstname": "ORNEK",
 "lastname": "KULLANICI",
 "birthyear": "1989",
 "tc_identity_no": "xxxxxxxx",
 "province": "izmir",
 "district": "karşıyaka",
 "company_name": "pelikansms",
 "tax_office": "Karşıyaka VD",
 "tax_no": "13123123",
 "company_phone": "5371112233",
 "company_address": "xxxxxxxx",
 "email": "destek@pelikansms.net",
 "cellphone": "5371112233",
 "invoice_address": "xxxxxxxx",
 "api_key": "xxxxxxxxxxxxxxxxxxxx",
 "credit_type": "money",
 "money_per_credit": "0",
 "balance_credit": "12345",
 "affiliate_parent_id": "2",
 "balance_money": "0"
}
Örnek Kodlar
string urlkredisorgu = "https://panel.pelikansms.net/api/v1/user/profileDetails?apikey=";
        public string  Kredisorgula(string apikey)
        {
            urlkredisorgu +=  apikey;
            return getistegiii(urlkredisorgu);
        }
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


