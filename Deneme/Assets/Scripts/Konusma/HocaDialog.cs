using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HocaDialog : MonoBehaviour
{
    private TextMeshProUGUI HocaMesajText;
    private int hocaSayac = 0;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        //HocaMesajText = transform.Find("hocaDialog").Find("mesajText").GetComponent<TextMeshProUGUI>();

        transform.Find("hocaDialog").GetComponent<Button>().onClick.AddListener(Hoca);
        //TextWriter.AddWriter_Static(HocaMesajText, "O dersi neden alttan ald���n �imdi anla��l�yor..Cahil �ocu�um.. E hadi biraz zorla da �evir �unu!", .05f, true, true);
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(mesajText, "Ne bak�yorsun �ocu�um kazsana", 0.1f, true);
        //TextWriter.AddWriter_Static(HocaMesajText, "Hah! Elin aya��n da uyu�mu�tur, hareket etmeyi de unutmu�sundur �imdi sen.", .05f, true, true);
        //TextWriter.AddWriter_Static(HocaMesajText, "Elinin alt�ndaki D tu�u ile sa� baca��n� �al��t�rda uyu�uklu�unu at.", .05f, true, true);

    }

    public void Hoca()
    {
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            string[] mesajArray = new string[] {
                "Hah! Elin aya��n da uyu�mu�tur, hareket etmeyi de unutmu�sundur �imdi sen.",//0
                "Elinin alt�ndaki D tu�u ile sa� baca��n� �al��t�rda uyu�uklu�unu at.",//1
                "Osmanl�spor'dan Ufuk antrenmana ma�ara i�inde devam ediyor.",//2
                "Helal ulan kerata! �imdi de A �ya basarak sol taraf� �al��t�r bakay�m.",//3
                "Helal �ocu�um! Sende hala umut g�r�yorum, adam olacaks�n be Arif!",//4
                "Her neyse i�te Ekrem.",//5
                "Yol boyunca ihtiyac�n olacak her �ey burada elinin alt�nda olmal�.",//6
                "Hahahah, demek sonunda haketti�in yerdesin. Projelerimi yapmaman�n cezas�! Cehennem.",//7
                "Cehaletinin bende makul bir zemine oturmas� �art de�il. Fakat yine de bana muhta�s�n tabii. Eh, yapacak bir �ey yok..",//8
                "O dersi neden alttan ald���n �imdi anla��l�yor..Cahil �ocu�um.. E hadi biraz zorla da �evir �unu!",//9
            };
            string message = mesajArray[hocaSayac++];
            textWriterSingle = TextWriter.AddWriter_Static(HocaMesajText, message, .05f, true, true);
        }
    }
}
