using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {

    private Rigidbody2D plat; //platforma
    public float MinDestroyVelocity = 0;
	
    void Start()
    {
        plat = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    		//Ustawiasz tag obiektu, który może to zniszczyć
        if (col.tag == "Util1" && (col.attachedRigidbody.velocity-plat.velocity).magnitude>MinDestroyVelocity)
            Destroy(this.gameObject);
    }
    
}
