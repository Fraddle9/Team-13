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
        yazitlar = GameObject.FindGameObjectsWithTag("Yaz?tButonu");
        characters = GameObject.FindGameObjectsWithTag("KarakterButonu");
        VLayrintihik = GameObject.Find("VL_AyrintiHik");
        VLayrintikisi = GameObject.Find("VL_AyrintiKisi");
        locked = GameObject.Find("Locked");
        lockedkisi = GameObject.Find("LockedKisi");

        //info = "Deneme";
        //info1 = "T?rkler'in bilinen ilk Alfabesi olan Orhun alfabesi ile G?kt?rkler taraf?ndan yaz?lm?? yap?tlard?r. Bu yaz?tlar T?rk?enin tarihsel s?re?teki gramer yap?s? ve bu yap?n?n de?i?imiyle ilgili bilgiler verdi?i gibi T?rklerin devlet anlay??? ile y?netimi, k?lt?rel ?geleri, kom?ular? ile soyda?lar?yla olan ili?kileri ve sosyal ya?ant?s?yla ilgili ?nemli bilgiler i?ermektedir.Bilge Ka?an ve K?l Tigin yaz?tlar?n? Yoll?g Tigin yazm??t?r.Yoll?? Tigin ayn? zamanda Bilge Ka?an'?n ye?enidir. Yaz?tlarda bu abidelerin sonsuzlu?a kadar kalmas? temennisi ile 'Beng? Ta?lar' denmi?tir.Yaz?tlar, 1889 y?l?nda Mo?olistan?da Orhun Vadisi'nde bulunmu?lard?r. Bu yaz?tlar II. G?kt?rk Ka?anl???'na aittir. Yaz?l?? tarihleri MS. 8.y?zy?l?n ba?lar?na dayanmaktad?r. Yaz?tlardan K?l Tigin Yaz?t? 732 y?l?nda, Bilge Ka?an Yaz?t? 735 y?l?nda yaz?lm??lard?r.1893 y?l?nda Danimarkal? dilbilimci Vilhelm Thomsen taraf?ndan, Rus T?rkolog Vasili Radlof?un da yard?m?yla ??z?lm?? ve ayn? y?l?n 15 Aral?k g?n? Danimarka Kraliyet Bilimler Akademisi'nde bilim d?nyas?na a??klanm??t?r.";
        //info2 = "2. sayfa";
        //info3 = "3. sayfa";
        //info4 = "4. sayfa";

        //text = bilgi.GetComponent<TextMeshProUGUI>();
        // isLocked kullan yeterli tablet say?s? varsa image a??k olacak ve isLockedi false olacak.

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
                "T?rkler'in bilinen ilk Alfabesi olan Orhun alfabesi ile G?kt?rkler taraf?ndan yaz?lm?? yap?tlard?r. Bu yaz?tlar T?rk?enin tarihsel s?re?teki gramer yap?s? ve bu yap?n?n de?i?imiyle ilgili bilgiler verdi?i gibi T?rklerin devlet anlay??? ile y?netimi, k?lt?rel ?geleri, kom?ular? ile soyda?lar?yla olan ili?kileri ve sosyal ya?ant?s?yla ilgili ?nemli bilgiler i?ermektedir.\n\nBilge Ka?an ve K?l Tigin yaz?tlar?n? Yoll?g Tigin yazm??t?r.Yoll?? Tigin ayn? zamanda Bilge Ka?an'?n ye?enidir. Yaz?tlarda bu abidelerin sonsuzlu?a kadar kalmas? temennisi ile 'Beng? Ta?lar' denmi?tir.",//1
                "Kutadgu Bilig (G?n?m?z T?rk?esi ile: Mutluluk Veren Bilgi ya da Devlet Olma Bilgisi)\n\n 11. y?zy?l Karahanl? T?rklerinden Yusuf Has Hacib'in Do?u Karahanl? h?k?mdar? ve Ka?gar Prensi Tabga? Ulu? Bu?ra Kara Han'a (Eb? Ali Hasan bin S?leyman Arslan) atfen yazd??? ve takdim etti?i Orta T?rk?e eserdir. Eser, Karahanl?ca olarak da isimlendirilen Hakaniye leh?esi ile yaz?lm??t?r.",//2
                "Bengita? - T?rk mitolojisinde bilinmeyen bir yerdeki gizemli bir dikilita? ?eklindedir. ?l?ms?zl?k Ta?? anlam?na gelir. \n D?n???m? ve d?ng?y? vurgular. Sonsuz ya?am?n sembol?d?r. Farkl? T?rk dillerinde Meng?ta?, Beng?da?, Beng?ta? olarak da s?ylenir. Ayr?ca an?t anlam?na da gelir. Bengi (Beng?/Meng?/Mengi) kavram? sonu olmayan, hep varolacak olan bir varl?k anlay???n? ifade eder. Bu ta? ise sonsuz bir d?ng? i?erisinde ruhlar?n g??e y?kseli?ini simgeler.",//3
                "d?rt",//4
                "be?",//5
                "alt?",//6
                "yedi",//7
                "sekiz",//8
                "dokuz",//9
                "on",//10
                "onbir",//11
                "oniki",//12

            };

                headline = new string[] {
                "Orhun Yaz?tlar?",
                "Kutadgu Bilig",
                "Bengita?",
                "4. Sayfa Ba?l???",
                "5. Sayfa Ba?l???",
                "6. Sayfa Ba?l???",
                "7. Sayfa Ba?l???",
                "8. Sayfa Ba?l???",
                "9. Sayfa Ba?l???",
                "10. Sayfa Ba?l???",
                "11. Sayfa Ba?l???",
                "12. Sayfa Ba?l???",


            };

                yazitlar = GameObject.FindGameObjectsWithTag("Yaz?tButonu");
                VLayrintihik = GameObject.Find("VL_AyrintiHik");

                obje = EventSystem.current.currentSelectedGameObject;
                //Debug.Log(obje);
                buttonImages = obje.GetComponentsInChildren<Image>();
                pageImages = VLayrintihik.GetComponentsInChildren<Image>();

                text = VLayrintihik.GetComponentsInChildren<TextMeshProUGUI>();

                for (int i = 0; i < buttonImages.Length; i++)
                { // objenin ad? ve text variable ad? ayn? ise o text variablesini ata.
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
                "?lgen, T?rk ve Altay mitolojisinde ?yilik Tanr?s?d?r. G???n 16. kat?nda ya?ar. Kayra Han??n o?ludur. T?rk mitolojisinde (Tengricilik d?neminde) T?rklerin iyilik tanr?s?d?r. Tek Tanr? inanc?nda G?ktanr?'n?n o?lu ve g?ky?z?n?n h?k?mdar? olarak g?r?lm??t?r. Bai Ulgan, Ulgan gibi adlarla Sibirya kavimlerince de yarat?c? tanr? olarak an?l?r.G???n 16. kat?nda oturan Kayra Han'dan 'd?n???m' yoluyla yarat?lan g?ksel ?? tanr? s?ralamas?nda ilk s?rada yer alan ve g???n on yedinci (veya on alt?nc?) kat?nda oturdu?una inan?lan, hava durumunu, verimlili?i ve do?urganl??? y?netti?i kabul edilen, sonralar? i?levlenerek G?ktanr?'n?n yerini alan tanr?d?r.",//1
                "Tepeg?z, T?rk mitolojisinde de ad? ge?en tek g?zl? devdir. Kaf da??nda ya?ar. Annesi alageyik donuna girebilen bir peridir. Bu perinin bir ?obanla birle?mesinden do?mu?tur. Bazen di?i, bazen de erkek Tepeg?z?lere rastlanabilir.",//2
                "Gulyabani veya Gul-i beyabani, orijinal s?yleyi?iyle de kar??m?za ??kan bu mahl?k, gezginlere ve yolculara u?ray?p onlar? mahveden canavard?r. Daha sonralar? Anadolu k?lt?r?nde ahubabayla beraber an?lmaya ba?lam?? ve insan yedi?i d???n?len kocaman, uzun sakall? ve asal? bir dev olarak tasavvur olunmu?tur.  sulara tekrar dalm??t?r. I??ktan (cisimsel olmayan) bir bedeni vard?r. Ba??nda g?c? simgeleyen ve taca benzeyen zarif boynuzlar? bulunur. Alt k?sm?nda denizk?z? gibi ?ok uzun bir bal?k kuyru?u bulunur. Kuyru?u hafif maviye ?alan bir renktedir.",//3
                "Ak Ana, T?rk mitolojilerinde Deniz Tanr??as?. Hen?z hi?bir ?ey yarat?lmam??ken ve yaln?zca u?suz bucaks?z bir su varken, sonsuz sulardan ??karak, Tanr? ?lgen?e yaratma ilham?n? vererek",//4
                "Ayisit, T?rk ve Altay mitolojilerinde g?zellik tanr??as?d?r. Ayz?t??n k?zlar? vard?r. Onlar da ku?u k?l???na b?r?nebilirler. S?merlerde Ay Tanr??as? olan Ay'a da ???k sa?maktad?r ve ad? da bu anlamla ba?lant?l?d?r. A?k her zaman ???kla ve parlakl?kla simgelenmektedir. ?A?k ate?i g?zlerimi k?r etti? ifadesi bunun en belirgin anlat?m?d?r.",//5
                "?aman, T?rk Mitolojisinde  insanlar ile ruhlar aras?nda ileti?im kurarak ?ifa sa?lad?klar?na inan?lan ki?ilerin ad?d?r.",//6
                "yedi",//7
                "sekiz",//8
                "dokuz",//9
                "on",//10
                "onbir",//11
                "oniki",//12

            };

                headline = new string[] {
                "?lgen",
                "Tepeg?z",
                "Gulyabani",
                "Ak Ana",
                "Ayisit'in K?zlar?",
                "?aman",
                "7. Sayfa Ba?l???",
                "8. Sayfa Ba?l???",
                "9. Sayfa Ba?l???",
                "10. Sayfa Ba?l???",
                "11. Sayfa Ba?l???",
                "12. Sayfa Ba?l???",
            };

                characters = GameObject.FindGameObjectsWithTag("KarakterButonu");
                VLayrintikisi = GameObject.Find("VL_AyrintiKisi");

                obje = EventSystem.current.currentSelectedGameObject;
                //Debug.Log(obje);
                buttonImages = obje.GetComponentsInChildren<Image>();
                pageImages = VLayrintikisi.GetComponentsInChildren<Image>();

                text = VLayrintikisi.GetComponentsInChildren<TextMeshProUGUI>();

                for (int i = 0; i < buttonImages.Length; i++)
                { // objenin ad? ve text variable ad? ayn? ise o text variablesini ata.
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