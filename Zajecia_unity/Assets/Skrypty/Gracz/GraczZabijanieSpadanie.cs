using UnityEngine;
public class GraczZabijanieSpadanie : MonoBehaviour{
    private GameObject Player;
    private void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update(){
        if (Player.transform.position.y < 0){
            Player.GetComponent<Gracz>().Respawn();
        }
    }
}