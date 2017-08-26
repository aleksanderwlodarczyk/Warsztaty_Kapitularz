using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour
{
    public BoxCollider2D _boxcol;
    private bool on = true;

    void FixedUpdate()
    {
        on = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            on = false;
    }

    void Update()
    {
        _boxcol.enabled = on;
    }
}
