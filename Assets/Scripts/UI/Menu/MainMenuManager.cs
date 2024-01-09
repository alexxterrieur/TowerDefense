using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject creditPanel;

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenCredit()
    {
        creditPanel.SetActive(true);
    }

    public void CloseCredit()
    {
        creditPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
