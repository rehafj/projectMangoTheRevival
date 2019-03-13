using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    bool canMove = false;
    bool inTutorialPhase = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            Move();
    }

    float horizontal;
    float vertical;
    Vector2 movement;
    void Move(){
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");    

        movement = new Vector2(horizontal, vertical);
        movement = movement.normalized * speed; 
        
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    public void MovePlayer(bool _canMove)
    {
        canMove = _canMove;
        anim.SetBool("canFly", _canMove);
    }
}
