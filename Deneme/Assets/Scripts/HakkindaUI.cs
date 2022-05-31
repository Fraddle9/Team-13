using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HakkindaUI : MonoBehaviour
{
    public TextMeshProUGUI HakkindaSolText;
    public TextMeshProUGUI HakkindaSagText;
    public Button HakkindaBtn;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Start()
    {
        GorevYap();
        HakkindaBtn.onClick.AddListener(GorevYap);
    }


    void GorevYap()
    {
        StartCoroutine(HakkindaIE());
    }
    IEnumerator HakkindaIE()
    {
        TextWriter.AddWriter_Static(HakkindaSolText, "Bir inat�� ruhun hikayesi ya da nedenlerinin, soru i�aretlerinin pe�inden ko�an bir insan�n hikayesi diyelim� \n\nHocas�n�n tavsiyesini dinlemeyip inatla merak etti�i yaz�tlara do�ru ser�vene ��kan karakterimiz, yaz�tlara yakla��r biraz daha biraz daha sonra biraz daha�", .05f, true, true);
        yield return new WaitForSeconds(13);
        TextWriter.AddWriter_Static(HakkindaSagText, "Dokundu�u an yaz�larda bir parlama g�rmesi ile toprak tabakas�n�n ikiye b�l�n�p karakterimizi yutmas� bir olur. \n\nKaderini belirleyip onu kurtaracak olan sensin�", .05f, true, true);
    }
}
