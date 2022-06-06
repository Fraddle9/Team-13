using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HakkindaStartGame : MonoBehaviour
{
    public TextMeshProUGUI HakkindaSGSolText;
    public TextMeshProUGUI HakkindaSGSagText;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Start()
    {
        HakkindaBilgi();
    }


    void HakkindaBilgi()
    {
        StartCoroutine(HakkindaSG());
    }
    IEnumerator HakkindaSG()
    {
        TextWriter.AddWriter_Static(HakkindaSGSolText, "Bir inatçý ruhun hikayesi ya da nedenlerinin, soru iþaretlerinin peþinden koþan bir insanýn hikayesi diyelim… \n\nHocasýnýn tavsiyesini dinlemeyip inatla merak ettiði yazýtlara doðru serüvene çýkan karakterimiz, yazýtlara yaklaþýr biraz daha biraz daha sonra biraz daha…", .05f, true, true);
        yield return new WaitForSeconds(13);
        TextWriter.AddWriter_Static(HakkindaSGSagText, "Dokunduðu an yazýlarda bir parlama görmesi ile toprak tabakasýnýn ikiye bölünüp karakterimizi yutmasý bir olur. \n\nKaderini belirleyip onu kurtaracak olan sensin…", .05f, true, true);
    }
}
