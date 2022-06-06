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
        HocaAnim.enabled = false;

        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam ben Arif deðilim.", .05f, true, true);
        yield return new WaitForSeconds(3);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Her neyse iþte Ekrem.", .05f, true, true);
        yield return new WaitForSeconds(3);
        TextWriter.AddWriter_Static(HocaMesajText, "Yol boyunca ihtiyacýn olacak her þey burada elinin altýnda olmalý.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Pfft. Peki, neredeyim ben ? Maðara mý burasý ?", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Hahahah, demek sonunda hakettiðin yerdesin. Projelerimi yapmamanýn cezasý! Cehennem.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Allah taksiratýmý affetsin. Peki derin bilgilerinizle bana yardýmcý olurmusunuz? Sayýn Ýlter Altaylý hocam.", .05f, true, true);
        yield return new WaitForSeconds(6);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Cehaletinin bende makul bir zemine oturmasý þart deðil. Fakat yine de bana muhtaçsýn tabii. Eh, yapacak bir þey yok..", .05f, true, true);
        yield return new WaitForSeconds(6);
        HocaAnim.enabled = false;
        arkeologButon.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator DikiliTas()
    {
        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Ýlerde bir dikilitaþ görüyorum.", .05f, true, true);
        yield return new WaitForSeconds(3);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Taþ üzerinde antik bir dil kazýlý hocam. Göktürk Alfabesine benziyor.", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "O dersi neden alttan aldýðýn þimdi anlaþýlýyor..Cahil çocuðum.. E hadi biraz zorla da çevir þunu!", .05f, true, true);
        yield return new WaitForSeconds(6);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam harfler çok yabancý ya…Bu harfler kalktý bitti medeniyetimiz…", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Sanki harfler eskisi gibiyken o medeniyetin içine gömüldüydünüüüzz… Almadýn mý dersini sen bunun…", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Eðitsem bile cahil kalabilme baþarýsýný kimseyle paylaþmýyorsun.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hmm...", .05f, true, true);
        yield return new WaitForSeconds(1);
        TextWriter.AddWriter_Static(ArkeologMesajText, "‘’Erlik maðarasýnda 13. günüm.Tengri beni korusun, Ülgen’in egemenliði daim olsun...", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Ýnsanlýk Erlik’in haylazlýk ve kötülüklerinden sakýnsýn.’’", .05f, true, true);
        yield return new WaitForSeconds(5);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Erlik mi? \nGeçmiþ olsun çocuðum, keþke cehennemde olsaymýþsýn.", .05f, true, true);
        yield return new WaitForSeconds(4);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "B-BEN BAÞKA BÝR EVRENE MÝ GEÇÝÞ YAPTIM YANÝ!?", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Heyt býyýðýný sevdiðim çocuðum be, arada kafan çalýþýyor.", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "Hadi hadi, durma da bir þeyler kazmaya bak.", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "Belki birkaç iþe yarar þey bulursun. Ellerini kulan.", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "Yoksa da Erlik’ e akþam yemeði olursun hahah..", .05f, true, true);
        yield return new WaitForSeconds(4);
        TextWriter.AddWriter_Static(HocaMesajText, "Þaka þaka. Dua et ki ben sana yardým ediyorum.Yoksa bu ot beyninle hayatta kalamazsýn..", .05f, true, true);
        yield return new WaitForSeconds(4);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Saðolun hocam iyiki yanýmdasýnýz vallahi.", .05f, true, true);
        yield return new WaitForSeconds(5);
        arkeologButon.transform.parent.gameObject.SetActive(false);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Çocuðum eðer ki ortada bir Erlik varsa doðada ondan kurtulmaný saðlayacak malzemelerde vardýr. Hayatýn kanunu budur sorgulama Uluð.", .05f, true, true);
        yield return new WaitForSeconds(7);
        TextWriter.AddWriter_Static(HocaMesajText, "Ýlerlemeye baþla ve yol boyunca kazýlar gerçekleþtir.Mutlaka iþe yarar þeyler bulursun.Umarým yani, eþek deðilsin ya.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Buradaki tek kiþi sen olabilirsin þu an Seton, ama senden öncesi de vardýr elbet.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Dikkat et yapýlara ve çýkýþ için ipuçlarýný aman kaçýrma evladým. ", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
    }

    IEnumerator YarasaVeOcu()
    {
        Yarasalar.gameObject.SetActive(true);
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Aman dikkat et yarasalarýn akþam yemeði olacak gibisin.", .05f, true, true);
        yield return new WaitForSeconds(10);
        Yarasalar.gameObject.SetActive(false);
        TextWriter.AddWriter_Static(HocaMesajText, "Maç vardý da bedava bilet mi daðýttýlar bunlarýn ardý arkasý kesilmiyor.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
    }

    IEnumerator LevelOncesi()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Sen çalýþýrken ben de sana bir anýmý anlatayým ahahuhhh aklýma geldi de hahahuhuh.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Senden cahil olmasýn bir öðrencim, Einstein ile tanýþsaydýn ne yapardýn diye sordu çocukcaðýzýn biri bana.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Ben bir þeyler yapar muhabbet kurardým da aman diyeyim dedim senin gibi bir cahili görse Einstein kesin ‘’parçalardý’’ ahahauhau", .05f, true, true);
        yield return new WaitForSeconds(7);
        HocaAnim.enabled = false;

        //Arkeolog
        arkeologButon.transform.parent.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(ArkeologMesajText, "Hocam dünyadaki tek cahil ben deðilim yani. :D", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Sen yine yaþarsýn da bazýlarý keþke ölse… Cahillik zor. Bunu bilmeden yaþamakta ne bileyim. Hadi hadi elin çalýþsýn biraz.", .05f, true, true);
        yield return new WaitForSeconds(7);
        HocaAnim.enabled = false;

        //Arkeolog
        TextWriter.AddWriter_Static(ArkeologMesajText, "Bu azimle ben dünyayý feth ederim hocam.", .05f, true, true);
        yield return new WaitForSeconds(4);

        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Adamýn biri aya 7+1 villa yapacaðým diyor bizde hala dünya düz mü yuvarlak mý haah düz tepsi gibi evet içinde de su yerine þerbet var.", .05f, true, true);
        yield return new WaitForSeconds(7);
        TextWriter.AddWriter_Static(HocaMesajText, "Gir içine ninenin dantelleri gibi ol. Televizyonun üzerine örtsünler seni.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
        arkeologButon.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator GulyabaniAlert()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Gerçekten yerin dibine girmeni istediðim oldu da böylesini kastetmemiþtim tabi…", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Etraf soðuk ve boðuk. Gulyabaniler serüvene çýkmýþ kiþileri yiyip yutan varlýklar olarak bilinmektedir.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Alim Allah yutuverirler seni, dikkat et…", .05f, true, true);
        yield return new WaitForSeconds(3);
        HocaAnim.enabled = false;
    }

    IEnumerator GeciteGit()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Muskayý buldun aferin, hadi bakalým þansýn açýk olsun fena deðilsin. Bir DC veririm derste sana.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Suyun kaynama noktasýný ilk bulan sen olsan gider çay demlersin heralde.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Bu vizyon ile bulduðunu da heba edersin sen. Yaklaþtýr þunu yakýn gözlüðüm yok.", .05f, true, true);
        yield return new WaitForSeconds(5);
        HocaAnim.enabled = false;
    }

    IEnumerator GecitOnu()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Kadýnlarýn iyi erkek imajýný tanýmlayabilir misin bilmem ama buradaki kýzlar senin bir birikimle gelmeni bekliyor.", .05f, true, true);
        yield return new WaitForSeconds(7);
        TextWriter.AddWriter_Static(HocaMesajText, "Ceplerini ve kalbini kontrol et yavrum. Meteliksizdin dünyada ama bakalým burada neyin varmýþ.", .05f, true, true);
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
        TextWriter.AddWriter_Static(HocaMesajText, "Her fidanýn can suyuna ihtiyacý var. Yeþili sadece dolarýn üzerindeki renk olarak sevenlerden olma.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Akana sana bir can suyu bahþettiði için þanslýsýn Halet. Bunu sok þimdi koynuna, aman düþürüp kaybetme.", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Ya da boynuna baðla ilkokuldaki silgi gibi. Ha silgi, ha küçükbaþ çaný ne fark ediyor, güdülmeye çok alýþtýnýz...", .05f, true, true);
        yield return new WaitForSeconds(6);
        HocaAnim.enabled = false;
    }

    IEnumerator DikilitasTwo()
    {
        //Hoca
        HocaAnim.enabled = true;
        TextWriter.AddWriter_Static(HocaMesajText, "Viyana kapýlarýna dayanýr gibi dayanma oðlum dikilitaþa, hassas þeyler onlar.", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Elinin ayaðýnýn ayarý yok ya. Göklerden bir haber indi de bunu mu seçtiler yani…", .05f, true, true);
        yield return new WaitForSeconds(5);
        TextWriter.AddWriter_Static(HocaMesajText, "Hem beceriksiz hem cahil… Yakýnda ölür bu.", .05f, true, true);
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
        TextWriter.AddWriter_Static(HocaMesajText, "O kadar görevler için seçilmiþ insanlarý tanýdým, tarihte okudum ama senin gibisini bilmem…", .05f, true, true);
        yield return new WaitForSeconds(6);
        TextWriter.AddWriter_Static(HocaMesajText, "Sen olsan olsan I.Mahvettin falan olurdun heralde.", .05f, true, true);
        yield return new WaitForSeconds(4);
        HocaAnim.enabled = false;
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
