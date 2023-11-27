using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject
{
    public int level;
    public bool levelWin = false;
    public int highScore = 0;
    public float bestTimeSeconds = 0;
    public string bestTime = "0:00";
    public string sceneName;
}
