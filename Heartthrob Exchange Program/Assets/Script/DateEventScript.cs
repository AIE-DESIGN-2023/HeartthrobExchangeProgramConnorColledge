using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateEventScript : MonoBehaviour
{
    public TMP_Text dialogueBox;
    public int locationValue;
    public int npcValue;
    public int randomLocation;
    public GameObject dateNPC;

    public void DialoguePrinter(NPCScriptableObject dialogue)
    {

    }

    void Start()
    {
        LocationIdentifier();
        NPCIdentifier();
        DateIntro();
    }

    public void DateIntro()
    {
        if(locationValue == 0)
        {
            dialogueBox.text = "You arrive at the Botanical Gardens...";
        }
        else if(locationValue == 1)
        {
            dialogueBox.text = "You arrive at the Bar...";
        }
        else if(locationValue == 2)
        {
            dialogueBox.text = "You arrive at the Arcade...";
        }
        else if (locationValue == 3)
        {
            dialogueBox.text = "You arrive at the Library...";
        }
    }
    


    //identifies the scheduled date location
    public void LocationIdentifier()
    {
        //generates a random number in order to pick a location (for the purposes of testing)
        randomLocation = Random.Range(0, 4);
        locationValue = randomLocation;
    }

    //identifies the schedules date NPC
    public void NPCIdentifier()
    {
        npcValue = 0;
    }


    public void DateArrives(NPCScriptableObject bodySprite)
    {
       
    }





}
