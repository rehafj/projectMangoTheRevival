using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform gunPosition;
    [SerializeField] GameObject bulletPrefab; 
    Camera mainCamera;
    public bool canShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot(){
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot){
            Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetWorldPosition = new Vector3(targetWorldPosition.x, targetWorldPosition.y, 0f);
            GameObject bullet = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            Vector3 direction = (targetWorldPosition - gunPosition.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 20;
            Destroy(bullet, 5f);
        }
    }

    public void setShooting(bool _canShoot)
    {
        canShoot = _canShoot;
    }
}
