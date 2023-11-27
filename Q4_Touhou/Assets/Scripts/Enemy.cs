using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public int sideSpawn;

    public GameObject prefab;

    public List<int> patternList;

}
