using UnityEngine;

public class IleMonetDoWygranej : MonoBehaviour {
    public int IleMonet;
    private int punkty = GameObject.FindGameObjectWithTag("Player").GetComponent<Punkty>().punkty;
	void Update () {
        if(punkty==IleMonet)
        {
            //win();
        }
	}
}
