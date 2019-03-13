using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunPosition;

    [SerializeField, Range(0,10)] float shootingRate = 5f;
    [SerializeField, Range(0,10)] float bulletSpeed = 5f;

    [SerializeField] bool target = false;
    public int type = 1;

    bool inView = false;
    bool inCooldown = false;
    GameObject player; 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnBecameVisible()
    {
        inView = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(inView){
            Shoot();
        }
    }

    void Shoot(){
        GameObject bullet;
        if (!inCooldown)
        {
          
            inCooldown = true;
            if (type == 2) /// just a thought 
            {
                Vector3 newPos = new Vector3(gunPosition.position.x,
                                         gunPosition.position.y + (Random.Range(-2f, 1f)),
                                         gunPosition.position.z);
                 bullet = Instantiate(bulletPrefab, newPos, Quaternion.identity);

            }

            bullet = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            if (target){
                bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - gunPosition.position ).normalized * bulletSpeed / 2;
            }else{
                bullet.GetComponent<Rigidbody2D>().velocity = -Vector3.right * bulletSpeed; // can have the rotaion based on game object but i think  phis stops it ) can make a vector 2 though, thoughts? ( and locally rotate with patterns)  ) 
            }
            Invoke("ResetCooldown", shootingRate);
            Destroy(bullet, 5f);

         
        }
    }

    void ResetCooldown(){
        inCooldown = false;
    }
}
