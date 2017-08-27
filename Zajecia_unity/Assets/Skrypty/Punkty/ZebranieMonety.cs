using UnityEngine;
public class ZebranieMonety : MonoBehaviour
{
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
            Player.GetComponent<Punkty>().DodajPunkt();
            Destroy(gameObject);
    }
}
