using UnityEngine;
using UnityEngine.UI;
public class Punkty : MonoBehaviour {
    public int punkty;
    public Text ZbieranieMonety;
	void Start () {
        punkty = 0;
	}
    public void DodajPunkt(){
        punkty++;
        ZbieranieMonety.text ="Punkty: " + punkty.ToString();
    }
}
