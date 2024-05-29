using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Quest",menuName = "QuestSystem")]
public class Quest : ScriptableObject
{
   public int id;
   public GameObject deliveryGoal;

}
