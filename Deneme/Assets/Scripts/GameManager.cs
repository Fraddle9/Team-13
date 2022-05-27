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
        TextWriter.AddWriter_Static(HocaMesajText, "Hah! Elin aya��n da uyu�mu�tur, hareket etmeyi de unutmu�sundur �imdi sen.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Elinin alt�ndaki D tu�u ile sa� baca��n� �al��t�rda uyu�uklu�unu at.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Osmanl�spor'dan Ufuk antrenmana ma�ara i�inde devam ediyor.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Helal ulan kerata! �imdi de A �ya basarak sol taraf� �al��t�r bakay�m.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Helal �ocu�um! Sende hala umut g�r�yorum, adam olacaks�n be Arif!", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam ben Arif de�ilim.", .05f, true, true);
        yield return new WaitForSeconds(3);

        //Hoca
        TextWriter.AddWriter_Static(HocaMesajText, "Her neyse i�te Ekrem.", .05f, true, true);
        yield return new WaitForSeconds(3);
        TextWriter.AddWriter_Static(HocaMesajText, "Yol boyunca ihtiyac�n olacak her �ey burada elinin alt�nda olmal�.", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Pfft. Peki, neredeyim ben ? Ma�ara m� buras� ?", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        TextWriter.AddWriter_Static(HocaMesajText, "Hahahah, demek sonunda haketti�in yerdesin. Projelerimi yapmaman�n cezas�! Cehennem.", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Allah taksirat�m� affetsin. Peki derin bilgilerinizle bana yard�mc� olurmusunuz? Say�n �lter Altayl� hocam.", .05f, true, true);
        yield return new WaitForSeconds(6);

        //Hoca
        TextWriter.AddWriter_Static(HocaMesajText, "Cehaletinin bende makul bir zemine oturmas� �art de�il. Fakat yine de bana muhta�s�n tabii. Eh, yapacak bir �ey yok..", .05f, true, true);
        yield return new WaitForSeconds(6);
        arkeologButon.transform.parent.gameObject.SetActive(false);
    }

    /*�UAN KULLANILMIYOR!!*
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
            string message = mesajArray[i];
            textWriterSingle = TextWriter.AddWriter_Static(ArkeologMesajText, message, .05f, true, true);
        }
    }
    */
}
