using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject player = null;
    [SerializeField] EnemySpawnData spawnData = null;
    [SerializeField] private float _currentIngameTime = 0;
    [SerializeField] int _currentSpawnEnemyIndex = 0;
    [SerializeField] Vector2 _horizontalSpawnPos = Vector2.zero;
    [SerializeField] Vector2 _verticalSpawnPos = Vector2.zero;
    [SerializeField] float _spawnTime;
    [SerializeField] int _maxEnemyCount = 3;
    [SerializeField] Vector2 _verticalLimit;
    [SerializeField] Vector2 _horizontalLimit;
    bool _reachLastSpawn = false;
    public bool ReachLastSpawn => _reachLastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _currentIngameTime += Time.deltaTime;
        if (_currentIngameTime > _spawnTime)
        {
            _currentIngameTime = 0;
            var x = Random.Range(_horizontalSpawnPos.x, _horizontalSpawnPos.y);
            x += player.transform.position.x;
            
            if (x < _horizontalLimit.x)
            {
                x = _horizontalLimit.x;
            }
            else if (x > _horizontalLimit.y)
            {
                x = _horizontalLimit.y;
            }

            bool isUp = Random.Range(0, 1) == 0;
            var y = isUp ? _verticalSpawnPos.x : _verticalSpawnPos.y;
            y += player.transform.position.y;

            if (y < _verticalLimit.x)
            {
                y = _verticalLimit.x;
            }
            else if (y > _verticalLimit.y)
            {
                y = _verticalLimit.y;
            }

            var spawnEnemyIndex = Random.Range(0, spawnData.Enemies.Count);
            SpawnEnemy(spawnData.Enemies[spawnEnemyIndex].InstantiateObject, new Vector2(x, y));
        }
    }

    // 敵をスポーンさせるメソッド
    // 引数：enemyPrefab：敵のプレハブ
    public void SpawnEnemy(GameObject enemyPrefab, Vector2 pos)
    {
        var enemyCount = FindObjectsByType<Enemy>(sortMode: FindObjectsSortMode.None).Length;
        if (enemyCount >= _maxEnemyCount) return;
        GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
        enemy.GetComponent<Enemy>().SetTarget = player;
    }
}