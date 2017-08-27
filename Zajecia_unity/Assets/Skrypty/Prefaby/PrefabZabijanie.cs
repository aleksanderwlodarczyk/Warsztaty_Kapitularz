using UnityEngine;

public class PrefabZabijanie: MonoBehaviour{
    private GameObject Player;
    private void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == Player){
            Player.GetComponent<Gracz>().Respawn();
        }
    }
}