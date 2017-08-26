using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public Rigidbody2D player;
		//Tu w inspektorze przeciągasz transformy, pomiędzy którymi ma się teleportować cośtam
    public Transform InPoint;
    public Transform OutPoint;

    public bool twoWay = false;
    public bool exitDirection = false;
    public float exitSpeedScale = 1f;
    public bool ConstantVelocity = false;
    public Vector2 OutVelocity;

    public LayerMask PlayerLayer; //hehe

    private bool t_enabled;

    public float r;
	
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        Debug.Log(player);
    }

	void FixedUpdate ()
    {
        if (twoWay)
            TeleportTwoWay();
        else
            TeleportOneWay();

	}

    void TeleportTwoWay()
    { 
        if (Physics2D.OverlapCircle(InPoint.position, r*transform.localScale.x, PlayerLayer) && t_enabled)
        {
            player.transform.position = OutPoint.position;
            if (exitDirection)
            {
               player.velocity = new Vector2(player.velocity.magnitude * Mathf.Cos(Mathf.Deg2Rad * OutPoint.eulerAngles.z), player.velocity.magnitude * Mathf.Sin(Mathf.Deg2Rad * OutPoint.eulerAngles.z));
               player.velocity *= exitSpeedScale;
            }
            if (ConstantVelocity)
                player.velocity = OutVelocity;

            t_enabled = false;
            return;
        }
        if (Physics2D.OverlapCircle(OutPoint.position, r * transform.localScale.x, PlayerLayer) && t_enabled)
        {
            player.transform.position = InPoint.position;
            if (exitDirection)
            {
                player.velocity = new Vector2(player.velocity.magnitude * Mathf.Cos(Mathf.Deg2Rad * InPoint.eulerAngles.z), player.velocity.magnitude * Mathf.Sin(Mathf.Deg2Rad * InPoint.eulerAngles.z));
                player.velocity *= exitSpeedScale;
            }
            if (ConstantVelocity)
                player.velocity = OutVelocity;
            t_enabled = false;
            return;
        }        
        if (!t_enabled)
            if (!Physics2D.OverlapCircle(OutPoint.position, r * transform.localScale.x, PlayerLayer) && !Physics2D.OverlapCircle(InPoint.position, r, PlayerLayer))
                t_enabled = true;
    }

    void TeleportOneWay()
    {
        if (Physics2D.OverlapCircle(InPoint.position, r, PlayerLayer))
        {
            player.transform.position = OutPoint.position;
            if (exitDirection)
            {
                player.velocity = new Vector2(player.velocity.magnitude * Mathf.Cos(Mathf.Deg2Rad * OutPoint.eulerAngles.z), player.velocity.magnitude * Mathf.Sin(Mathf.Deg2Rad * OutPoint.eulerAngles.z));
                player.velocity *= exitSpeedScale;
            }
            if (ConstantVelocity)
                player.velocity = OutVelocity;
        }
    }
}
