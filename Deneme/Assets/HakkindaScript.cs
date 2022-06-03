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
        TextWriter.AddWriter_Static(hakkindaSolText, "Bir inatçý ruhun hikayesi \n ya da nedenlerinin, soru iþaretlerinin peþinden koþan bir insanýn hikayesi diyelim \nHocasýnýn tavsiyesini dinlemeyip inatla merak ettiði yazýtlara doðru serüvene çýkan karakterimiz, yazýtlara yaklaþýr biraz daha biraz daha sonra biraz daha…", .05f, true, true);
        yield return new WaitForSecondsRealtime(5f);
        TextWriter.AddWriter_Static(hakkindaSagText, "Hah! Elin ayaðýn da uyuþmuþtur, hareket etmeyi de unutmuþsundur þimdi sen.", .05f, true, true);
    }
}
