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
    float timing;
    bool played = false;
    Transform player;
    AudioSource fanWhirl;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("PauseTrigger");
        timing = Time.time;
        player = GameObject.Find("Player").GetComponent<Transform>();
        fanWhirl = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= 10f)
        {
            if (timing < Time.time)
            {
                played = true;
                timing = Time.time + 10;
            }
        }
        else if (Vector3.Distance(player.position, transform.position) >= 10f)
            fanWhirl.Stop();

        if (played)
        {
            fanWhirl.Play();
            played = false;
        }
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
