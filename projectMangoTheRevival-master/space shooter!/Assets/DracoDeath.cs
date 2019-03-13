using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracoDeath : MonoBehaviour
{
    [SerializeField]
    bool isDead = false;
    [SerializeField]
    float timer = 500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && !isDead)
        {
            timer = 4;
            //Draco 1 is a fungus block - to remind the player so they wouldshoot draco if he is alive  --- 
            Fungus.Flowchart.BroadcastFungusMessage("Draco1");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "PlayerBullet")
        {
            isDead = true;
            Fungus.Flowchart.BroadcastFungusMessage("MOVEPLAYER");

            Destroy(gameObject);
            Destroy(col.gameObject);


        }
    }
    public void startCountdown(float _timer)
    {
        timer = _timer;
    }



}
