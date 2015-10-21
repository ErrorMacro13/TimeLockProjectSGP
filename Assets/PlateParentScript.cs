using UnityEngine;
using System.Collections;

public class PlateParentScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BroadcastThis(string msg)
    {
        BroadcastMessage(msg);
    }
}
