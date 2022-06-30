using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Character_State))]
[System.Serializable]
public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float Drag;
    public float JumpHeight;

    private Rigidbody2D rb;
    private Character_State Character;
    private float speed;
    private float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        
        
        Character = GetComponent<Character_State>();
        Debug.Log("Player_Movement Starting");
        rb = Character.rb;
        speed = Speed*rb.mass;
        jumpHeight = JumpHeight*rb.mass;
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpHeight);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        float walk = Input.GetAxis("Horizontal")*speed;
        float jump = Input.GetAxis("Jump");
        
        if(Character.IsGrounded())
        {
            if(Input.GetAxis("Jump") == 1)
            {
                Jump();
            }
        }
        


        //Makes a new Vector3 by which to move the player by.
        Vector3 horizontalMovement = new Vector3(walk,0,0);
        //Adds force to the player
        rb.AddForce(horizontalMovement, ForceMode2D.Force);
        //Adds drag to the player
        rb.drag = Drag;
    }
}

