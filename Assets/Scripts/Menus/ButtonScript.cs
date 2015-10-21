using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

    public GameObject SoundManager;
    public GameObject mainCamera;
    public GameObject levelScroll;
    Button button;
    // Use this for initialization
    void Start()
    {
        SoundManager = GameObject.Find("SoundManager");
        mainCamera = GameObject.Find("Main Camera");
        levelScroll = GameObject.Find("LevelScroll");
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ArcadeMode()
    {
        SoundManager.SendMessage("ArcadeState");
        Destroy(GameObject.Find("LevelScroll"));
    }

    public void FreePlay()
    {
        SoundManager.SendMessage("FreePlayState");
        Destroy(GameObject.Find("LevelScroll"));
    }

    public void ButtonClick(string name)
    {
        if (name != "Back")
            SoundManager.SendMessage("In");
        else
            SoundManager.SendMessage("Out");
        Application.LoadLevel(name);
    }

    public void ChangeImages(string name)
    {
        SendMessageUpwards(name);

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void OnMouseEnter()
    {
        SoundManager.SendMessage("Hovered");
        print(name);
        //if (mainCamera != null)
        //    mainCamera.SendMessage("Hovered", true);

    }

    public void OnMouseExit()
    {
        //if (mainCamera != null)
        //    mainCamera.SendMessage("Hovered", false);
    }

    public void LevelSelect(int level)
    {
        if (levelScroll != null)
            levelScroll.SendMessage("LevelHover", level);
    }

    public void LevelUnlock()
    {
        if (levelScroll != null)
            levelScroll.SendMessage("Unlock");
    }

    public void ToggleFS()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SwitchSettingsCanvas()
    {
        GameObject.Find("GameOverWorld").SendMessage("SwitchSettings");
    }

    public void SwitchInstructionsCanvas()
    {
        GameObject.Find("GameOverWorld").SendMessage("SwitchInstructions");
    }

    public void Unpause()
    {
        GameObject.Find("GameOverWorld").SendMessage("Unpause");
    }

    public void MainMenu()
    {
        GameObject.Find("GameOverWorld").SendMessage("Unpause");
        Application.LoadLevel("MainMenu");
    }

    public void Interactable(bool b)
    {
        if (b)
            button.interactable = true;      
        else
            button.interactable = false;
    }
}
