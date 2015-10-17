using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeslaAnimationScript : MonoBehaviour
{
    public GameObject[] images;
    public float TimeBetweenArcs = 0.5f;
    private float ArcTime;
    private float ArcLength;
    public float MaxArcs = 5;
    private bool Hiden = false;
    bool Running = false;
    void Start()
    {
        Show();
        ArcTime = TimeBetweenArcs;
        for (int i = 0; i < 9; i++)
        {
            images[i].GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        }
    }
    void Hide()
    {
        Hiden = true;
        for (int i = 0; i < 9; i++)
        {
            images[i].GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        }
    }
    void Show()
    {
        Hiden = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Running)
        {
            if (!Hiden)
            {
                if (ArcTime <= 0)
                {
                    ArcTime = TimeBetweenArcs;
                    for (int i = 0; i < 9; i++)
                    {
                        images[i].GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
                    }
                    for (int i = 0; i < Random.Range(1, MaxArcs); i++)
                    {
                        int index = Random.Range(0, 8);
                        if (images[index].GetComponent<Transform>().localScale != new Vector3(1, 1, 1))
                            images[index].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                    }
                }
                else ArcTime -= Time.deltaTime;
            }
            else
            {

            }
        }
    }
    void ResetOverWorld()
    {
        Start();
    }
    void ToggleActive(bool isActive)
    {
        if (isActive)
            Running = true;
        else
            Running = false;
    }
}
