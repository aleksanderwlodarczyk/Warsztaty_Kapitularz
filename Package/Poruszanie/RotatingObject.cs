using UnityEngine;
using System.Collections;

public class RotatingObject : MonoBehaviour
{
    private Rigidbody2D _rbody;
    public bool Clockwise = true;
    public float DegPerSec = 5;

    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _rbody.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (!Clockwise)
            _rbody.MoveRotation(DegPerSec*Time.time);
        else
            _rbody.MoveRotation(-DegPerSec * Time.time);
    }
}
