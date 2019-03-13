using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float i = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        i--;
        if (i <= 0)
        {
            if (col.transform.tag == "PlayerBullet")
            {
                Destroy(col.gameObject);
                Destroy(transform.parent.gameObject);
            }
        }
     
    }

}
