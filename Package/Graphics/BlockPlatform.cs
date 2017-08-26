using UnityEngine;
using System.Collections;

public class BlockPlatform : MonoBehaviour
{
    public SpriteRenderer Top, Bottom, Right, Left, TopLeft, TopRight, BottomLeft, BottomRight, Center;
    public bool smallScale = true;
    public bool physical = true;
    public PhysicsMaterial2D ColliderMaterial;
	void Awake ()
    {
        
        float rotation = transform.rotation.eulerAngles.z;
        transform.Rotate(0, 0, -rotation);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = sprite.bounds.size;

        if ( ((transform.localScale.x < transform.localScale.y) && smallScale) || (transform.localScale.x > transform.localScale.y) && !smallScale)
        {
            TopLeft.transform.localScale = TopRight.transform.localScale = BottomLeft.transform.localScale = BottomRight.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.x);
            Top.transform.localScale = Bottom.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.x);
            Left.transform.localScale = Right.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * 2f - transform.localScale.x);
            Center.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * 2f - transform.localScale.x);

            TopLeft.transform.localPosition = new Vector2(-spriteSize.x / 2, spriteSize.y / 2);
            BottomLeft.transform.localPosition = new Vector2(-spriteSize.x / 2, -spriteSize.y / 2);
            TopRight.transform.localPosition = new Vector2(spriteSize.x / 2, spriteSize.y / 2);
            BottomRight.transform.localPosition = new Vector2(spriteSize.x / 2, -spriteSize.y / 2);
            Top.transform.localPosition = new Vector2(0, spriteSize.y / 2);
            Bottom.transform.localPosition = new Vector2(0, -spriteSize.y / 2);
            Left.transform.localPosition = new Vector2(-spriteSize.x / 2, 0);
            Right.transform.localPosition = new Vector2(spriteSize.x / 2, 0);

            TopLeft.sortingLayerID = Top.sortingLayerID = TopRight.sortingLayerID = Left.sortingLayerID = Center.sortingLayerID = Right.sortingLayerID = BottomLeft.sortingLayerID = Bottom.sortingLayerID = BottomRight.sortingLayerID = GetComponent<SpriteRenderer>().sortingLayerID;
        }
        else
        {
            TopLeft.transform.localScale = TopRight.transform.localScale = BottomLeft.transform.localScale = BottomRight.transform.localScale = new Vector2(transform.localScale.y, transform.localScale.y);
            Top.transform.localScale = Bottom.transform.localScale = new Vector2(transform.localScale.x * 2f - transform.localScale.y, transform.localScale.y);
            Left.transform.localScale = Right.transform.localScale = new Vector2(transform.localScale.y, transform.localScale.y);
            Center.transform.localScale = new Vector2(transform.localScale.x * 2f - transform.localScale.y, transform.localScale.y);


            TopLeft.transform.localPosition = new Vector2(-spriteSize.x/2, spriteSize.y/2);
            BottomLeft.transform.localPosition = new Vector2(-spriteSize.x/2, -spriteSize.y/2);
            TopRight.transform.localPosition = new Vector2(spriteSize.x/2, spriteSize.y/2);
            BottomRight.transform.localPosition = new Vector2(spriteSize.x / 2, -spriteSize.y / 2);
            Top.transform.localPosition = new Vector2(0, spriteSize.y/2);
            Bottom.transform.localPosition = new Vector2(0, -spriteSize.y / 2);
            Left.transform.localPosition = new Vector2(-spriteSize.x / 2, 0);
            Right.transform.localPosition = new Vector2(spriteSize.x / 2, 0);

        }
        Top.color = Bottom.color = Right.color = Left.color = TopLeft.color = TopRight.color = BottomLeft.color = BottomRight.color = Center.color = sprite.color;
        Top.enabled = Bottom.enabled = Right.enabled = Left.enabled = TopLeft.enabled = TopRight.enabled = BottomLeft.enabled = BottomRight.enabled = Center.enabled = true;

        transform.localScale = Vector2.one;
        transform.Rotate(0, 0, rotation);

        if (physical)
        {
            sprite.gameObject.AddComponent<BoxCollider2D>();
            BoxCollider2D collider = sprite.gameObject.GetComponent<BoxCollider2D>();
            collider.size = spriteSize;
            collider.sharedMaterial = ColliderMaterial;
        }

        sprite.enabled = false;
    }

}
