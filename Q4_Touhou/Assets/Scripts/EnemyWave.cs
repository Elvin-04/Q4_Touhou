using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyWave", order = 1)]
public class EnemyWave : ScriptableObject
{
    public List<Enemy> ennemies;
}
