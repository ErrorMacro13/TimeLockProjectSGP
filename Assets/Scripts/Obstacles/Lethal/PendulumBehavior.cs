using UnityEngine;
using System.Collections;

public class PendulumBehavior : MonoBehaviour
{
    BoxCollider2D pendulumCollider;
    public Rigidbody2D player;

    public float motorSpeed = 120f;
    float CurrGameSpeed = 1.0f;
    bool nonlethal;
    bool isCatapult;
    bool collision;
    Vector2 direction;

    public HingeJoint2D hinge;
    JointMotor2D motor;
    bool swingingLeft;
    bool enabled = false;
    public Transform ball;
    // Use this for initialization
    void Start()
    {
        hinge = GetComponentInChildren<HingeJoint2D>();
        //motor = hinge.motor;
        motor.maxMotorTorque = 5000;
        motor.motorSpeed = 120;
        swingingLeft = true;
        direction = new Vector2(50, 0);
        pendulumCollider = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if ((hinge.jointAngle >= hinge.limits.max && swingingLeft) || (hinge.jointAngle <= hinge.limits.min && !swingingLeft))
        {
            swingingLeft = !swingingLeft;
            motorSpeed = -motorSpeed;
        }

        if (swingingLeft)
        {
            if(ball.rotation.y < 90)
            ball.Rotate(0, 60*Time.deltaTime * CurrGameSpeed, 0);
        }
        else
        {
            if (ball.rotation.y > -90)
            ball.Rotate(0, 60* -Time.deltaTime * CurrGameSpeed, 0);
        }


        if (nonlethal)
        {
            pendulumCollider.isTrigger = false;
            tag = "Ground";
        }
        else
        {
            nonlethal = false;
            pendulumCollider.isTrigger = true;
            tag = "Lethal";
        }


        motor.motorSpeed = motorSpeed * CurrGameSpeed;
        hinge.motor = motor;



    }

    void ToggleActive(bool isActive)
    {
        if (isActive)
            hinge.useMotor = true;
        else
            hinge.useMotor = false;
    }

    void SetTime(short GameSpeed)
    {
        switch (GameSpeed)
        {
            case 1:
                CurrGameSpeed = 0.5f;
                nonlethal = false;
                break;
            case 2:
                CurrGameSpeed = 0.25f;
                nonlethal = true;
                break;
            case 3:
                CurrGameSpeed = 0.0f;
                nonlethal = true;
                break;
            default:
                CurrGameSpeed = 1.0f;
                nonlethal = false;
                break;
        }
    }
}
