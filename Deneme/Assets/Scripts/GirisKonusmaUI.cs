using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GirisKonusmaUI : MonoBehaviour
{
    public TextMeshProUGUI GKonusmaSolText;
    public TextMeshProUGUI GKonusmaSagText;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Start()
    {
        Konus();
    }


    void Konus()
    {
        StartCoroutine(GirisKonusma());
    }
    IEnumerator GirisKonusma()
    {
        yield return new WaitForSeconds(2);
        TextWriter.AddWriter_Static(GKonusmaSolText, "Nereye gidersen git �� �ey seninle gelir. \nG�lgen, ac�n, ge�mi�in� \nKaderinse seni orada beklemektedir�\n\nBeni bekleyen kader neye benziyordu, neden bu i�i yap�yorum, neden bu yaz�lara deli gibi sapland�m kald�m, neden buraya geldim�", .1f, true, true);
        yield return new WaitForSeconds(23);
        TextWriter.AddWriter_Static(GKonusmaSagText, "Neden, neden, neden�\nSoruya soru ile cevap vermek ile kendimi kaderin a��na m� teslim ediyorum yoksa �oktan kaderin kuca��na m� d��t�m� \n\nYapacak bir �ey yok, yine d��t�m bir �ukura.Bu melet al�n yazg�s�n�n sat�l��� yok ki iyisini alal�m.Yolun bundan sonras�n� ke�iflerle devam edece�im.", .09f, true, true);
    }
}
