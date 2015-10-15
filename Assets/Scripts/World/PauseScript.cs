using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{
    bool paused = false;
    bool mainPause = false;
    bool isInstructions = false;
    bool isSettings = false;

    public Canvas mainCanvas;
    public Canvas settingsCanvas;
    public Canvas instructionsCanvas;
    //public Texture pauseOverlay;
    public Camera mainCam;

    // Use this for initialization
    void Start()
    {
        mainCanvas.enabled = false;
        settingsCanvas.enabled = false;
        instructionsCanvas.enabled = false;
        instructionsCanvas.GetComponentInChildren<InstructionArrayScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isSettings && !isInstructions)
            paused = TogglePause();
            else if (isSettings)
            {
                SwitchSettings();
            }
            else if (isInstructions)
            {
                SwitchInstructions();
            }
        }
    }

    bool TogglePause()
    {
        if (Time.timeScale <= 0f)
        {
            Time.timeScale = 1f;
            mainPause = false;
            mainCanvas.enabled = false;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            mainPause = true;
            mainCanvas.enabled = true;
            return (true);
        }
    }

    void OnGUI()
    {


        //Rect overlayRect = new Rect(new Vector3(0, 0, -20), new Vector2(Screen.width, Screen.height));
      
        if (paused)
        {
            //GUI.DrawTexture(overlayRect, pauseOverlay);
            if (mainPause)
            {
                settingsCanvas.enabled = false;
                instructionsCanvas.enabled = false;
            }
            else if(isSettings)
            {
                settingsCanvas.enabled = true;
            }
            else if (isInstructions)
            {
                instructionsCanvas.enabled = true;
                instructionsCanvas.GetComponentInChildren<InstructionArrayScript>().enabled = true;

}
            
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
        paused = false;
        TogglePause();
        isSettings = false;
        isInstructions = false;
        settingsCanvas.enabled = false;
        instructionsCanvas.enabled = false;
        instructionsCanvas.GetComponentInChildren<InstructionArrayScript>().enabled = false;
    }
}
