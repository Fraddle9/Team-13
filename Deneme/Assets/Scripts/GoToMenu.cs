using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MenuyeGit());
    }

    IEnumerator MenuyeGit()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("StartMenuScene");
    }
}
