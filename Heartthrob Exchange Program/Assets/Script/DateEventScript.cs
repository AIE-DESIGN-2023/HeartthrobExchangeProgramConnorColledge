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
    public GameObject nextButton;
    public GameObject returnButton;
    public int dialogueSequence;
    public string impressionQuality;


    private DayManager dayManager;


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
        nextButton.SetActive(true);
        returnButton.SetActive(false);
        LocationIdentifier();
        NPCIdentifier();
        DateIntro();
        dayManager.UpdateDay();
        

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
        nextButton.SetActive(false);
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

    public void DateResponse()
    {
        dialogueBox.text = "I seemed to have left a " + impressionQuality + " impression!";
        nextButton.SetActive(false);
        returnButton.SetActive(true);
    }


    //Gets response element from NPC scriptable when player clicks on dialogue button
    public void DialogueChosen(int buttonNumber)
    {
        responseTop.SetActive(false);
        responseMiddle.SetActive(false);
        responseBottom.SetActive(false);
        nextButton.SetActive(true);
        if (locationValue == 0)
        {
            dialogueBox.text = currentNPC.GardenDateReaction[buttonNumber];
        }
        else if (locationValue == 1)
        {
            dialogueBox.text = currentNPC.BarDateReaction[buttonNumber];
        }
        else if (locationValue == 2)
        {
            dialogueBox.text = currentNPC.ArcadeDateReaction[buttonNumber];
        }
        else if (locationValue == 3)
        {
            dialogueBox.text = currentNPC.AquariumDateReaction[buttonNumber];
        }
        dialogueSequence = 2;
        if(buttonNumber == 0)
        {
            impressionQuality = "good";
        }
        else if(buttonNumber == 1)
        {
            impressionQuality = "relatively good";
        }
        else if (buttonNumber == 2)
        {
            impressionQuality = "bad";
        }
    }


    //Loads next sequenced function when player clicks on the Next Button
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
        else if(dialogueSequence == 2)
        {
            DateResponse();
        }
    }



}
