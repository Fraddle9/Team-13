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
        TextWriter.AddWriter_Static(HakkindaSGSolText, "Bir inat�� ruhun hikayesi ya da nedenlerinin, soru i�aretlerinin pe�inden ko�an bir insan�n hikayesi diyelim� \n\nHocas�n�n tavsiyesini dinlemeyip inatla merak etti�i yaz�tlara do�ru ser�vene ��kan karakterimiz, yaz�tlara yakla��r biraz daha biraz daha sonra biraz daha�", .05f, true, true);
        yield return new WaitForSeconds(13);
        TextWriter.AddWriter_Static(HakkindaSGSagText, "Dokundu�u an yaz�larda bir parlama g�rmesi ile toprak tabakas�n�n ikiye b�l�n�p karakterimizi yutmas� bir olur. \n\nKaderini belirleyip onu kurtaracak olan sensin�", .05f, true, true);
    }
}
