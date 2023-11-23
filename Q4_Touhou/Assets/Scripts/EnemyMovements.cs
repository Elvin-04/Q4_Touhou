using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    private Vector2 destination;
    public bool isMoving = false;

    public float speed;

    public int actualPosition = 0;

    public float timeBetweenEachMovement = 10f;
    private float currentTimer = 0.0f;

    private void Update()
    {
        if (isMoving)
        {
            if(Vector2.Distance(transform.position, destination) < 0.2f)
            {
                isMoving = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            }
        }
        else
        {
            if(currentTimer < timeBetweenEachMovement)
            {
                currentTimer += Time.deltaTime;
            }
            else
            {
                currentTimer = 0.0f;
                if (actualPosition + 1 < WaveManager.instance.spawnPositionInGame.Count)
                {
                    actualPosition++;
                }
                else
                {
                    actualPosition = 0;
                }

                MoveTo(WaveManager.instance.spawnPositionInGame[actualPosition].position);
            }
            
        }
    }

    public void MoveTo(Vector2 destination)
    {
        isMoving = true;
        this.destination = destination;
    }
}
