using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    public Animation animate;
    public AnimationClip animateClip;
    public GameObject acid;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D ent)
    {
        if (gameObject.tag != "Stop" && ent.tag == "Player")
        {
            SendMessageUpwards("Activate");
        }
    }
}