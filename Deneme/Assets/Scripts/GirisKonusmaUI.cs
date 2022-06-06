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
        TextWriter.AddWriter_Static(GKonusmaSolText, "Nereye gidersen git üç þey seninle gelir. \nGölgen, acýn, geçmiþin… \nKaderinse seni orada beklemektedir…\n\nBeni bekleyen kader neye benziyordu, neden bu iþi yapýyorum, neden bu yazýlara deli gibi saplandým kaldým, neden buraya geldim…", .1f, true, true);
        yield return new WaitForSeconds(23);
        TextWriter.AddWriter_Static(GKonusmaSagText, "Neden, neden, neden…\nSoruya soru ile cevap vermek ile kendimi kaderin aðýna mý teslim ediyorum yoksa çoktan kaderin kucaðýna mý düþtüm… \n\nYapacak bir þey yok, yine düþtüm bir çukura.Bu melet alýn yazgýsýnýn satýlýðý yok ki iyisini alalým.Yolun bundan sonrasýný keþiflerle devam edeceðim.", .09f, true, true);
    }
}
