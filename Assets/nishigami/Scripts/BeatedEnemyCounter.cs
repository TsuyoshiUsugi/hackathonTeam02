using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatedEnemyCounter : MonoBehaviour
{
    [SerializeField] private Text beatedEnemyCounter = null;

    [SerializeField] private IngameManager ingameManager = null;

    private int clearKillCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        clearKillCount = ingameManager.GetClearKillCount;
        Debug.Log("clearKillCount =" + clearKillCount);
    }

    // Update is called once per frame
    void Update()
    {
        beatedEnemyCounter.text = string.Format("écÇË {0} ëÃÅI", clearKillCount - ingameManager.KillCount);
    }
}
