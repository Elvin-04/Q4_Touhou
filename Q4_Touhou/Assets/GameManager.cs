using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxFramerate = 120;


    void Start()
    {
        Application.targetFrameRate = maxFramerate;
    }

}
