using UnityEngine;
using System.Collections;

public class AcidPoolBehavior : MonoBehaviour
{
    float CurrGameSpeed = 1.0f;
    float animSpeed = 1.0f;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("PauseTrigger");
    }

    // Update is called once per frame
    void Update()
    {
    }

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
            anim.SetTrigger("PlayTrigger");
        }
        else
        {
            anim.SetTrigger("PauseTrigger");
        }
    }
}
