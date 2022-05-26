using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button hocaButon;
    public Button arkeologButon;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        HocaDialog hcDialog = new HocaDialog();
        hocaButon.onClick.AddListener(hcDialog.Hoca);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
