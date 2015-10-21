using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseScript : MonoBehaviour
{
    public bool paused;
    public bool mainPause = false;
    public bool isInstructions = false;
    public bool isSettings = false;

    public Canvas mainCanvas;
    public Canvas settingsCanvas;
    public Canvas instructionsCanvas;

    Button resumeGameMain;
    Button settings;
    Button instructions;
    Button mainMenu;
    Button quitGame;

    [SerializeField]
    Toggle fsToggle;
    [SerializeField]
    Slider masterVolume;
    [SerializeField]
    Slider bgmVolume;
    [SerializeField]
    Slider sfxVolume;
    Button backSettings;
    Button resumeGameSettings;

    Button prev;
    Button next;
    Button backInstructions;
    Button resumeGameInstructions;

    EventSystem eventSystem;

    //public Texture pauseOverlay;


    // Use this for initialization
    void Start()
    {
        mainCanvas.enabled = false;
        settingsCanvas.enabled = false;
        instructionsCanvas.enabled = false;
        instructionsCanvas.GetComponentInChildren<InstructionArrayScript>().enabled = false;

        resumeGameMain = GameObject.Find("Resume Game").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();
        instructions = GameObject.Find("Instructions").GetComponent<Button>();
        mainMenu = GameObject.Find("Main Menu").GetComponent<Button>();
        quitGame = GameObject.Find("Quit Game").GetComponent<Button>();

        backSettings = GameObject.Find("BackS").GetComponent<Button>();
        resumeGameSettings = GameObject.Find("Resume GameS").GetComponent<Button>();

        prev = GameObject.Find("Prev").GetComponent<Button>();
        next = GameObject.Find("Next").GetComponent<Button>();
        backInstructions = GameObject.Find("BackI").GetComponent<Button>();
        resumeGameInstructions = GameObject.Find("Resume GameI").GetComponent<Button>();

        resumeGameMain.interactable = false;
        settings.interactable = false;
        instructions.interactable = false;
        mainMenu.interactable = false;
        quitGame.interactable = false;
        fsToggle.interactable = false;
        masterVolume.interactable = false;
        bgmVolume.interactable = false;
        sfxVolume.interactable = false;
        backSettings.interactable = false;
        resumeGameSettings.interactable = false;
        prev.interactable = false;
        next.interactable = false;
        backInstructions.interactable = false;
        resumeGameInstructions.interactable = false;

        //eventSystem = GetComponent<EventSystem>();
        //eventSystem.sendNavigationEvents = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isSettings && !isInstructions)
                TogglePause();
            else if (isSettings)
            {
                SwitchSettings();
            }
            else if (isInstructions)
            {
                SwitchInstructions();
            }
        }

        if (paused)
        {
            //GUI.DrawTexture(overlayRect, pauseOverlay);
            if (mainPause)
            {
                //eventSystem.sendNavigationEvents = true;
                resumeGameMain.interactable = true;
                settings.interactable = true;
                instructions.interactable = true;
                mainMenu.interactable = true;
                quitGame.interactable = true;


                fsToggle.interactable = false;
                masterVolume.interactable = false;
                bgmVolume.interactable = false;
                sfxVolume.interactable = false;
                backSettings.interactable = false;
                resumeGameSettings.interactable = false;


                prev.interactable = false;
                next.interactable = false;
                backInstructions.interactable = false;
                resumeGameInstructions.interactable = false;

            }
            else if (isSettings)
            {

                //eventSystem.sendNavigationEvents = true;
                fsToggle.interactable = true;
                masterVolume.interactable = true;
                bgmVolume.interactable = true;
                sfxVolume.interactable = true;
                backSettings.interactable = true;
                resumeGameSettings.interactable = true;


                resumeGameMain.interactable = false;
                settings.interactable = false;
                instructions.interactable = false;
                mainMenu.interactable = false;
                quitGame.interactable = false;


                prev.interactable = false;
                next.interactable = false;
                backInstructions.interactable = false;
                resumeGameInstructions.interactable = false;

               // eventSystem.SetSelectedGameObject(backSettings.gameObject);

            }
            else if (isInstructions)
            {

                //eventSystem.sendNavigationEvents = true;
                prev.interactable = true;
                next.interactable = true;
                backInstructions.interactable = true;
                resumeGameInstructions.interactable = true;


                resumeGameMain.interactable = false;
                settings.interactable = false;
                instructions.interactable = false;
                mainMenu.interactable = false;
                quitGame.interactable = false;



                fsToggle.interactable = false;
                masterVolume.interactable = false;
                bgmVolume.interactable = false;
                sfxVolume.interactable = false;
                backSettings.interactable = false;
                resumeGameSettings.interactable = false;
                //eventSystem.SetSelectedGameObject(backInstructions.gameObject);

            }

        }
    }

    void TogglePause()
    {
        if (Time.timeScale <= 0f)
        {
            mainCanvas.enabled = false;
            mainPause = false;         
            paused = false;
            Time.timeScale = 1f;
            Unpause();
        }
        else
        {
            mainCanvas.enabled = true;
            mainPause = true;
            paused = true;
            Time.timeScale = 0f;      
        }
    }

    void SwitchSettings()
    {
        mainPause = !mainPause;
        isSettings = !isSettings;
        mainCanvas.enabled = !mainCanvas.enabled;
        settingsCanvas.enabled = !settingsCanvas.enabled;
    }

    void SwitchInstructions()
    {
        mainPause = !mainPause;
        isInstructions = !isInstructions;
        mainCanvas.enabled = !mainCanvas.enabled;
        instructionsCanvas.enabled = !instructionsCanvas.enabled;
        instructionsCanvas.GetComponentInChildren<InstructionArrayScript>().enabled = !instructionsCanvas.GetComponentInChildren<InstructionArrayScript>().enabled;
    }

    void Unpause()
    {
        Time.timeScale = 1f;
        paused = false;
        isSettings = false;
        isInstructions = false;
        mainCanvas.enabled = false;
        settingsCanvas.enabled = false;
        instructionsCanvas.enabled = false;
        instructionsCanvas.GetComponentInChildren<InstructionArrayScript>().enabled = false;
        resumeGameMain.interactable = false;
        settings.interactable = false;
        instructions.interactable = false;
        mainMenu.interactable = false;
        quitGame.interactable = false;
        fsToggle.interactable = false;
        masterVolume.interactable = false;
        bgmVolume.interactable = false;
        sfxVolume.interactable = false;
        backSettings.interactable = false;
        resumeGameSettings.interactable = false;
        prev.interactable = false;
        next.interactable = false;
        backInstructions.interactable = false;
        resumeGameInstructions.interactable = false;
    }
}
