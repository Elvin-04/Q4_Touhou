using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<string> bulletTags = new List<string>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(bulletTags.Contains(collision.gameObject.tag))
        {
            GameManager.instance.PlayerDeath();
        }
    }
}
