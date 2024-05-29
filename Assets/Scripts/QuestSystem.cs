using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;
    public List<Quest> questList = new List<Quest>();
    private Quest activeQuest;
    private bool playerIsHere;

    private float time = 0.0f;
    public float interpolationPeriod = 1f;

    void Awake()
    {
        instance = this;
    }

    float timePassed = 0f;
    void Update()
    {
      
      timePassed += Time.deltaTime;
      
    if(timePassed > 1f)
    {
        //do something
        if(activeQuest!=null){
            Debug.Log("in there");
FindObjectOfType<PlayerState>().timer-=1;
FindObjectOfType<PlayerState>().updateTimerText();


                if(FindObjectOfType<PlayerState>().timer<0){
                    activeQuest = null;
                }
    }
        timePassed = 0f;
    } 

                
            

        if (Input.GetKeyDown(KeyCode.Space) && playerIsHere)
        {
            AddQuest();
        }
    }

    



    void AddQuest()
    {
        if (activeQuest == null)
        {
            activeQuest = questList[Random.Range(0, questList.Count)];
            Debug.Log("Quest " +activeQuest.id+ " Started");
        }
    }

    public int ReadActiveQuest()
    {
        return activeQuest != null ? activeQuest.id : -1; // Assuming -1 indicates no active quest
    }

    public void CompleteQuest(int _id)
    {
        if(activeQuest==null){
            return;
        }
        if (activeQuest != null && activeQuest.id == _id)
        {
            Debug.Log("Quest number " + activeQuest.id + " is complete");
            FindObjectOfType<PlayerState>().incrementPizzas();
            activeQuest = null;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerIsHere = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerIsHere = false;
        }
    }
}
