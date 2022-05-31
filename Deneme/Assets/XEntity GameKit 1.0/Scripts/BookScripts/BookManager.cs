using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    //public GameObject yazit;
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
    public Color alphaZero;
    public Color alphaOne;
    //public string info;
    //public string info1;
    //public string info2;
    //public string info3;
    //public string info4;
    public TextMeshProUGUI[] text;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        //yazit = GameObject.Find("Yazit2");
        icerikHikaye = GameObject.Find("icerikHikaye");
        icerikKisiler = GameObject.Find("icerikKisiler");
        yazitlar = GameObject.FindGameObjectsWithTag("Yaz�tButonu");
        characters = GameObject.FindGameObjectsWithTag("KarakterButonu");
        VLayrintihik = GameObject.Find("VL_AyrintiHik");
        VLayrintikisi = GameObject.Find("VL_AyrintiKisi");
        locked = GameObject.Find("Locked");
        lockedkisi = GameObject.Find("LockedKisi");

        //info = "Deneme";
        //info1 = "T�rkler'in bilinen ilk Alfabesi olan Orhun alfabesi ile G�kt�rkler taraf�ndan yaz�lm�� yap�tlard�r. Bu yaz�tlar T�rk�enin tarihsel s�re�teki gramer yap�s� ve bu yap�n�n de�i�imiyle ilgili bilgiler verdi�i gibi T�rklerin devlet anlay��� ile y�netimi, k�lt�rel �geleri, kom�ular� ile soyda�lar�yla olan ili�kileri ve sosyal ya�ant�s�yla ilgili �nemli bilgiler i�ermektedir.Bilge Ka�an ve K�l Tigin yaz�tlar�n� Yoll�g Tigin yazm��t�r.Yoll�� Tigin ayn� zamanda Bilge Ka�an'�n ye�enidir. Yaz�tlarda bu abidelerin sonsuzlu�a kadar kalmas� temennisi ile 'Beng� Ta�lar' denmi�tir.Yaz�tlar, 1889 y�l�nda Mo�olistan�da Orhun Vadisi'nde bulunmu�lard�r. Bu yaz�tlar II. G�kt�rk Ka�anl���'na aittir. Yaz�l�� tarihleri MS. 8.y�zy�l�n ba�lar�na dayanmaktad�r. Yaz�tlardan K�l Tigin Yaz�t� 732 y�l�nda, Bilge Ka�an Yaz�t� 735 y�l�nda yaz�lm��lard�r.1893 y�l�nda Danimarkal� dilbilimci Vilhelm Thomsen taraf�ndan, Rus T�rkolog Vasili Radlof�un da yard�m�yla ��z�lm�� ve ayn� y�l�n 15 Aral�k g�n� Danimarka Kraliyet Bilimler Akademisi'nde bilim d�nyas�na a��klanm��t�r.";
        //info2 = "2. sayfa";
        //info3 = "3. sayfa";
        //info4 = "4. sayfa";

        //text = bilgi.GetComponent<TextMeshProUGUI>();
        // isLocked kullan yeterli tablet say�s� varsa image a��k olacak ve isLockedi false olacak.

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRightSide()
    { //ifler gelcek. e�er image a��ksa sa� taraf da a��k. de�ilse de�il. a��ksa texti de�i�.

        icerikHikaye = GameObject.Find("icerikHikaye");
        icerikKisiler = GameObject.Find("icerikKisiler");
        alphaZero = new Color(0, 0, 0, 0);
        alphaOne = new Color(255, 255, 255, 255);

        string[] info = new string[] {
                "T�rkler'in bilinen ilk Alfabesi olan Orhun alfabesi ile G�kt�rkler taraf�ndan yaz�lm�� yap�tlard�r. Bu yaz�tlar T�rk�enin tarihsel s�re�teki gramer yap�s� ve bu yap�n�n de�i�imiyle ilgili bilgiler verdi�i gibi T�rklerin devlet anlay��� ile y�netimi, k�lt�rel �geleri, kom�ular� ile soyda�lar�yla olan ili�kileri ve sosyal ya�ant�s�yla ilgili �nemli bilgiler i�ermektedir.\n\nBilge Ka�an ve K�l Tigin yaz�tlar�n� Yoll�g Tigin yazm��t�r.Yoll�� Tigin ayn� zamanda Bilge Ka�an'�n ye�enidir. Yaz�tlarda bu abidelerin sonsuzlu�a kadar kalmas� temennisi ile 'Beng� Ta�lar' denmi�tir.",//1
                "Kutadgu Bilig (G�n�m�z T�rk�esi ile: Mutluluk Veren Bilgi ya da Devlet Olma Bilgisi)\n\n 11. y�zy�l Karahanl� T�rklerinden Yusuf Has Hacib'in Do�u Karahanl� h�k�mdar� ve Ka�gar Prensi Tabga� Ulu� Bu�ra Kara Han'a (Eb� Ali Hasan bin S�leyman Arslan) atfen yazd��� ve takdim etti�i Orta T�rk�e eserdir. Eser, Karahanl�ca olarak da isimlendirilen Hakaniye leh�esi ile yaz�lm��t�r.",//2
                "Bengita� - T�rk mitolojisinde bilinmeyen bir yerdeki gizemli bir dikilita� �eklindedir. �l�ms�zl�k Ta�� anlam�na gelir. \n D�n���m� ve d�ng�y� vurgular. Sonsuz ya�am�n sembol�d�r. Farkl� T�rk dillerinde Meng�ta�, Beng�da�, Beng�ta� olarak da s�ylenir. Ayr�ca an�t anlam�na da gelir. Bengi (Beng�/Meng�/Mengi) kavram� sonu olmayan, hep varolacak olan bir varl�k anlay���n� ifade eder. Bu ta� ise sonsuz bir d�ng� i�erisinde ruhlar�n g��e y�kseli�ini simgeler.",//3
                "d�rt",//4
                "be�",//5
                "alt�",//6
                "yedi",//7
                "sekiz",//8
                "dokuz",//9
                "on",//10
                "onbir",//11
                "oniki",//12

            };

        string[] headline = new string[]
        {
            "Orhun Yaz�tlar�",
            "Kutadgu Bilig",
            "Bengita�",
            "4. Sayfa Ba�l���",
            "5. Sayfa Ba�l���",
            "6. Sayfa Ba�l���",
            "7. Sayfa Ba�l���",
            "8. Sayfa Ba�l���",
            "9. Sayfa Ba�l���",
            "10. Sayfa Ba�l���",
            "11. Sayfa Ba�l���",
            "12. Sayfa Ba�l���",


        };

        if (icerikHikaye != null)
        {
            if (icerikHikaye.activeInHierarchy == true)
            {
                Debug.Log("in hikaye if");
                yazitlar = GameObject.FindGameObjectsWithTag("Yaz�tButonu");
                VLayrintihik = GameObject.Find("VL_AyrintiHik");

                obje = EventSystem.current.currentSelectedGameObject;
                Debug.Log(obje);
                buttonImages = obje.GetComponentsInChildren<Image>();
                pageImages = VLayrintihik.GetComponentsInChildren<Image>();

                text = VLayrintihik.GetComponentsInChildren<TextMeshProUGUI>();

                for (int i = 0; i < buttonImages.Length; i++)
                { // objenin ad� ve text variable ad� ayn� ise o text variablesini ata.
                    if (buttonImages[i].tag == "Ikon")
                    {
                        //Debug.Log("tag is Ikon");
                        //Debug.Log(obje);
                        //Debug.Log("Length is = " + buttonImages.Length);

                        if (buttonImages[i].color.a == 1) //if visible
                        {
                            pageImages[0].color = alphaOne;
                            locked.SetActive(false);
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
                            Debug.Log("ikon is not active");
                            text[0].text = " Kilitli ";
                            text[1].text = " Kilitli ";
                            pageImages[0].color = alphaZero;
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
                characters = GameObject.FindGameObjectsWithTag("KarakterButonu");
                VLayrintikisi = GameObject.Find("VL_AyrintiKisi");

                obje = EventSystem.current.currentSelectedGameObject;
                Debug.Log(obje);
                buttonImages = obje.GetComponentsInChildren<Image>();
                pageImages = VLayrintikisi.GetComponentsInChildren<Image>();

                text = VLayrintikisi.GetComponentsInChildren<TextMeshProUGUI>();

                for (int i = 0; i < buttonImages.Length; i++)
                { // objenin ad� ve text variable ad� ayn� ise o text variablesini ata.
                    if (buttonImages[i].tag == "Ikon")
                    {
                        //Debug.Log("tag is Ikon");
                        //Debug.Log(obje);
                        //Debug.Log("Length is = " + buttonImages.Length);

                        if (buttonImages[i].color.a == 1) //if visible
                        {
                            pageImages[0].color = alphaOne;
                            locked.SetActive(false);
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
                            Debug.Log("ikon is not active");
                            text[0].text = " Kilitli ";
                            text[1].text = " Kilitli ";
                            pageImages[0].color = alphaZero;
                            locked.SetActive(true);
                        }
                    }
                }

            }
        }



    }

    public void UpdateCharacters()
    {
        characters = GameObject.FindGameObjectsWithTag("KarakterButonu");

    }


}
