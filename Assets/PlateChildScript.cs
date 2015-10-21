using UnityEngine;
using System.Collections;

public class PlateChildScript : MonoBehaviour {
    public Sprite ActiveImg;
    public Sprite InactiveImg;
    private Vector3 origSize;
	// Use this for initialization
	void Start () {
        origSize = transform.localScale;
	}
	// Update is called once per frame
	void Update () {
	
	}
    void Activate()
    {
        transform.localScale = origSize;
        gameObject.GetComponent<SpriteRenderer>().sprite = ActiveImg;
    }
    void Deactivate()
    {
        transform.localScale = origSize;
        gameObject.GetComponent<SpriteRenderer>().sprite = InactiveImg;
    }
}
