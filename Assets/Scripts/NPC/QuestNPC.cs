using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestNPC : MonoBehaviour
{
    public Quest quest;
    private bool playerInRange;
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))  //判断在范围之内且选择了与NPC进行交互
        {
            Talk();                                        
        }
    }
    void Talk()
    {
       // if (!quest.questAccepted)
       // {
        //    quest.questAccepted = true;
        //
        //    Debug.Log("任务已接取:消灭三个敌人");
        //    quest.AcceptQuest();
       // }
       // else if (!quest.questCompleted)
       // {
       //     Debug.Log("任务还没完成");
       // }
      //  else
       // {
       //     Debug.Log("获得100金币奖励！");
       //     quest.CompleteQuest();
       // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {playerInRange = true;}
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {playerInRange = false;}
    }
    private void FixedUpdate()
    {
        Debug.Log(playerInRange);
    }
}
