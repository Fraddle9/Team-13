using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor; //Editör kütüp ekleniyor.

public class KarakterDialog : MonoBehaviour
{
    public GameObject kitapbuton;


    public NPCConversation myConversation;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
