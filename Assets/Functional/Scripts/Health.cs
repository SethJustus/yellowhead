using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    void Start()
    {

    }
    void TakeDamage(float Amount)
    {
        health -= Amount;
    }
    void FixedUpdate()
    {
        Debug.Log(health);
    }
}
