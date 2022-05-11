using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor; //Editör kütüp ekleniyor.

public class avciKarakter : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
