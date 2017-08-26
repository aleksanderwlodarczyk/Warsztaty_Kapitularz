using UnityEngine;
using System.Collections;

public class ButtonSwitchState : MonoBehaviour {

    public GameObject ObjectToSwitchState;
    private Button _button;

    private bool ObjectBool = true;
    private bool changed = false;

	void Start ()
    {
        _button = GetComponent<Button>();
        if (ObjectToSwitchState == null)
            ObjectBool = false;
        Debug.Log(ObjectToSwitchState);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (_button.pressed && !changed)
        {
            if (ObjectBool)
                ObjectToSwitchState.SetActive(!ObjectToSwitchState.activeSelf);
            changed = true;
        }
	}
}
