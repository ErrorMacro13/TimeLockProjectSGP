using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite RightSideSprite;
    public Sprite LeftSideSprite;
    private int total;
    public int RightTrim = 0;
    public int LeftTrim = 0;
    void Awake()
    {
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

        GameObject CenterPrefab = new GameObject();
        SpriteRenderer childSprite = CenterPrefab.AddComponent<SpriteRenderer>();
        CenterPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;
        childSprite.transform.rotation = transform.rotation;
        childSprite.sortingOrder = 4;

        GameObject child;
        int l = (int)(Mathf.Round(transform.localScale.x) * .5);
        for (int i = 1; i < l + 1; i++)
        {
            total++;
            child = Instantiate(CenterPrefab) as GameObject;
            child.transform.position = transform.position + (new Vector3(spriteSize.x, 0, 0) * i);
            child.transform.parent = transform;

        }
        for (int i = 1; i < l + 1; i++)
        {
            total++;
            child = Instantiate(CenterPrefab) as GameObject;
            child.transform.position = transform.position - (new Vector3(spriteSize.x, 0, 0) * i);
            child.transform.parent = transform;

        }
        CenterPrefab.transform.parent = transform;
        sprite.enabled = false;
    }
}