using UnityEngine;
using System.Collections;

public class DestroyingObject : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
            col.gameObject.SetActive(false);
    }
}
