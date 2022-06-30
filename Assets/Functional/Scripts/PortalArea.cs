using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalArea : MonoBehaviour
{
    public string locationName;
    public GameObject target;

    public void Portal()
    {
        SceneManager.LoadScene(locationName);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == target)
        {
            Portal();
        }
        else
        {

        }
    }
}
