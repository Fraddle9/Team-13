using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    //public GameObject yazit;
    public static BookManager instance;
    public GameObject icerikHikaye;
    public GameObject icerikKisiler;
    public GameObject[] yazitlar;
    public GameObject[] characters;
    public Image[] buttonImages;
    public Image[] pageImages;
    public GameObject obje;
    public GameObject objekisi;
    public GameObject VLayrintihik;
    public GameObject VLayrintikisi;
    public GameObject locked;
    public GameObject lockedkisi;
    public GameObject[] yazitbuton;
    public int counter = 0;

    public Color alphaZero;
    public Color alphaOne;
    public string[] info;
    public string[] headline;
    //public string info;
    //public string info1;
    //public string info2;
    //public string info3;
    //public string info4;
    public TextMeshProUGUI[] text;
    public Image image;
    public int tabletamount;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //yazit = GameObject.Find("Yazit2");
        yazitbuton = GameObject.FindGameObjectsWithTag("Ikon");
        icerikHikaye = GameObject.Find("icerikHikaye");
        icerikKisiler = GameObject.Find("icerikKisiler");
        yazitlar = GameObject.FindGameObjectsWithTag("YazýtButonu");
        characters = GameObject.FindGameObjectsWithTag("KarakterButonu");
        VLayrintihik = GameObject.Find("VL_AyrintiHik");
        VLayrintikisi = GameObject.Find("VL_AyrintiKisi");
        locked = GameObject.Find("Locked");
        lockedkisi = GameObject.Find("LockedKisi");

        //info = "Deneme";
        //info1 = "Türkler'in bilinen ilk Alfabesi olan Orhun alfabesi ile Göktürkler tarafýndan yazýlmýþ yapýtlardýr. Bu yazýtlar Türkçenin tarihsel süreçteki gramer yapýsý ve bu yapýnýn deðiþimiyle ilgili bilgiler verdiði gibi Türklerin devlet anlayýþý ile yönetimi, kültürel ögeleri, komþularý ile soydaþlarýyla olan iliþkileri ve sosyal yaþantýsýyla ilgili önemli bilgiler içermektedir.Bilge Kaðan ve Kül Tigin yazýtlarýný Yollýg Tigin yazmýþtýr.Yollýð Tigin ayný zamanda Bilge Kaðan'ýn yeðenidir. Yazýtlarda bu abidelerin sonsuzluða kadar kalmasý temennisi ile 'Bengü Taþlar' denmiþtir.Yazýtlar, 1889 yýlýnda Moðolistan’da Orhun Vadisi'nde bulunmuþlardýr. Bu yazýtlar II. Göktürk Kaðanlýðý'na aittir. Yazýlýþ tarihleri MS. 8.yüzyýlýn baþlarýna dayanmaktadýr. Yazýtlardan Kül Tigin Yazýtý 732 yýlýnda, Bilge Kaðan Yazýtý 735 yýlýnda yazýlmýþlardýr.1893 yýlýnda Danimarkalý dilbilimci Vilhelm Thomsen tarafýndan, Rus Türkolog Vasili Radlof’un da yardýmýyla çözülmüþ ve ayný yýlýn 15 Aralýk günü Danimarka Kraliyet Bilimler Akademisi'nde bilim dünyasýna açýklanmýþtýr.";
        //info2 = "2. sayfa";
        //info3 = "3. sayfa";
        //info4 = "4. sayfa";

        //text = bilgi.GetComponent<TextMeshProUGUI>();
        // isLocked kullan yeterli tablet sayýsý varsa image açýk olacak ve isLockedi false olacak.

    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }

    public void UpdateRightSide()
    {

        icerikHikaye = GameObject.Find("icerikHikaye");
        icerikKisiler = GameObject.Find("icerikKisiler");
        alphaZero = new Color(0, 0, 0, 0);
        alphaOne = new Color(255, 255, 255, 255);

        if (icerikHikaye != null)
        {
            if (icerikHikaye.activeInHierarchy == true)
            {
                //Debug.Log("in hikaye if");
                if (locked == null) locked = GameObject.Find("Locked");
                locked.SetActive(true);

                info = new string[] {
                "Türkler'in bilinen ilk Alfabesi olan Orhun alfabesi ile Göktürkler tarafýndan yazýlmýþ yapýtlardýr. Bu yazýtlar Türkçenin tarihsel süreçteki gramer yapýsý ve bu yapýnýn deðiþimiyle ilgili bilgiler verdiði gibi Türklerin devlet anlayýþý ile yönetimi, kültürel ögeleri, komþularý ile soydaþlarýyla olan iliþkileri ve sosyal yaþantýsýyla ilgili önemli bilgiler içermektedir.\n\nBilge Kaðan ve Kül Tigin yazýtlarýný Yollýg Tigin yazmýþtýr.Yollýð Tigin ayný zamanda Bilge Kaðan'ýn yeðenidir. Yazýtlarda bu abidelerin sonsuzluða kadar kalmasý temennisi ile 'Bengü Taþlar' denmiþtir.",//1
                "Kutadgu Bilig (Günümüz Türkçesi ile: Mutluluk Veren Bilgi ya da Devlet Olma Bilgisi)\n\n 11. yüzyýl Karahanlý Türklerinden Yusuf Has Hacib'in Doðu Karahanlý hükümdarý ve Kaþgar Prensi Tabgaç Uluð Buðra Kara Han'a (Ebû Ali Hasan bin Süleyman Arslan) atfen yazdýðý ve takdim ettiði Orta Türkçe eserdir. Eser, Karahanlýca olarak da isimlendirilen Hakaniye lehçesi ile yazýlmýþtýr.",//2
                "Bengitaþ - Türk mitolojisinde bilinmeyen bir yerdeki gizemli bir dikilitaþ þeklindedir. Ölümsüzlük Taþý anlamýna gelir. \n Dönüþümü ve döngüyü vurgular. Sonsuz yaþamýn sembolüdür. Farklý Türk dillerinde Mengütaþ, Bengüdaþ, Bengütaþ olarak da söylenir. Ayrýca anýt anlamýna da gelir. Bengi (Bengü/Mengü/Mengi) kavramý sonu olmayan, hep varolacak olan bir varlýk anlayýþýný ifade eder. Bu taþ ise sonsuz bir döngü içerisinde ruhlarýn göðe yükseliþini simgeler.",//3
                "dört",//4
                "beþ",//5
                "altý",//6
                "yedi",//7
                "sekiz",//8
                "dokuz",//9
                "on",//10
                "onbir",//11
                "oniki",//12

            };

                headline = new string[] {
                "Orhun Yazýtlarý",
                "Kutadgu Bilig",
                "Bengitaþ",
                "4. Sayfa Baþlýðý",
                "5. Sayfa Baþlýðý",
                "6. Sayfa Baþlýðý",
                "7. Sayfa Baþlýðý",
                "8. Sayfa Baþlýðý",
                "9. Sayfa Baþlýðý",
                "10. Sayfa Baþlýðý",
                "11. Sayfa Baþlýðý",
                "12. Sayfa Baþlýðý",


            };

                yazitlar = GameObject.FindGameObjectsWithTag("YazýtButonu");
                VLayrintihik = GameObject.Find("VL_AyrintiHik");

                obje = EventSystem.current.currentSelectedGameObject;
                //Debug.Log(obje);
                buttonImages = obje.GetComponentsInChildren<Image>();
                pageImages = VLayrintihik.GetComponentsInChildren<Image>();

                text = VLayrintihik.GetComponentsInChildren<TextMeshProUGUI>();

                for (int i = 0; i < buttonImages.Length; i++)
                { // objenin adý ve text variable adý ayný ise o text variablesini ata.
                    if (buttonImages[i].tag == "Ikon")
                    {
                        //Debug.Log("tag is Ikon");
                        //Debug.Log(obje);
                        //Debug.Log("Length is = " + buttonImages.Length);

                        if (buttonImages[i].color.a == 1 || buttonImages[i].color.a == 255) //if visible
                        {
                            pageImages[0].color = alphaOne;
                            if (locked != null) locked.SetActive(false);

                            Debug.Log("ikon is active alpha is 1");
                            //Debug.Log(obje);

                            if (pageImages[0].tag == "Ikon")
                            {
                                for (int a = 0; a < yazitlar.Length; a++)
                                {
                                    if (obje == yazitlar[a])
                                    {
                                        text[0].text = headline[a];
                                        text[1].text = info[a];
                                        pageImages[0].sprite = buttonImages[i].sprite;
                                    }
                                }
                                //pageImages[0].sprite = buttonImages[i].sprite; //bunun gibi pageTexts[0].text = text1
                                //text[0].text = headline[0]; //[0].text = info;
                                //text[1].text = info[0];
                            }
                            VLayrintihik.SetActive(true);
                        }
                        else if (buttonImages[i].color.a == 0) //if not visible
                        {
                            //Debug.Log("ikon is not active");
                            text[0].text = " Kilitli ";
                            text[1].text = " Kilitli ";
                            //pageImages[0].color = alphaZero;
                            locked.SetActive(true);
                        }
                    }
                }
            }
        }


        if (icerikKisiler != null)
        {
            if (icerikKisiler.activeInHierarchy == true)
            {
                Debug.Log("in kisiler if");
                if (lockedkisi == null) lockedkisi = GameObject.Find("LockedKisi");
                lockedkisi.SetActive(true);

                info = new string[] {
                "Ülgen, Türk ve Altay mitolojisinde Ýyilik Tanrýsýdýr. Göðün 16. katýnda yaþar. Kayra Han’ýn oðludur. Türk mitolojisinde (Tengricilik döneminde) Türklerin iyilik tanrýsýdýr. Tek Tanrý inancýnda Göktanrý'nýn oðlu ve gökyüzünün hükümdarý olarak görülmüþtür. Bai Ulgan, Ulgan gibi adlarla Sibirya kavimlerince de yaratýcý tanrý olarak anýlýr.Göðün 16. katýnda oturan Kayra Han'dan 'dönüþüm' yoluyla yaratýlan göksel üç tanrý sýralamasýnda ilk sýrada yer alan ve göðün on yedinci (veya on altýncý) katýnda oturduðuna inanýlan, hava durumunu, verimliliði ve doðurganlýðý yönettiði kabul edilen, sonralarý iþlevlenerek Göktanrý'nýn yerini alan tanrýdýr.",//1
                "Tepegöz, Türk mitolojisinde de adý geçen tek gözlü devdir. Kaf daðýnda yaþar. Annesi alageyik donuna girebilen bir peridir. Bu perinin bir çobanla birleþmesinden doðmuþtur. Bazen diþi, bazen de erkek Tepegöz’lere rastlanabilir.",//2
                "Gulyabani veya Gul-i beyabani, orijinal söyleyiþiyle de karþýmýza çýkan bu mahlûk, gezginlere ve yolculara uðrayýp onlarý mahveden canavardýr. Daha sonralarý Anadolu kültüründe ahubabayla beraber anýlmaya baþlamýþ ve insan yediði düþünülen kocaman, uzun sakallý ve asalý bir dev olarak tasavvur olunmuþtur.  sulara tekrar dalmýþtýr. Iþýktan (cisimsel olmayan) bir bedeni vardýr. Baþýnda gücü simgeleyen ve taca benzeyen zarif boynuzlarý bulunur. Alt kýsmýnda denizkýzý gibi çok uzun bir balýk kuyruðu bulunur. Kuyruðu hafif maviye çalan bir renktedir.",//3
                "Ak Ana, Türk mitolojilerinde Deniz Tanrýçasý. Henüz hiçbir þey yaratýlmamýþken ve yalnýzca uçsuz bucaksýz bir su varken, sonsuz sulardan çýkarak, Tanrý Ülgen’e yaratma ilhamýný vererek",//4
                "Ayisit, Türk ve Altay mitolojilerinde güzellik tanrýçasýdýr. Ayzýt’ýn kýzlarý vardýr. Onlar da kuðu kýlýðýna bürünebilirler. Sümerlerde Ay Tanrýçasý olan Ay'a da ýþýk saçmaktadýr ve adý da bu anlamla baðlantýlýdýr. Aþk her zaman ýþýkla ve parlaklýkla simgelenmektedir. “Aþk ateþi gözlerimi kör etti” ifadesi bunun en belirgin anlatýmýdýr.",//5
                "Þaman, Türk Mitolojisinde  insanlar ile ruhlar arasýnda iletiþim kurarak þifa saðladýklarýna inanýlan kiþilerin adýdýr.",//6
                "yedi",//7
                "sekiz",//8
                "dokuz",//9
                "on",//10
                "onbir",//11
                "oniki",//12

            };

                headline = new string[] {
                "Ülgen",
                "Tepegöz",
                "Gulyabani",
                "Ak Ana",
                "Ayisit'in Kýzlarý",
                "Þaman",
                "7. Sayfa Baþlýðý",
                "8. Sayfa Baþlýðý",
                "9. Sayfa Baþlýðý",
                "10. Sayfa Baþlýðý",
                "11. Sayfa Baþlýðý",
                "12. Sayfa Baþlýðý",
            };

                characters = GameObject.FindGameObjectsWithTag("KarakterButonu");
                VLayrintikisi = GameObject.Find("VL_AyrintiKisi");

                obje = EventSystem.current.currentSelectedGameObject;
                //Debug.Log(obje);
                buttonImages = obje.GetComponentsInChildren<Image>();
                pageImages = VLayrintikisi.GetComponentsInChildren<Image>();

                text = VLayrintikisi.GetComponentsInChildren<TextMeshProUGUI>();

                for (int i = 0; i < buttonImages.Length; i++)
                { // objenin adý ve text variable adý ayný ise o text variablesini ata.
                    if (buttonImages[i].tag == "Ikon")
                    {
                        //Debug.Log("tag is Ikon");
                        //Debug.Log(obje);
                        //Debug.Log("Length is = " + buttonImages.Length);

                        if (buttonImages[i].color.a == 1 || buttonImages[i].color.a == 255) //if visible
                        {
                            pageImages[0].color = alphaOne;
                            lockedkisi.SetActive(false);
                            //Debug.Log("ikon is active alpha is 1");
                            //Debug.Log(obje);

                            if (pageImages[0].tag == "Ikon")
                            {
                                for (int a = 0; a < characters.Length; a++)
                                {
                                    if (obje == characters[a])
                                    {
                                        text[0].text = headline[a];
                                        text[1].text = info[a];
                                        pageImages[0].sprite = buttonImages[i].sprite;
                                    }
                                }
                                //pageImages[0].sprite = buttonImages[i].sprite; //bunun gibi pageTexts[0].text = text1
                                //text[0].text = headline[0]; //[0].text = info;
                                //text[1].text = info[0];
                            }
                            VLayrintikisi.SetActive(true);
                        }
                        else if (buttonImages[i].color.a == 0) //if not visible
                        {
                            //Debug.Log("ikon is not active");
                            text[0].text = " Kilitli ";
                            text[1].text = " Kilitli ";
                            //pageImages[0].color = alphaZero;
                            lockedkisi.SetActive(true);
                        }
                    }
                }

                //Debug.Log(buttonImages[1]);

            }
        }



    }

    public void ActivateLeftButton()
    {
        alphaOne = new Color(255, 255, 255, 255);
        //Debug.Log(XEntity.Interactor.instance.amount);
        tabletamount = XEntity.Interactor.instance.amount;
        //Debug.Log(yazitbuton[tabletamount].GetComponent<Image>().color.a);

        if (counter < 3)
        {
            Debug.Log("in");
            yazitbuton[counter].GetComponent<Image>().color = alphaOne;
        }
        Debug.Log(yazitbuton[counter]);
        counter++;
        Debug.Log("counter" + counter);


    }


}