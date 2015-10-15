using UnityEngine;
using System.Collections;

public class WallTile : MonoBehaviour
{
    public SpriteRenderer sprite;
    private int total = 0;
    void Awake()
    {
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;
        childSprite.sortingOrder = sprite.sortingOrder;
        childSprite.transform.rotation = transform.rotation;
        GameObject child;
        int l = (int)(Mathf.Round(transform.localScale.y) * .5);
        for (int i = 1; i < l + 1; i++)
        {
            total++;
            child = Instantiate(childPrefab) as GameObject;
            child.transform.position = transform.position + (new Vector3(0, (spriteSize.y - .01f), 0) * i);
            child.transform.parent = transform;
        }
        for (int i = 1; i < l + 1; i++)
        {
            total++;
            child = Instantiate(childPrefab) as GameObject;
            child.transform.position = transform.position - (new Vector3(0, (spriteSize.y - .01f), 0) * i);
            child.transform.parent = transform;
        }
        childPrefab.transform.parent = transform;
        sprite.enabled = false;
        print(gameObject.name + total);
    }
}
