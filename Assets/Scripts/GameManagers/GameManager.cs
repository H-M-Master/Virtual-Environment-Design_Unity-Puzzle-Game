using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ContinueGame()
    {
        UIManager.instance.UIPanels[4].SetActive(false);
        UIManager.instance.HideBlur();
    }

    public void Esc()
    {
        UIManager.instance.UIPanels[4].SetActive(true);
        UIManager.instance.ShowBlur();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
        PublicAttribute.Instance.isHaveAKey = false;
    }

    public void BtnNext()
    {
        SceneManager.LoadScene(1);
    }

    public void GameWin()
    {

        UIManager.instance.UIPanels[5].SetActive(true);
        UIManager.instance.HideBlur();
    }
}
