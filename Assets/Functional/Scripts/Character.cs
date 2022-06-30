using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isTalking()
    {
        return false;
    }
    public bool isGrounded()
    {      
        return Physics2D.BoxCast(transform.position, new Vector2(transform.localScale.x, transform.localScale.y), 0f, Vector2.down, 1.2f, game.ground);
        
    }
    public void Jump(float jumpPower, bool jumpCont)
    {
        if (jumpCont)
        {
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    public void Roll(bool facingRight, float rollSpeed, bool rolling)
    {
        rolling = true;
        gameObject.transform.localScale = new Vector3(1,1,0);
        if(facingRight)
        {
            rb.AddForce(transform.right*rollSpeed);
        }
        else
        {
            rb.AddForce(transform.right * -rollSpeed);
        }

        gameObject.transform.localScale = size;
        rolling = false;
        
        
    }
    public void WalkLeft(float walkSpeed)
    {
        rb.AddForce(transform.right * -walkSpeed);
    }

    public void WalkRight(float walkSpeed)
    {
        rb.AddForce(transform.right * walkSpeed);
    }

    private Game game;
    private GameObject gameObj;
    private Vector3 size;
    void Start()
    {
        gameObj = GameObject.FindGameObjectWithTag("GameController");
        game = gameObj.GetComponent<Game>();
        rb = GetComponent<Rigidbody2D>();
        size = gameObject.transform.localScale;
    }
}
