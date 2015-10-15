using UnityEngine;
using System.Collections;

public class FanBehavior : MonoBehaviour
{
    float CurrGameSpeed = 1.0f;
    public float magnitude = 20;
    public float buffer = 0;
    public AreaEffector2D aEffector;

    Animator anim;
    float animSpeed = 1.0f;

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
                buffer = 5;
                break;
            case 2:
                CurrGameSpeed = 0.25f;
                buffer = 5;
                break;
            case 3:
                CurrGameSpeed = 0.0f;
                buffer = 0;
                break;
            default:
                CurrGameSpeed = 1.0f;
                buffer = 0;
                break;
        }
        aEffector.forceMagnitude = (magnitude * CurrGameSpeed) + buffer;
        anim.speed = animSpeed * CurrGameSpeed;
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
