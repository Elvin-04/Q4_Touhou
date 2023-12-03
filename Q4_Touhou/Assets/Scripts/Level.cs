using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject
{
    public AudioClip clip;
    public string sceneName;
    public bool levelWin;

    public GameMode mode;
}
