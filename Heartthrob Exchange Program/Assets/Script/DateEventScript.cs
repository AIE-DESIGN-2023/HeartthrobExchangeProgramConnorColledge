using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateEventScript : MonoBehaviour
{
    //base variables
    public TMP_Text dialogueBox;
    public int locationValue;
    public int npcValue;
    public int randomLocation;
    public GameObject dateNPC;
    public int dialogueSequence;

    //Scriptable object variables
    public NPCScriptableObject[] allNPCs;
    private NPCScriptableObject currentNPC;

    //Response button variables
    public GameObject responseTop;
    public GameObject responseMiddle;
    public GameObject responseBottom;
    public TMP_Text topText;
    public TMP_Text middleText;
    public TMP_Text bottomText;

    public void DialoguePrinter(NPCScriptableObject dialogue)
    {

    }

    void Start()
    {
        dateNPC.SetActive(false);
        responseTop.SetActive(false);
        responseMiddle.SetActive(false);
        responseBottom.SetActive(false);
        LocationIdentifier();
        NPCIdentifier();
        DateIntro();

    }

    //checks locationValue and prints an introductory message to play to inform them of their location
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
            dialogueBox.text = "You arrive at the Aquarium...";
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
        dialogueBox.text = "";
        if (locationValue == 0)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.GardenPlayerResponse[0];
            middleText.text = currentNPC.GardenPlayerResponse[1];
            bottomText.text = currentNPC.GardenPlayerResponse[2];
        }
        else if (locationValue == 1)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.BarPlayerResponse[0];
            middleText.text = currentNPC.BarPlayerResponse[1];
            bottomText.text = currentNPC.BarPlayerResponse[2];
        }
        else if (locationValue == 2)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.ArcadePlayerResponse[0];
            middleText.text = currentNPC.ArcadePlayerResponse[1];
            bottomText.text = currentNPC.ArcadePlayerResponse[2];
        }
        else if (locationValue == 3)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.AquariumPlayerResponse[0];
            middleText.text = currentNPC.AquariumPlayerResponse[1];
            bottomText.text = currentNPC.AquariumPlayerResponse[2];
        }
        
      
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
