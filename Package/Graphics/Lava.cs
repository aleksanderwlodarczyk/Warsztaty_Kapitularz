using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Lava : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        // Get the current sprite with an unscaled size
        sprite = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.parent.transform.localScale.x, sprite.bounds.size.y / transform.parent.transform.localScale.y);
        spriteSize = spriteSize * transform.parent.transform.localScale.y;

        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;

        GameObject child = null;
        for (int i = 0, l = Mathf.FloorToInt(sprite.bounds.size.x / spriteSize.x); i < l; i++)
        {
            child = Instantiate(childPrefab) as GameObject;
            child.transform.parent = transform;
            child.transform.localPosition = new Vector2((-spriteSize.x * (l - 1) / 2 + i * spriteSize.x) / transform.parent.transform.localScale.x, 0);
            child.transform.localScale = new Vector2(1 / transform.parent.transform.localScale.x * transform.parent.transform.localScale.y, 1);
            child.GetComponent<SpriteRenderer>().sortingLayerID = sprite.sortingLayerID;
        }
        Destroy(childPrefab);


        sprite.gameObject.AddComponent<BoxCollider2D>();
        // Disable the currently existing sprite component since its now a repeated image
        sprite.enabled = false;
    }
}