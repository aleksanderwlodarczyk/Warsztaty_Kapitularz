using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(SpriteRenderer))]

public class StretchPlatform : MonoBehaviour
{
    //Y się nie zmienia
    //X się zmniejsza
    //X środka się zwiększa
    
    public SpriteRenderer LeftSide, Center, RightSide;
    public PhysicsMaterial2D ColliderMaterial;

    void Start ()
    {
        if (transform.localScale.x * 2 < transform.localScale.y)
            return;
        if (transform.localScale.x < transform.localScale.y)
            Debug.LogWarning("Center quality will be reduced");
        float rotation = transform.rotation.eulerAngles.z;
        transform.Rotate(0, 0, -rotation);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = sprite.bounds.size;

        LeftSide.transform.localScale = new Vector2(transform.localScale.y, transform.localScale.y);
        RightSide.transform.localScale = new Vector2(transform.localScale.y, transform.localScale.y);

        Center.transform.localScale = new Vector2(transform.localScale.x * 2f - transform.localScale.y, transform.localScale.y);
        if (Center.transform.localScale.x < 0)
            Center.transform.localScale = Vector2.zero;

        LeftSide.transform.localPosition = new Vector3(-sprite.bounds.size.x / 2, LeftSide.transform.localPosition.y, LeftSide.transform.localPosition.z);
        RightSide.transform.localPosition = new Vector3(sprite.bounds.size.x / 2, RightSide.transform.localPosition.y, RightSide.transform.localPosition.z);
        Center.transform.localPosition = new Vector3(Center.transform.localPosition.x, Center.transform.localPosition.y, RightSide.transform.localPosition.z);

        LeftSide.color = RightSide.color = Center.color = sprite.color;
        
        LeftSide.enabled = RightSide.enabled = Center.enabled = true;

        transform.localScale = Vector2.one;
        transform.Rotate(0, 0, rotation);

        sprite.gameObject.AddComponent<BoxCollider2D>();
        BoxCollider2D collider = sprite.gameObject.GetComponent<BoxCollider2D>();
        collider.size = spriteSize;
        collider.sharedMaterial = ColliderMaterial;

        sprite.enabled = false;


    }
}
