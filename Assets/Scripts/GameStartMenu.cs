using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject LogInPanel;
    public GameObject RegisterPanel;
    public GameObject StartPanel;
    public GameObject options;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button configuartionButton;
    public Button optionButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        //Hook events
        startButton.onClick.AddListener(StartGame);
        configuartionButton.onClick.AddListener(ConfigurationMenu);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        HideAll();
        StartPanel.SetActive(true);
    }

    public void HideAll()
    {
        LogInPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    public void EnableLogInPanel()
    {
        LogInPanel.SetActive(true);
        RegisterPanel.SetActive(false);
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    public void EnableMainMenu()
    {
        LogInPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }

    public void ConfigurationMenu()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
        LogInPanel.SetActive(false);
        RegisterPanel.SetActive(false);
    }

    public void EnableAbout()
    {
        LogInPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }
}
