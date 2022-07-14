using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    public int WaitTime = 1;
    void Update()
    {

        Destroy(gameObject,WaitTime);
    }
}

