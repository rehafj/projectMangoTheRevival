using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    // Start is called before the first frame update
  void OnCollisionEnter2D(Collision2D col) //question why did we not shoose col as triggers - effect? 
    {
        if (col.transform.tag == "EnemyBullet");
                Destroy(gameObject);

}

}
