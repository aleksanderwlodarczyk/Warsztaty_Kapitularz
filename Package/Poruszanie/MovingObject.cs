using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{
		//Tu się chyba przeciągało w inspektorze jakieś 2 transformy, pomiędzy którymi obiekt miał się poruszać w linii prostej
    public float speed = 5f;
    public Transform max_up_pos;
    public Transform max_down_pos;
    private Vector2 A, B;
    private Rigidbody2D r;
    private Vector2 direction;
    private Vector2 dest;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();

        A = max_up_pos.position;
        B = max_down_pos.position;

        SetDes(A);
    }

    void FixedUpdate()
    {
        r.MovePosition(r.position + direction * speed * Time.fixedDeltaTime);
        r.MovePosition(r.position + direction * speed * Time.fixedDeltaTime);

        if (Vector2.Distance(r.position, dest) < 0.1)
            SetDes(dest == A ? B : A);
    }

    void SetDes(Vector2 d)
    {
        dest = d;
        direction = (dest - (Vector2)r.position).normalized;
    }
}
