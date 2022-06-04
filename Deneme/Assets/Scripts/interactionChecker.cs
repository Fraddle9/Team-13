using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class interactionChecker : MonoBehaviour
{
    [SerializeField] public GameObject Book;
    public GameObject locImage1;
    public GameObject locImage2;
    public GameObject locImage3;
    public GameObject locImage4;
    public GameObject locImage5;
    public GameObject locImage6;
    public GameObject locImage7;
    public GameObject locImage8;

    public Color alphaZero;
    public Color alphaOne;
    public static bool GameIsPaused = false;

    public GameObject locText1;
    public GameObject locText2;
    public GameObject locText3;
    public GameObject locText4;
    public GameObject locText5;
    public GameObject locText6;
    public GameObject locText7;
    public GameObject locText8;

    public bool triggered = false;
    string message1 = "En son bir parýltý hatýrlýyorum. Sonra yer yarýldý da içine girdim sanki. Gözlerimi açtýðýmda ise buradaydým. Etraf çok karanlýk ve korkutucu.";
    string message2 = "Dikilitaþ.";
    string message3 = "Yarasa.";
    string message4 = "Geçit.";
    string message5 = "Ýskelet.";
    string message6 = "Gulyabani.";

    public void Start()
    {
        locImage1 = GameObject.Find("locImage1");
        locImage2 = GameObject.Find("locImage2");
        locImage3 = GameObject.Find("locImage3");
        locImage4 = GameObject.Find("locImage4");
        locImage5 = GameObject.Find("locImage5");
        locImage6 = GameObject.Find("locImage6");
        locImage7 = GameObject.Find("locImage7");
        locImage8 = GameObject.Find("locImage8");

        alphaZero = new Color(0, 0, 0, 0);
        alphaOne = new Color(255, 255, 255, 255);

        //locText1 = GameObject.Find("locText1");
    }

    public void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("Triggered");
            triggered = true;
            if (gameObject.name == "firstInteraction")
            {

                Debug.Log(gameObject.name);
                Book.SetActive(true);

                Destroy(gameObject);

                locImage1 = GameObject.Find("locImage1");
                locImage2 = GameObject.Find("locImage2");
                locImage3 = GameObject.Find("locImage3");
                locImage4 = GameObject.Find("locImage4");
                locImage5 = GameObject.Find("locImage5");
                locImage6 = GameObject.Find("locImage6");
                locImage7 = GameObject.Find("locImage7");
                locImage8 = GameObject.Find("locImage8");

                locText1 = GameObject.Find("locText1");
                locText2 = GameObject.Find("locText2");
                locText3 = GameObject.Find("locText3");
                locText4 = GameObject.Find("locText4");
                locText5 = GameObject.Find("locText5");
                locText6 = GameObject.Find("locText6");
                locText7 = GameObject.Find("locText7");
                locText8 = GameObject.Find("locText8");


                //Debug.Log(gameObject.name);
                locImage1.GetComponent<Image>().color = alphaOne;
                locText1.GetComponent<TextMeshProUGUI>().text = message1;

            }

            if (gameObject.name == "dikilitasInteraction")
            {

                Book.SetActive(true);
                Destroy(gameObject);

                locImage1 = GameObject.Find("locImage1");
                locImage2 = GameObject.Find("locImage2");
                locImage3 = GameObject.Find("locImage3");
                locImage4 = GameObject.Find("locImage4");
                locImage5 = GameObject.Find("locImage5");
                locImage6 = GameObject.Find("locImage6");
                locImage7 = GameObject.Find("locImage7");
                locImage8 = GameObject.Find("locImage8");

                locText1 = GameObject.Find("locText1");
                locText2 = GameObject.Find("locText2");
                locText3 = GameObject.Find("locText3");
                locText4 = GameObject.Find("locText4");
                locText5 = GameObject.Find("locText5");
                locText6 = GameObject.Find("locText6");
                locText7 = GameObject.Find("locText7");
                locText8 = GameObject.Find("locText8");

                locImage2.GetComponent<Image>().color = alphaOne;
                locText2.GetComponent<TextMeshProUGUI>().text = message2;

            }

            if (gameObject.name == "yarasaInteraction")
            {
                Book.SetActive(true);

                Destroy(gameObject);

                locImage1 = GameObject.Find("locImage1");
                locImage2 = GameObject.Find("locImage2");
                locImage3 = GameObject.Find("locImage3");
                locImage4 = GameObject.Find("locImage4");
                locImage5 = GameObject.Find("locImage5");
                locImage6 = GameObject.Find("locImage6");
                locImage7 = GameObject.Find("locImage7");
                locImage8 = GameObject.Find("locImage8");

                locText1 = GameObject.Find("locText1");
                locText2 = GameObject.Find("locText2");
                locText3 = GameObject.Find("locText3");
                locText4 = GameObject.Find("locText4");
                locText5 = GameObject.Find("locText5");
                locText6 = GameObject.Find("locText6");
                locText7 = GameObject.Find("locText7");
                locText8 = GameObject.Find("locText8");

                locImage3.GetComponent<Image>().color = alphaOne;
                locText3.GetComponent<TextMeshProUGUI>().text = message3;

            }

            if (gameObject.name == "gecitInteraction")
            {
                Book.SetActive(true);

                Destroy(gameObject);

                locImage1 = GameObject.Find("locImage1");
                locImage2 = GameObject.Find("locImage2");
                locImage3 = GameObject.Find("locImage3");
                locImage4 = GameObject.Find("locImage4");
                locImage5 = GameObject.Find("locImage5");
                locImage6 = GameObject.Find("locImage6");
                locImage7 = GameObject.Find("locImage7");
                locImage8 = GameObject.Find("locImage8");

                locText1 = GameObject.Find("locText1");
                locText2 = GameObject.Find("locText2");
                locText3 = GameObject.Find("locText3");
                locText4 = GameObject.Find("locText4");
                locText5 = GameObject.Find("locText5");
                locText6 = GameObject.Find("locText6");
                locText7 = GameObject.Find("locText7");
                locText8 = GameObject.Find("locText8");

                locImage4.GetComponent<Image>().color = alphaOne;
                locText4.GetComponent<TextMeshProUGUI>().text = message4;

            }

        }



    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Debug.Log("resuming");
    }

}
