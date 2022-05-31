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
        //TextWriter.AddWriter_Static(ArkeologMesajText, "O dersi neden alttan ald���n �imdi anla��l�yor..Cahil �ocu�um.. E hadi biraz zorla da �evir �unu!", .05f, true, true);
        
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(mesajText, "Ne bak�yorsun �ocu�um kazsana", 0.1f, true);
        //TextWriter.AddWriter_Static(ArkeologMesajText, "O dersi neden alttan ald���n �imdi anla��l�yor..Cahil �ocu�um.. E hadi biraz zorla da �evir �unu!", .05f, true, true);

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
                "Hocam ben Arif de�ilim.",//0
                "Pfft. Peki, neredeyim ben? Ma�ara m� buras�?",//1
                "Allah taksirat�m� affetsin. Peki derin bilgilerinizle bana yard�mc� olurmusunuz? Say�n �lter Altayl� hocam.",//2
                "Helal ulan kerata! �imdi de A �ya basarak sol taraf� �al��t�r bakay�m.",//3
                "Helal �ocu�um! Sende hala umut g�r�yorum, adam olacaks�n be Arif!",//4
                "Her neyse i�te Ekrem.",//5
                "Yol boyunca ihtiyac�n olacak her �ey burada elinin alt�nda olmal�.",//6
                "Hahahah, demek sonunda haketti�in yerdesin. Projelerimi yapmaman�n cezas�! Cehennem.",//7
                "Cehaletinin bende makul bir zemine oturmas� �art de�il. Fakat yine de bana muhta�s�n tabii. Eh, yapacak bir �ey yok..",//8
                "O dersi neden alttan ald���n �imdi anla��l�yor..Cahil �ocu�um.. E hadi biraz zorla da �evir �unu!",//9
            };
            string message = mesajArray[arkeologSayac++];
            textWriterSingle = TextWriter.AddWriter_Static(ArkeologMesajText, message, .05f, true, true);
        }
    }
}
