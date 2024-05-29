using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;


public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;
    public List<Quest> questList = new List<Quest>();
    private Quest activeQuest;
    private bool playerIsHere;

    public Text onScreen;

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
                    // activeQuest = null;
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

            string location = "";

            switch(activeQuest.id){
                case(1):
                    location="Pizzeria";
                    break;
                case(2):
                    location="Hospital";
                    break;
                case(3):
                    location="Prison";
                    break;
                case(4):
                    location="Police";
                    break;
                case(5):
                    location="Bank";
                    break;
                case(6):
                    location="Racing";
                    break;
            }
            onScreen.text = "Go to "+location;
    

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
            onScreen.text="";
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
