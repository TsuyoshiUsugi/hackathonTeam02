using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateEnemyParamAsset")]
public class EnemySpawnData : ScriptableObject
{
    public List<EnemyData> Enemies;
}

[System.Serializable]
public class EnemyData
{
    public GameObject InstantiateObject;
    public float SpawnTime;
}
