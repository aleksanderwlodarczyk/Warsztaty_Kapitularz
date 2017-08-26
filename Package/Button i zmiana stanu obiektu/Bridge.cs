using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {

    //public bool Clockwise;
    private HingeJoint2D Motor;
    public Button Button;
    public Rigidbody2D bridge;
    public bool bouncing = false;
  
    
    void Start ()
    {
        Motor = GetComponent<HingeJoint2D>();
	}
	
	void FixedUpdate ()
    {

        if (Button.pressed)
        {
            if (!bouncing && (Motor.jointAngle >= Motor.limits.min || Motor.jointAngle <= Motor.limits.max))
            {
                bridge.isKinematic = true;
                return;
            }
            bridge.isKinematic = false;
            Motor.enabled = true;
        }
        else
            bridge.isKinematic = true;
	}
}
