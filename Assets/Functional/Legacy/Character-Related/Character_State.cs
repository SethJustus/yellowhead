using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character_State : MonoBehaviour
{
    [SerializeField] private LayerMask layerGround;
    public bool talking;
    public Rigidbody2D rb;
    public GameObject dialogue_manager;
    public Dialogue_Manager manager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dialogue_manager = GameObject.FindGameObjectWithTag("Dialogue_Manager");
        manager = dialogue_manager.GetComponent<Dialogue_Manager>();
    }
   

    public bool IsGrounded()
    {
        if(manager.displaying == true)
        {
            return false;
        }
        return Physics2D.BoxCast(transform.position, transform.localScale,0f,Vector2.down, 0.01f,layerGround);
    }
}
