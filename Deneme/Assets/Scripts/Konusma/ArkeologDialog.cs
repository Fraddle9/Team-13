using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArkeologDialog : MonoBehaviour
{
    private TextMeshProUGUI ArkeologMesajText;
    private int arkeologSayac = 0;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        ArkeologMesajText = transform.Find("arkeologDialog").Find("mesajText").GetComponent<TextMeshProUGUI>();

        transform.Find("arkeologDialog").GetComponent<Button>().onClick.AddListener(Arkeolog);
        //TextWriter.AddWriter_Static(ArkeologMesajText, "O dersi neden alttan aldýðýn þimdi anlaþýlýyor..Cahil çocuðum.. E hadi biraz zorla da çevir þunu!", .05f, true, true);
        
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(mesajText, "Ne bakýyorsun çocuðum kazsana", 0.1f, true);
        //TextWriter.AddWriter_Static(ArkeologMesajText, "O dersi neden alttan aldýðýn þimdi anlaþýlýyor..Cahil çocuðum.. E hadi biraz zorla da çevir þunu!", .05f, true, true);

    }

    
    void Arkeolog()
    {
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            string[] mesajArray = new string[] {
                "Hocam ben Arif deðilim.",//0
                "Pfft. Peki, neredeyim ben? Maðara mý burasý?",//1
                "Allah taksiratýmý affetsin. Peki derin bilgilerinizle bana yardýmcý olurmusunuz? Sayýn Ýlter Altaylý hocam.",//2
                "Helal ulan kerata! Þimdi de A ’ya basarak sol tarafý çalýþtýr bakayým.",//3
                "Helal çocuðum! Sende hala umut görüyorum, adam olacaksýn be Arif!",//4
                "Her neyse iþte Ekrem.",//5
                "Yol boyunca ihtiyacýn olacak her þey burada elinin altýnda olmalý.",//6
                "Hahahah, demek sonunda hakettiðin yerdesin. Projelerimi yapmamanýn cezasý! Cehennem.",//7
                "Cehaletinin bende makul bir zemine oturmasý þart deðil. Fakat yine de bana muhtaçsýn tabii. Eh, yapacak bir þey yok..",//8
                "O dersi neden alttan aldýðýn þimdi anlaþýlýyor..Cahil çocuðum.. E hadi biraz zorla da çevir þunu!",//9
            };
            string message = mesajArray[arkeologSayac++];
            textWriterSingle = TextWriter.AddWriter_Static(ArkeologMesajText, message, .05f, true, true);
        }
    }
}
