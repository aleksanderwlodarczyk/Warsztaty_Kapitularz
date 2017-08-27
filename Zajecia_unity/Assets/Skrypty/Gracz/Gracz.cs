using UnityEngine;
public class Gracz : MonoBehaviour {
	private Vector3 startPos;
	void Start () {
		startPos = transform.position;
	}
	public void Respawn(){
		transform.position = startPos;
	}
}
