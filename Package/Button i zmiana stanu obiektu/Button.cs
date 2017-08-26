using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    public bool pressed = false;
    private Animator _animator;
    private EdgeCollider2D _edgecol;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _edgecol = GetComponent<EdgeCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (ContactPoint2D C in col.contacts)
            if (C.otherCollider == _edgecol)
            {
                pressed = true;
                _animator.SetTrigger("buttonPressed");
                _edgecol.enabled = false;
            }

    }

}
