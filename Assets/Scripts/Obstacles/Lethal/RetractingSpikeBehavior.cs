using UnityEngine;
using System.Collections;

public class RetractingSpikeBehavior : MonoBehaviour
{
    public float RetractingSpeed;
    public float RetractDelay;
    public float EmergeDelay;
    public float RDelay;
    public float GDelay;
    public bool RetractingHorizontal;
    public bool RetractingVertical;
    public GameObject anim;
    private Vector3 StartLoc;

    private bool ChangeDirection = false;
    public bool Running = false;

    private float DelayEmerge;
    private float DelayRetract;
    public float InitialDelay;
    private float CurrGameSpeed = 1.0f;
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
        transform.position = StartLoc;
        DelayEmerge = EmergeDelay;
        DelayRetract = RetractDelay;
        Running = false;
    }
    // Use this for initialization
    void Start()
    {
        StartLoc = transform.position;
        DelayEmerge = EmergeDelay;
        DelayRetract = RetractDelay;
    }

    // ChangeDirectiondate is called once per frame
    void FixedUpdate()
    {
        if (Running)
        {
            if (InitialDelay <= 0.0f)
            {
                if (RetractingVertical)
                {
                    if (ChangeDirection)
                    {
                        DelayEmerge -= Time.deltaTime * CurrGameSpeed;
                        if (DelayEmerge < 0)
                            DelayEmerge = 0;
                    }
                    else
                    {
                        DelayRetract -= Time.deltaTime * CurrGameSpeed;
                    }
                    MoveDownUp(Time.deltaTime);
                }
                else
                {
                    if (ChangeDirection)
                    {
                        DelayEmerge -= Time.deltaTime * CurrGameSpeed;
                        
                    }
                    else
                    {
                        DelayRetract -= Time.deltaTime * CurrGameSpeed;
                    }
                    MoveLeftRight(Time.deltaTime);
                }
            }
            else
                InitialDelay -= Time.deltaTime * CurrGameSpeed;

            float percent = (DelayEmerge / EmergeDelay);

            if ((percent >= 0 && percent <= .1) || (percent >= .9 && percent <= 1))
                anim.GetComponent<RetractingFloorScript>().ChangeImage(0);
            else if ((percent >= .1 && percent <= .2) || (percent >= .8 && percent <= .9))
                anim.GetComponent<RetractingFloorScript>().ChangeImage(1);
            else if ((percent >= .2 && percent <= .3) || (percent >= .7 && percent <= .8))
                anim.GetComponent<RetractingFloorScript>().ChangeImage(2);
            else if ((percent >= .3 && percent <= .4) || (percent >= .6 && percent <= .7))
                anim.GetComponent<RetractingFloorScript>().ChangeImage(3);
            else if ((percent >= .4 && percent <= .5) || (percent >= .5 && percent <= .6))
                anim.GetComponent<RetractingFloorScript>().ChangeImage(4);
        }
    }
    void MoveDownUp(float dt)
    {
        if (RDelay <= 0)
        {
            if (gameObject.transform.position.y >= StartLoc.y - gameObject.transform.lossyScale.y && !ChangeDirection && DelayRetract <= 0)
            {
                gameObject.transform.position += new Vector3(0, -RetractingSpeed * dt * CurrGameSpeed, 0);
                if (gameObject.transform.position.y <= StartLoc.y - gameObject.transform.lossyScale.y)
                {
                    ChangeDirection = true;
                    DelayRetract = RetractDelay;
                }
            }
        }
        else
            RDelay -= Time.deltaTime * CurrGameSpeed;

        if (GDelay <= 0)
        {
            if (gameObject.transform.position.y <= StartLoc.y && ChangeDirection && DelayEmerge <= 0)
            {
                gameObject.transform.position += new Vector3(0, RetractingSpeed * dt * CurrGameSpeed, 0);
                if (gameObject.transform.position.y >= StartLoc.y)
                {
                    ChangeDirection = false;
                    DelayEmerge = EmergeDelay;
                }
            }
        }
        else
            GDelay -= Time.deltaTime * CurrGameSpeed;
    }
    void MoveLeftRight(float dt)
    {
        if (gameObject.transform.position.x >= StartLoc.x - gameObject.transform.lossyScale.x && !ChangeDirection && DelayRetract <= 0)
        {
            gameObject.transform.position += new Vector3(-RetractingSpeed * dt * CurrGameSpeed, 0, 0);
            if (gameObject.transform.position.x <= StartLoc.x - gameObject.transform.lossyScale.x)
            {
                ChangeDirection = true;
                DelayRetract = RetractDelay;
            }
        }
        else if (gameObject.transform.position.x <= StartLoc.x && ChangeDirection && DelayEmerge <= 0)
        {
            gameObject.transform.position += new Vector3(RetractingSpeed * dt * CurrGameSpeed, 0, 0);
            if (gameObject.transform.position.x >= StartLoc.x)
            {
                ChangeDirection = false;
                DelayEmerge = EmergeDelay;
            }
        }
    }

    void RedTrigger(float duration)
    {
        RDelay = duration;
    }

    void GreenTrigger(float duration)
    {
        GDelay = duration;
    }

    void ToggleActive(bool isActive)
    {
        if (isActive)
            Running = true;
        else
            Running = false;
    }
}
