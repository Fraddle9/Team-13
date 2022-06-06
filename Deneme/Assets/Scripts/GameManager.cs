using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public Button hocaButon;
    public Button arkeologButon;
    public TextMeshProUGUI HocaMesajText;
    public TextMeshProUGUI ArkeologMesajText;
    public Animator HocaAnim;
    public GameObject interaction;
    public GameObject interactionGokyuzu;
    public GameObject dikiliTasObje;
    public Light2D GokyuzuGlobalisik;
    public GameObject Yarasalar;
    public GameObject GirisKonusma;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "IlkDusme")
        {
            Destroy(collision.gameObject);
            StartCoroutine(IlkDusme());
        }

        if (collision.gameObject.name == "DikiliTas")
        {
            StopAllCoroutines();
            HocaAnim.enabled = false;
            arkeologButon.transform.parent.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            StartCoroutine(DikiliTas());
        }

        if (collision.gameObject.name == "FenerBozulma")
        {
            StopAllCoroutines();
            HocaAnim.enabled = false;
            arkeologButon.transform.parent.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            StartCoroutine(YarasaVeOcu());
        }

        if (collision.gameObject.name == "LevelOncesi")
        {
            StopAllCoroutines();
            HocaAnim.enabled = false;
            arkeologButon.transform.parent.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            StartCoroutine(LevelOncesi());
        }

        if (collision.gameObject.name == "GulyabaniAlert")
        {
            StopAllCoroutines();
            HocaAnim.enabled = false;
            arkeologButon.transform.parent.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            StartCoroutine(GulyabaniAlert());
        }

        if (collision.gameObject.name == "GeciteGit")
        {
            StopAllCoroutines();
            HocaAnim.enabled = false;
            arkeologButon.transform.parent.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            StartCoroutine(GeciteGit());
        }

        if (collision.gameObject.name == "GecitOnu")
        {
            StopAllCoroutines();
            HocaAnim.enabled = false;
            arkeologButon.transform.parent.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            StartCoroutine(GecitOnu());
        }

        if (collision.gameObject.name == "dikilitas-yazili")
        {
            interaction.gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "Cesme")
        {
            interactionGokyuzu.gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "Cansuyu")
        {
            Destroy(collision.gameObject);
            StartCoroutine(CanSuyu());
        }

        if (collision.gameObject.name == "DikilitasTwo")
        {
            StopAllCoroutines();
            HocaAnim.enabled = false;
            arkeologButon.transform.parent.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            StartCoroutine(DikilitasTwo());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "dikilitas-yazili" && Input.GetKey(KeyCode.E))
        {
            Instantiate(dikiliTasObje, new Vector3(collision.transform.position.x - 1f, collision.transform.position.y - 1), Quaternion.identity);
            collision.enabled = false;
        }

        if (collision.gameObject.name == "Cesme" && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(GeriDon());
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "dikilitas-yazili")
        {
            interaction.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Cesme")
        {
            interactionGokyuzu.gameObject.SetActive(false);
        }
    }

    IEnumerator IlkDusme()
    {
        yield return new WaitForSeconds(2);
        GirisKonusma.gameObject.SetActive(true);
        yield return new WaitForSeconds(53);
        GirisKonusma.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        //Hoca
        HocaAnim.enabled= true;
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
        HocaAnim.enabled = false;

        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam ben Arif de�ilim.", .05f, true, true);
        yield return new WaitForSeconds(3);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Her neyse i�te Ekrem.", .05f, true, true);
        yield return new WaitForSeconds(3);
        TextWriter.AddWriter_Static(HocaMesajText, "Yol boyunca ihtiyac�n olacak her �ey burada elinin alt�nda olmal�.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Pfft. Peki, neredeyim ben ? Ma�ara m� buras� ?", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Hahahah, demek sonunda haketti�in yerdesin. Projelerimi yapmaman�n cezas�! Cehennem.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Allah taksirat�m� affetsin. Peki derin bilgilerinizle bana yard�mc� olurmusunuz? Say�n �lter Altayl� hocam.", .05f, true, true);
        yield return new WaitForSeconds(6);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Cehaletinin bende makul bir zemine oturmas� �art de�il. Fakat yine de bana muhta�s�n tabii. Eh, yapacak bir �ey yok..", .05f, true, true);
        yield return new WaitForSeconds(6);
        HocaAnim.enabled = false;
        arkeologButon.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator DikiliTas()
    {
        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "�lerde bir dikilita� g�r�yorum.", .05f, true, true);
        yield return new WaitForSeconds(3);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Ta� �zerinde antik bir dil kaz�l� hocam. G�kt�rk Alfabesine benziyor.", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "O dersi neden alttan ald���n �imdi anla��l�yor..Cahil �ocu�um.. E hadi biraz zorla da �evir �unu!", .05f, true, true);
        yield return new WaitForSeconds(6);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam harfler �ok yabanc� ya�Bu harfler kalkt� bitti medeniyetimiz�", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Sanki harfler eskisi gibiyken o medeniyetin i�ine g�m�ld�yd�n���zz� Almad�n m� dersini sen bunun�", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "E�itsem bile cahil kalabilme ba�ar�s�n� kimseyle payla�m�yorsun.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hmm...", .05f, true, true);
        yield return new WaitForSeconds(1);
        TextWriter.AddWriter_Static(ArkeologMesajText, "��Erlik ma�aras�nda 13. g�n�m.Tengri beni korusun, �lgen�in egemenli�i daim olsun...", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(ArkeologMesajText, "�nsanl�k Erlik�in haylazl�k ve k�t�l�klerinden sak�ns�n.��", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Erlik mi? \nGe�mi� olsun �ocu�um, ke�ke cehennemde olsaym��s�n.", .05f, true, true);
        yield return new WaitForSeconds(4);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "B-BEN BA�KA B�R EVRENE M� GE��� YAPTIM YAN�!?", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Heyt b�y���n� sevdi�im �ocu�um be, arada kafan �al���yor.", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "Hadi hadi, durma da bir �eyler kazmaya bak.", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "Belki birka� i�e yarar �ey bulursun. Ellerini kulan.", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "Yoksa da Erlik� e ak�am yeme�i olursun hahah..", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "�aka �aka. Dua et ki ben sana yard�m ediyorum.Yoksa bu ot beyninle hayatta kalamazs�n..", .05f, true, true);
        yield return new WaitForSeconds(4);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Sa�olun hocam iyiki yan�mdas�n�z vallahi.", .05f, true, true);
        yield return new WaitForSeconds(5);
        arkeologButon.transform.parent.gameObject.SetActive(false);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "�ocu�um e�er ki ortada bir Erlik varsa do�ada ondan kurtulman� sa�layacak malzemelerde vard�r. Hayat�n kanunu budur sorgulama Ulu�.", .05f, true, true);
        yield return new WaitForSeconds(7);
        TextWriter.AddWriter_Static(HocaMesajText, "�lerlemeye ba�la ve yol boyunca kaz�lar ger�ekle�tir.Mutlaka i�e yarar �eyler bulursun.Umar�m yani, e�ek de�ilsin ya.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Buradaki tek ki�i sen olabilirsin �u an Seton, ama senden �ncesi de vard�r elbet.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Dikkat et yap�lara ve ��k�� i�in ipu�lar�n� aman ka��rma evlad�m. ", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
    }

    IEnumerator YarasaVeOcu()
    {
        Yarasalar.gameObject.SetActive(true);
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Aman dikkat et yarasalar�n ak�am yeme�i olacak gibisin.", .05f, true, true);
        yield return new WaitForSeconds(10);
        Yarasalar.gameObject.SetActive(false);
        TextWriter.AddWriter_Static(HocaMesajText, "Ma� vard� da bedava bilet mi da��tt�lar bunlar�n ard� arkas� kesilmiyor.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
    }

    IEnumerator LevelOncesi()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Sen �al���rken ben de sana bir an�m� anlatay�m ahahuhhh akl�ma geldi de hahahuhuh.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Senden cahil olmas�n bir ��rencim, Einstein ile tan��sayd�n ne yapard�n diye sordu �ocukca��z�n biri bana.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Ben bir �eyler yapar muhabbet kurard�m da aman diyeyim dedim senin gibi bir cahili g�rse Einstein kesin ��par�alard��� ahahauhau", .05f, true, true);
        yield return new WaitForSeconds(7);
        HocaAnim.enabled = false;

        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam d�nyadaki tek cahil ben de�ilim yani. :D", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Sen yine ya�ars�n da baz�lar� ke�ke �lse� Cahillik zor. Bunu bilmeden ya�amakta ne bileyim. Hadi hadi elin �al��s�n biraz.", .05f, true, true);
        yield return new WaitForSeconds(7);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Bu azimle ben d�nyay� feth ederim hocam.", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Adam�n biri aya 7+1 villa yapaca��m diyor bizde hala d�nya d�z m� yuvarlak m� haah d�z tepsi gibi evet i�inde de su yerine �erbet var.", .05f, true, true);
        yield return new WaitForSeconds(7);
        TextWriter.AddWriter_Static(HocaMesajText, "Gir i�ine ninenin dantelleri gibi ol. Televizyonun �zerine �rts�nler seni.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
        arkeologButon.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator GulyabaniAlert()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Ger�ekten yerin dibine girmeni istedi�im oldu da b�ylesini kastetmemi�tim tabi�", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Etraf so�uk ve bo�uk. Gulyabaniler ser�vene ��km�� ki�ileri yiyip yutan varl�klar olarak bilinmektedir.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Alim Allah yutuverirler seni, dikkat et�", .05f, true, true);
        yield return new WaitForSeconds(3);
        HocaAnim.enabled = false;
    }

    IEnumerator GeciteGit()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Muskay� buldun aferin, hadi bakal�m �ans�n a��k olsun fena de�ilsin. Bir DC veririm derste sana.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Suyun kaynama noktas�n� ilk bulan sen olsan gider �ay demlersin heralde.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Bu vizyon ile buldu�unu da heba edersin sen. Yakla�t�r �unu yak�n g�zl���m yok.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
    }

    IEnumerator GecitOnu()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Kad�nlar�n iyi erkek imaj�n� tan�mlayabilir misin bilmem ama buradaki k�zlar senin bir birikimle gelmeni bekliyor.", .05f, true, true);
        yield return new WaitForSeconds(7);
        TextWriter.AddWriter_Static(HocaMesajText, "Ceplerini ve kalbini kontrol et yavrum. Meteliksizdin d�nyada ama bakal�m burada neyin varm��.", .05f, true, true);
        yield return new WaitForSeconds(6);
        HocaAnim.enabled = false;
    }

    IEnumerator GeriDon()
    {
        GokyuzuGlobalisik.intensity = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GokyuzuDonus");
    }

    IEnumerator CanSuyu()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Her fidan�n can suyuna ihtiyac� var. Ye�ili sadece dolar�n �zerindeki renk olarak sevenlerden olma.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Akana sana bir can suyu bah�etti�i i�in �ansl�s�n Halet. Bunu sok �imdi koynuna, aman d���r�p kaybetme.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Ya da boynuna ba�la ilkokuldaki silgi gibi. Ha silgi, ha k���kba� �an� ne fark ediyor, g�d�lmeye �ok al��t�n�z...", .05f, true, true);
        yield return new WaitForSeconds(6);
        HocaAnim.enabled = false;
    }

    IEnumerator DikilitasTwo()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Viyana kap�lar�na dayan�r gibi dayanma o�lum dikilita�a, hassas �eyler onlar.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Elinin aya��n�n ayar� yok ya. G�klerden bir haber indi de bunu mu se�tiler yani�", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Hem beceriksiz hem cahil� Yak�nda �l�r bu.", .05f, true, true);
        yield return new WaitForSeconds(4);
        HocaAnim.enabled = false;
    }

    public void Basarisiz()
    {
        StartCoroutine(BasarisizIE());
    }

    IEnumerator BasarisizIE()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "O kadar g�revler i�in se�ilmi� insanlar� tan�d�m, tarihte okudum ama senin gibisini bilmem�", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Sen olsan olsan I.Mahvettin falan olurdun heralde.", .05f, true, true);
        yield return new WaitForSeconds(4);
        HocaAnim.enabled = false;
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
