using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Health : MonoBehaviour
{
    [SerializeField] int health = 3;
    public int currentSceneCounter=0;
    // Start is called before the first frame update
 

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "EnemyBullet")
        {
            health -= 1;
        }

        if (health <= 0)
        {
            //send fungus message to load death scene 1 - + int for current scene 
            Fungus.Flowchart.BroadcastFungusMessage("END" + currentSceneCounter.ToString());
        }
    }


}
