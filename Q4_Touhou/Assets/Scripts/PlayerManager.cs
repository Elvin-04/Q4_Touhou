using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            Debug.Log("Loose");
            //Call Loose function in GameManager
        }
    }
}
