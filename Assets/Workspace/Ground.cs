using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
    }
}
