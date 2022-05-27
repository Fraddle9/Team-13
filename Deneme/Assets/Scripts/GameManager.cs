using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button hocaButon;
    public Button arkeologButon;
    public TextMeshProUGUI HocaMesajText;
    public TextMeshProUGUI ArkeologMesajText;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        //HocaDialog hcDialog = new HocaDialog();
        //hocaButon.onClick.AddListener(hcDialog.Hoca);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "IlkDusme")
        {
            Destroy(collision.gameObject);
            StartCoroutine(IlkDusme());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    IEnumerator IlkDusme()
    {
        //Hoca
        TextWriter.AddWriter_Static(HocaMesajText, "Hah! Elin ayaðýn da uyuþmuþtur, hareket etmeyi de unutmuþsundur þimdi sen.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Elinin altýndaki D tuþu ile sað bacaðýný çalýþtýrda uyuþukluðunu at.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Osmanlýspor'dan Ufuk antrenmana maðara içinde devam ediyor.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Helal ulan kerata! Þimdi de A ’ya basarak sol tarafý çalýþtýr bakayým.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Helal çocuðum! Sende hala umut görüyorum, adam olacaksýn be Arif!", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam ben Arif deðilim.", .05f, true, true);
        yield return new WaitForSeconds(3);

        //Hoca
        TextWriter.AddWriter_Static(HocaMesajText, "Her neyse iþte Ekrem.", .05f, true, true);
        yield return new WaitForSeconds(3);
        TextWriter.AddWriter_Static(HocaMesajText, "Yol boyunca ihtiyacýn olacak her þey burada elinin altýnda olmalý.", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Pfft. Peki, neredeyim ben ? Maðara mý burasý ?", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        TextWriter.AddWriter_Static(HocaMesajText, "Hahahah, demek sonunda hakettiðin yerdesin. Projelerimi yapmamanýn cezasý! Cehennem.", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Allah taksiratýmý affetsin. Peki derin bilgilerinizle bana yardýmcý olurmusunuz? Sayýn Ýlter Altaylý hocam.", .05f, true, true);
        yield return new WaitForSeconds(6);

        //Hoca
        TextWriter.AddWriter_Static(HocaMesajText, "Cehaletinin bende makul bir zemine oturmasý þart deðil. Fakat yine de bana muhtaçsýn tabii. Eh, yapacak bir þey yok..", .05f, true, true);
        yield return new WaitForSeconds(6);
        arkeologButon.transform.parent.gameObject.SetActive(false);
    }

    /*ÞUAN KULLANILMIYOR!!*
     * *
    public void Hoca(int i)
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
            string message = mesajArray[i];
            textWriterSingle = TextWriter.AddWriter_Static(HocaMesajText, message, .05f, true, true);
        }
    }

    void Arkeolog(int i)
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
            string message = mesajArray[i];
            textWriterSingle = TextWriter.AddWriter_Static(ArkeologMesajText, message, .05f, true, true);
        }
    }
    */
}
