using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArkeologDialog : MonoBehaviour
{
    public static void DialogBaslat(Transform parent, Vector3 localPosition, string text)
    {
        Transform arkeologDialogTransform = Instantiate(GameAssets.i.pfKonusmaBalon, parent);
        arkeologDialogTransform.localPosition = localPosition;

        arkeologDialogTransform.GetComponent<ArkeologDialog>().Setup(text);

        //Destroy(arkeologDialogTransform.gameObject, 4f);
    }
    private SpriteRenderer bgSpriteRendererKonusmaBalon;
    private SpriteRenderer bgSpriteRendererKuyruk;
    private TextMeshPro textMeshPro;
    [SerializeField] GameObject _hero;

    private void Awake()
    {
        bgSpriteRendererKonusmaBalon = transform.Find("KonusmaBalon").GetComponent<SpriteRenderer>();
        bgSpriteRendererKuyruk = transform.Find("BalonKuyruk").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("ArkeologText").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        Setup("Hello");
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(_hero.transform.position.x, _hero.transform.position.y, _hero.transform.position.z);
    }

    //Text'e yazý yazmak için fonksiyon
    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textBoyutu = textMeshPro.GetRenderedValues(false);

        
        //Vector2 padding = new Vector2(7f, 3f);
        //bgSpriteRendererKonusmaBalon.size = textBoyutu + padding;

        //Vector3 offset = new Vector3(-3f, 0f);
        //bgSpriteRendererKonusmaBalon.transform.localPosition = new Vector3(bgSpriteRendererKonusmaBalon.size.x / 2f, 0f) + offset;
    }
}
