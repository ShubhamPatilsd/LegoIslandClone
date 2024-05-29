using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReciever : MonoBehaviour
{
public int questId;


void OnTriggerEnter(Collider col){
    if(col.CompareTag("Player")){
        QuestSystem.instance.CompleteQuest(questId);
    }
}

}
