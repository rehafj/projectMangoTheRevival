using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 1f;

    public bool moveUp= true;
    public bool canMoveCam = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveCam)
        {
            if (moveUp)
            {
                transform.Translate(Vector3.up * movementSpeed * 0.01f);
            }
            else
            {
                transform.Translate(Vector3.right * movementSpeed * 0.01f);
            }
        }
   
    }

    public void MoveCamera(Vector3 moveAmount){
        transform.position += moveAmount;
    }

    //i relized at some point this would have been better as a manager script ( similar method across scriptS)  so for now ignore the 
    //little snippits attached to scripts 

    public void SetCanMoveCam(bool _moveCamera) {
        canMoveCam = _moveCamera;
    }
}
