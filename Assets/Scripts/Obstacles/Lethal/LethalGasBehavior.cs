using UnityEngine;
using System.Collections;

public class LethalGasBehavior : MonoBehaviour
{
    public float killTime = 5.0f;

    bool isColliding = false;

    Animator anim;
    float animSpeed = 1.0f;

    float CurrGameSpeed = 1.0f;

    public bool Running;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("PauseTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            killTime -= Time.deltaTime;
        }
        else
        {
            killTime = 5.0f;
        }

        if (killTime <= 0.0f)
        {
            tag = "Lethal";
        }
        else
        {
            tag = "Untagged";
        }
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
                anim.speed = animSpeed * CurrGameSpeed;
                break;
            case 2:
                CurrGameSpeed = 0.25f;
                anim.speed = animSpeed * CurrGameSpeed;
                break;
            case 3:
                CurrGameSpeed = 0.0f;
                anim.speed = animSpeed * CurrGameSpeed;
                break;
            default:
                CurrGameSpeed = 1.0f;
                anim.speed = animSpeed * CurrGameSpeed;
                break;
        }
    }
    void ToggleActive(bool isActive)
    {
        if (isActive)
        {
            Running = true;
            anim.SetTrigger("PlayTrigger");
        }
        else
        {
            Running = false;
            anim.SetTrigger("PauseTrigger");
        }
    }
}

