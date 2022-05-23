using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{

    public int money;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bitcoin"))
        {
            Destroy(collision.gameObject);
            money++;
            Debug.Log(money);
            ScoreManager.instance.AddPoint();
        }
    }

}
