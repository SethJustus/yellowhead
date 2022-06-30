using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class Controller_Player : MonoBehaviour
{
    //Movement Params
    public float JumpPower;
    public float FloatPower;
    public float AirDrag;
    public float GroundDrag;
    public float AirTime;
    public float WalkSpeed;
    public float AirWalk;
    public float rollSpeed;
    public bool jumpContinuously;
    //Dialogue Params
    public bool Listening;
    //Holder Variables
    private float Drag;
    private float RealWalkSpeed;
    //Used temperarily
    private Character character;
    private bool canJump;
    private bool isJumping;
    private float jumpTimer = 0;
    private bool facingRight;
    private bool rolling;
    
    void Start()
    {
        this.character = GetComponent<Character>();
        JumpPower = JumpPower*character.rb.mass*character.rb.gravityScale;
        FloatPower = FloatPower*character.rb.mass*character.rb.gravityScale;
    }
    private float walk;
    private float listening;
    private float jump;
    private float roll;
    private void Update()
    {
        #region Get Player Input
        walk = Input.GetAxisRaw("Horizontal");
        listening = Input.GetAxisRaw("Vertical");
        jump = Input.GetAxisRaw("Jump");
        roll = Input.GetAxisRaw("Vertical");
        #endregion

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void FixedUpdate()
    {
        
        
        #region Handle Listen Input
        if(listening>0)
        {
            this.Listening = true;
        }
        else{
            this.Listening = false;
        }
        #endregion
        
        #region Handle Jump Input
        if(jump<=0)
        {
            if(character.isGrounded())
            {
                canJump = true;
                isJumping = false;
                jumpTimer = 0;
            }else
            {
            
                canJump = false;
            }
        }
        if(canJump)
        {
            if(jump>0)
            {       
                
                if(jumpContinuously)
                {
                    if(!isJumping)
                    {
                        character.rb.AddForce(transform.up*JumpPower,ForceMode2D.Impulse);
                        isJumping = true;
                    }
                    jumpTimer += 1;                    
                    if(jumpTimer>=AirTime)
                    {
                        canJump = false;                    
                    }
                }
                else
                {
                    canJump = false;
                } 
                character.Jump(FloatPower, jumpContinuously);
            }
        }

        #endregion
        
        #region Handle Walk Input
        if(walk>0)
        {
            facingRight = true;
            character.WalkRight(RealWalkSpeed);
        }else if(walk<0)
        {
            facingRight=false;
            character.WalkLeft(RealWalkSpeed);
        }
        #endregion

        #region Set Dynamic RigidBody Settings
        character.rb.drag = Drag;
        if(character.isGrounded())
        {
            Drag = GroundDrag;
            RealWalkSpeed = WalkSpeed;
        }else
        {
            RealWalkSpeed = WalkSpeed/AirWalk;
            Drag = AirDrag;
        }
        #endregion
        #region Handel Roll Input
        if(roll<0&&!rolling)
        {
            character.Roll(facingRight, rollSpeed, rolling);
        }
        #endregion
    }
}
