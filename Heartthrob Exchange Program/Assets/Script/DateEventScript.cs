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
    public int dialogueSequence;


    public NPCScriptableObject[] allNPCs;
    private NPCScriptableObject currentNPC;

    public void DialoguePrinter(NPCScriptableObject dialogue)
    {

    }

    void Start()
    {
        dateNPC.SetActive(false);
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
        dialogueSequence = 0;
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
        currentNPC = allNPCs[Random.Range(0, allNPCs.Length)];


    }

    //Presents the date sprite to the player, and randomly selects which conversation start to print to player
    public void DateArrives()
    {
        dateNPC.SetActive(true);
        //int dialogueNumber = Random.Range(0, 3);
        if (locationValue == 0)
        {
            int dialogueNumber = Random.Range(0, currentNPC.GardensDialoguePromptText.Length);
            dialogueBox.text = currentNPC.GardensDialoguePromptText[dialogueNumber];
        }
        else if (locationValue == 1)
        {
            int dialogueNumber = Random.Range(0, currentNPC.BarDialoguePromptText.Length);
            dialogueBox.text = currentNPC.BarDialoguePromptText[dialogueNumber];
        }
        else if (locationValue == 2)
        {
            int dialogueNumber = Random.Range(0, currentNPC.ArcadeDialoguePromptText.Length);
            dialogueBox.text = currentNPC.ArcadeDialoguePromptText[dialogueNumber];
        }
        else
        {
            int dialogueNumber = Random.Range(0, currentNPC.AquariumDialoguePromptText.Length);
            dialogueBox.text = currentNPC.AquariumDialoguePromptText[dialogueNumber];
        }
        dialogueSequence = 1;
    }

    
    //gets responses options from NPC scriptable object, based on previously printed dialogue prompt, and gives the player response buttons
    public void ResponseTime()
    {
        /*dialogueBox.text = "";
        if(currentNPC.dialogueNumber == 0)
        {
            dialogueBox.text = "Garden responses...";
        }
        else if(dialogueNumber == 1)
        {
            dialogueBox.text = "Bar responses...";
        }
        else if(dialogueNumber == 2)
        {
            dialogueBox.text = "Arcade responses...";
        }
        else if (dialogueNumber == 3)
        {
            dialogueBox.text = "Aquarium responses...";
        }
        */
      
    }
    public void GoNext()
    {
        if(dialogueSequence == 0)
        {
            DateArrives();
        }
        else if(dialogueSequence == 1)
        {
            ResponseTime();
        }
    }



}
