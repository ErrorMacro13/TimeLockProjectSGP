﻿using UnityEngine;
using System.Collections;

public class FireBallCannonScript : MonoBehaviour {

    float CurrGameSpeed = 1.0f;
    short SpeedCase = 0;

    public GameObject Ball;
    GameObject TempBall;

    public float BallSpeed = 3.0f;
    public float LifeSpan = 5.0f;
    public float BounceHeight = 3.0f;
    public float VertSpeed;
    public bool GoingUp;
    public bool Left = false;
    public float TimeBetweenShots;
    public float InitialDelay;
    public bool Running;
    float SavedIDelay;
    // Use this for initialization
    void Start () {
        SavedIDelay = InitialDelay;
    }

    // Update is called once per frame
    void Update () {
	}

    void FixedUpdate()
    {
        if (Running)
        {
            InitialDelay -= Time.deltaTime * CurrGameSpeed;
            if (InitialDelay <= 0.0f)
            {
                Fire();
                InitialDelay = TimeBetweenShots;
            }
        }
    }

    void Fire()
    {
        TempBall = Instantiate(Ball, transform.Find("Barrel").transform.position, transform.rotation) as GameObject;
        TempBall.transform.parent = transform;
        TempBall.SendMessage("SetLifeSpan", LifeSpan);
        TempBall.SendMessage("SetBallSpeed", BallSpeed);
        TempBall.SendMessage("SetLeft", Left);
        TempBall.SendMessage("SetBounce", BounceHeight);
        TempBall.SendMessage("SetUp", GoingUp);
        TempBall.SendMessage("SetVertSpeed", VertSpeed);
        switch (SpeedCase)
        {
            case 0:
                {
                    BroadcastMessage("SetTime", 4);
                    break;
                }
            case 1:
                {
                    BroadcastMessage("SetTime", 1);
                    break;
                }
            case 2:
                {
                    BroadcastMessage("SetTime", 2);
                    break;
                }
            case 3:
                {
                    BroadcastMessage("SetTime", 3);
                    break;
                }
        }
    }
    void SetTime(short GameSpeed)
    {
        switch (GameSpeed)
        {
            case 1:
                CurrGameSpeed = 0.5f;
                SpeedCase = 1;
                break;
            case 2:
                CurrGameSpeed = 0.25f;
                SpeedCase = 2;
                break;
            case 3:
                CurrGameSpeed = 0.0f;
                SpeedCase = 3;
                break;
            default:
                CurrGameSpeed = 1.0f;
                SpeedCase = 0;
                break;
        }
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
    
    void ResetOverWorld()
    {
        InitialDelay = SavedIDelay;
        Running = false;
    }
}
