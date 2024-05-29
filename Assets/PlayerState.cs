using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerState : MonoBehaviour
{

    public int pizzasDelivered;
    public int timer;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void incrementPizzas(){
        pizzasDelivered+=1;
        text.text = ""+pizzasDelivered;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
