using UnityEngine;
using System.Collections;

public class SpinningBladeBehavior : MonoBehaviour
{
    float CurrGameSpeed = 1.0f;
    public float rotateSpeed = 10.0f;
    public bool Clockwise = false;
    public bool Running;
    float timing;
    bool played = false;
    Transform player;
    AudioSource bladeWhirl;

    // Use this for initialization
    void Start()
    {
        //GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.25f);
        timing = Time.time;
        player = GameObject.Find("Player").GetComponent<Transform>();
        bladeWhirl = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Running)
        {
            if (!Clockwise)
                transform.Rotate(0, 0, rotateSpeed * CurrGameSpeed * Time.timeScale);
            else
                transform.Rotate(0, 0, -rotateSpeed * CurrGameSpeed * Time.timeScale);


            if (CurrGameSpeed < 0.25f)
            {
                tag = "Untagged";
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
            }
            else if (CurrGameSpeed >= 0.25f)
            {
                tag = "Lethal";
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        if (Vector3.Distance(player.position, transform.position) <= 10f)
        {
            if (timing < Time.time)
            {
                played = true;
                timing = Time.time + 10;
            }
        }
        else if (Vector3.Distance(player.position, transform.position) >= 10f)
            bladeWhirl.Stop();

        if (played)
        {
            bladeWhirl.Play();
            played = false;
        }
    }

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

    void ResetOverWorld()
    {

    }
    void ToggleActive(bool isActive)
    {
        if (isActive)
        {
            Running = true;
        }
        else
        {
            Running = false;
        }
    }
}
