using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HakkindaScript : MonoBehaviour
{
    private TextWriter.TextWriterSingle textWriterSingle;
    public TextMeshProUGUI hakkindaSolText;
    public TextMeshProUGUI hakkindaSagText;
    // Start is called before the first frame update
    
    private void Awake()
    {
        StartCoroutine(TypeWrite());
    }

    // Update is called once per frame
    IEnumerator TypeWrite()
    {
        TextWriter.AddWriter_Static(hakkindaSolText, "Bir inat�� ruhun hikayesi \n ya da nedenlerinin, soru i�aretlerinin pe�inden ko�an bir insan�n hikayesi diyelim \nHocas�n�n tavsiyesini dinlemeyip inatla merak etti�i yaz�tlara do�ru ser�vene ��kan karakterimiz, yaz�tlara yakla��r biraz daha biraz daha sonra biraz daha�", .05f, true, true);
        yield return new WaitForSecondsRealtime(5f);
        TextWriter.AddWriter_Static(hakkindaSagText, "Hah! Elin aya��n da uyu�mu�tur, hareket etmeyi de unutmu�sundur �imdi sen.", .05f, true, true);
    }
}
