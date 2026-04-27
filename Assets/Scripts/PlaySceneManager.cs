using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{

    [SerializeField] GameObject fadeOut;
    [SerializeField] private GameObject settingsPopUp;
    [SerializeField] private GameObject statsPopUp;
    private bool activeSettingButton = false;
    private bool activeStatsButton = false;
    public void GameScene()
    {
        fadeOut.SetActive(true);
        StartCoroutine(GameSceneAnimation());
    }

    public void PlayScene()
    {
        fadeOut.SetActive(true);
        StartCoroutine(PlaySceneAnimation());
    }

    public void ExitGame()
    {
        fadeOut.SetActive(true);
        StartCoroutine(ExitAnimation());
    }

    public void SettingsButton()
    {
        if (activeSettingButton)
        {
            settingsPopUp.SetActive(false);
            activeSettingButton = false;
        }
        else
        {
            settingsPopUp.SetActive(true);
            activeSettingButton = true;
        }
    }

    public void StatsButton()
    {
        if (activeStatsButton)
        {
            statsPopUp.SetActive(false);
            activeStatsButton = false;
        }
        else
        {
            statsPopUp.SetActive(true);
            activeStatsButton = true;
        }
    }

    IEnumerator GameSceneAnimation()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator PlaySceneAnimation()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    IEnumerator ExitAnimation()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}
