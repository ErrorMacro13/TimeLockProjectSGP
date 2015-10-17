using UnityEngine;
using System.Collections;

public class AcidPoolBehavior : MonoBehaviour
{
    float CurrGameSpeed = 1.0f;
    float animSpeed = 1.0f;
    Animator anim;
    Transform player;
    AudioSource acidBubble;
    bool isBubbling = false;
    bool played;
    float timing;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("PauseTrigger");
        player = GameObject.Find("Player").GetComponent<Transform>();
        acidBubble = GetComponent<AudioSource>();
        played = false;
        timing = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(player.position, transform.position) <= 5f)
        {
            if (timing < Time.time)
            {
                played = true;
                timing = Time.time + 10;
            }
        }
        else if (Vector3.Distance(player.position, transform.position) >= 5f)
            acidBubble.Stop();

        if (played)
        {
            acidBubble.Play();
            played = false;
        }


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
