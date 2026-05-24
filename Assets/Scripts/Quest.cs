using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Quest : MonoBehaviour
{
    public int killedEnemies = 0;
    public TextMeshProUGUI questText;
    private void Start()
    {
        questText.text = "Kill 3 enemies";
    }

    private void OnEnable()
    {
        GameEvents.onEnemyKilled += EnemyKilled;
    }

    private void OnDisable()
    {
        GameEvents.onEnemyKilled -= EnemyKilled;
    }

    void EnemyKilled()
    {
        killedEnemies++;

        questText.text =
            "Killed: " + killedEnemies + "/3";

        Debug.Log("任务进度更新");
    }
}
