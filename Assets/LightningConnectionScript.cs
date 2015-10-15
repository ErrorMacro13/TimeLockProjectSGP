using UnityEngine;
using System.Collections;

public class LightningConnectionScript : MonoBehaviour
{
    private bool rotate = false;
    public GameObject player;
    private Vector3 dad;
    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        dad = GetComponentInParent<Transform>().position;
        player = GameObject.Find("Player");
    }
    public float width = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotate)
        {
            print("DAD " + dad.x.ToString());
            print("Player " + player.transform.position.x.ToString());
            //print("Calculated" + (player.transform.position.x - dad.x).ToString());

            transform.position = new Vector3(dad.x + ((player.transform.position.x - dad.x) * 0.5f), dad.y, 1);
            transform.localScale = new Vector3(width * .5f, transform.localPosition.x, 5);
            transform.rotation = Quaternion.AngleAxis(90 - (Mathf.Rad2Deg * Mathf.Atan((dad.y * 2) / (transform.localPosition.x * 2))), Vector3.forward);
        }
    }

    void Show(Collider2D other)
    {
        rotate = true;
        //transform.localScale = new Vector3(1, 1, 1);
        //GetComponent<Animator>().SetFloat("Play", 0);
    }
    void Hide()
    {
        rotate = false;
        transform.localScale = new Vector3(0, 0, 0);
        //GetComponent<Animator>().SetFloat("Play", 2);
    }
}
