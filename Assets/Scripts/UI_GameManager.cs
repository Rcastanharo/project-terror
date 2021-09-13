using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameManager : MonoBehaviour
{

    #region Global Variables

    [SerializeField]
    GameObject uI_GameManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseIntroMenu()
    {
        uI_GameManager.transform.Find("Intro").gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void EnableDisableCreditTextBox()
    {
        GameObject textBox;
        textBox = uI_GameManager.transform.Find("Intro").gameObject;
        textBox = textBox.transform.Find("textBoxCredit").gameObject;

        if (textBox.activeSelf)
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
        }
    }

    public void EnableDisablePauseScreen()
    {

        GameObject pauseMenu;
        pauseMenu = uI_GameManager.transform.Find("pauseMenu").gameObject;

        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    
}
