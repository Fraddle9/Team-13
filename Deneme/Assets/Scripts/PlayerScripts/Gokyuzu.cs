using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gokyuzu : MonoBehaviour
{
    public GameObject[] bulut = new GameObject[9];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SonrakiBulut")
        {
            bulut[1].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "SonrakiBulut1")
        {
            bulut[2].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "SonrakiBulut2")
        {
            bulut[3].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "SonrakiBulut3")
        {
            bulut[4].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "SonrakiBulut4")
        {
            bulut[5].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "SonrakiBulut5")
        {
            bulut[6].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "SonrakiBulut6")
        {
            bulut[7].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "SonrakiBulut7")
        {
            bulut[8].gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "Dusus")
        {
            StartCoroutine(Dusus());
        }
    }

    IEnumerator Dusus()
    {
        bulut[9].gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GokyuzuDonus");
    }

}
