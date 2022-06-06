using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public GameObject HK_giris;
    public GameObject Animasyon;

    private void Start()
    {
        //Resolution Dropdown içindeki elementlerin kullanýcýnýn bilgisayarýndaki görüntü ayarlarýna göre ayarlanmasýný saðlýyoruz
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void StartGame()
    {
        StartCoroutine(GameStartHikayeGiris());
    }

    public void QuitGame()
    {
        Application.Quit(); //Uygulamayý kapatýr
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume()
    {

    }

    IEnumerator GameStartHikayeGiris()
    {
        Animasyon.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Animasyon.gameObject.SetActive(false);
        
        HK_giris.gameObject.SetActive(true);
        yield return new WaitForSeconds(23);
        
        Animasyon.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Sýradaki sahneyi yükler
    }
}
