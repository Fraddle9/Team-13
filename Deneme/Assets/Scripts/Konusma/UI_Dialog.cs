using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Dialog : MonoBehaviour
{
    private TextMeshProUGUI mesajText;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        mesajText = transform.Find("Dialog").Find("mesajText").GetComponent<TextMeshProUGUI>();

        transform.Find("Dialog").GetComponent<Button>().onClick.AddListener(Baslangic);

    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(mesajText, "Ne bakýyorsun çocuðum kazsana", 0.1f, true);
    }

    void Baslangic()
    {
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            string[] mesajArray = new string[] {
                "Hah! Elin ayaðýn da uyuþmuþtur, hareket etmeyi de unutmuþsundur þimdi sen.",//0
                "Elinin altýndaki D tuþu ile sað bacaðýný çalýþtýrda uyuþukluðunu at.",//1
                "Osmanlýspor'dan Ufuk antrenmana maðara içinde devam ediyor.",//2
                "Helal ulan kerata! Þimdi de A ’ya basarak sol tarafý çalýþtýr bakayým.",//3
                "Helal çocuðum! Sende hala umut görüyorum, adam olacaksýn be Arif!",//4
                "Her neyse iþte Ekrem.",//5
                "Yol boyunca ihtiyacýn olacak her þey burada elinin altýnda olmalý.",//6
                "Hahahah, demek sonunda hakettiðin yerdesin. Projelerimi yapmamanýn cezasý! Cehennem.",//7
                "Cehaletinin bende makul bir zemine oturmasý þart deðil. Fakat yine de bana muhtaçsýn tabii. Eh, yapacak bir þey yok..",//8
                "O dersi neden alttan aldýðýn þimdi anlaþýlýyor..Cahil çocuðum.. E hadi biraz zorla da çevir þunu!",//9
            };
            string message = mesajArray[Random.Range(0, mesajArray.Length)];
            textWriterSingle = TextWriter.AddWriter_Static(mesajText, message, .05f, true, true);
        }
    }
}
