using UnityEngine;
using System.Collections;

public class LethalGasBehavior : MonoBehaviour
{
    public float killTime = 5.0f;

    bool isColliding = false;

    Animator anim;
    float animSpeed = 1.0f;

    float CurrGameSpeed = 1.0f;

    public Texture lethalGasOverlay;
    float gasValue;
    public bool Running;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<Animator>().SetTrigger("PauseTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            killTime -= Time.deltaTime;
            gasValue += 0.25f * Time.deltaTime;
        }
        else
        {
            killTime = 5.0f;
            if (gasValue > 0)
            gasValue -= Time.deltaTime;
        }

        if (killTime <= 0.0f)
        {
            tag = "Lethal";
        }
        else
        {
            tag = "Untagged";
        }


        anim.speed = animSpeed * CurrGameSpeed;
    }

    void OnGUI()
    {
        GUI.color = new Color(34, 139, 34, gasValue);

        Rect overlayRect = new Rect(new Vector3(0, 0, -20), new Vector2(Screen.width, Screen.height));
        GUI.DrawTexture(overlayRect, lethalGasOverlay);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = false;
        }
    }

    void ResetOverWorld() { tag = "Untagged"; }
    void SetTime(short GameSpeed)
    {
        switch (GameSpeed)
        {
            case 1:
                CurrGameSpeed = 0.5f;
                break;
            case 2:
                CurrGameSpeed = 0.25f;
                break;
            case 3:
                CurrGameSpeed = 0.0f;
                break;
            default:
                CurrGameSpeed = 1.0f;
                break;
        }
    }
    void ToggleActive(bool isActive)
    {
        if (isActive)
        {
            Running = true;
            GetComponent<Animator>().SetTrigger("PlayTrigger");
        }
        else
        {
            Running = false;
            GetComponent<Animator>().SetTrigger("PauseTrigger");
        }
    }
}

