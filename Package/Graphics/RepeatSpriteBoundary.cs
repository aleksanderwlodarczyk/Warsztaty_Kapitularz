using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class RepeatSpriteBoundary : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        // Get the current sprite with an unscaled size
        sprite = GetComponent<SpriteRenderer>();
        //Debug.Log(sprite.bounds.size);
        //Debug.Log((Vector2)transform.localScale);
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);
        //Debug.Log(spriteSize);

        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;
        //Debug.Log(childSprite.bounds.size);

        // Loop through and spit out repeated tiles
        GameObject child = null;
        for (int i1 = 0, l1 = (int)(Mathf.Round(sprite.bounds.size.x) / spriteSize.x); i1 < l1; i1++)
        {
            child = Instantiate(childPrefab) as GameObject;
            
            child.transform.parent = transform;
            child.transform.localPosition = new Vector2(-spriteSize.x/2, 0) + (new Vector2(spriteSize.x * i1 + spriteSize.x / 2, 0));
            child.transform.localScale = new Vector2(1 / transform.localScale.x, transform.localScale.y);
            Debug.Log(transform.localScale);
        }
        Destroy(childPrefab);

        // Disable the currently existing sprite component since its now a repeated image
        sprite.enabled = false;
    }
}