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
    public int dayCheck;
    public GameObject dateNPC;
    public GameObject nextButton;
    public GameObject returnButton;
    public int dialogueSequence;
    public string impressionQuality;
    public TMP_Text nameDisplay;
    public string playerName;


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



    void Start()
    {
        dayManager = FindObjectOfType<DayManager>();
        dateNPC.SetActive(false);
        responseTop.SetActive(false);
        responseMiddle.SetActive(false);
        responseBottom.SetActive(false);
        nextButton.SetActive(true);
        returnButton.SetActive(false);
        DateIdentifier();
        LocationIdentifier();
        DateIntro();
        
        

    }

    //checks locationValue and prints an introductory message to play to inform them of their location
    public void DateIntro()
    {
        nameDisplay.text = playerName;
        if (locationValue == 0)
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
    

    //Identifies the current day and matches the scheduled NPC for that day via their writable script
    public void DateIdentifier()
    {
        dayCheck = dayManager.currentDay;
        
        for(int i = 0; i < allNPCs.Length; i++)
        {
            if (allNPCs[i].scheduledDay == dayCheck)
            {
                currentNPC = allNPCs[i];
                
                break;
            }

        }
        
    }


    //identifies the scheduled date location
    public void LocationIdentifier()
    {
        locationValue = currentNPC.scheduledLocation;
    }


    //Presents the date sprite to the player, and randomly selects which conversation start to print to player
    public void DateArrives()
    {
        dateNPC.SetActive(true);
        nameDisplay.text = currentNPC.npcName;
        //int dialogueNumber = Random.Range(0, 3);
        if (locationValue == 0)
        {
            int dialogueNumber = Random.Range(0, currentNPC.gardensDialoguePromptText.Length);
            dialogueBox.text = currentNPC.gardensDialoguePromptText[dialogueNumber];
        }
        else if (locationValue == 1)
        {
            int dialogueNumber = Random.Range(0, currentNPC.barDialoguePromptText.Length);
            dialogueBox.text = currentNPC.barDialoguePromptText[dialogueNumber];
        }
        else if (locationValue == 2)
        {
            int dialogueNumber = Random.Range(0, currentNPC.arcadeDialoguePromptText.Length);
            dialogueBox.text = currentNPC.arcadeDialoguePromptText[dialogueNumber];
        }
        else
        {
            int dialogueNumber = Random.Range(0, currentNPC.aquariumDialoguePromptText.Length);
            dialogueBox.text = currentNPC.aquariumDialoguePromptText[dialogueNumber];
        }
        dialogueSequence = 1;
    }

    
    //gets responses options from NPC scriptable object, based on previously printed dialogue prompt, and gives the player response buttons
    public void ResponseTime()
    {
        nameDisplay.text = playerName;
        dialogueBox.text = "";
        nextButton.SetActive(false);
        if (locationValue == 0)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.gardenPlayerResponse[0];
            middleText.text = currentNPC.gardenPlayerResponse[1];
            bottomText.text = currentNPC.gardenPlayerResponse[2];
        }
        else if (locationValue == 1)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.barPlayerResponse[0];
            middleText.text = currentNPC.barPlayerResponse[1];
            bottomText.text = currentNPC.barPlayerResponse[2];
        }
        else if (locationValue == 2)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.arcadePlayerResponse[0];
            middleText.text = currentNPC.arcadePlayerResponse[1];
            bottomText.text = currentNPC.arcadePlayerResponse[2];
        }
        else if (locationValue == 3)
        {
            responseTop.SetActive(true);
            responseMiddle.SetActive(true);
            responseBottom.SetActive(true);
            topText.text = currentNPC.aquariumPlayerResponse[0];
            middleText.text = currentNPC.aquariumPlayerResponse[1];
            bottomText.text = currentNPC.aquariumPlayerResponse[2];
        }

        
      
    }

    public void DateResponse()
    {
        nameDisplay.text = currentNPC.npcName;
        dialogueBox.text = "I seemed to have left a " + impressionQuality + " impression!";
        nextButton.SetActive(false);
        returnButton.SetActive(true);
    }


    //Gets response element from NPC scriptable when player clicks on dialogue button
    public void DialogueChosen(int buttonNumber)
    {
        nameDisplay.text = playerName;
        responseTop.SetActive(false);
        responseMiddle.SetActive(false);
        responseBottom.SetActive(false);
        nextButton.SetActive(true);
        if (locationValue == 0)
        {
            dialogueBox.text = currentNPC.gardenDateReaction[buttonNumber];
            //adds the responses affinity value to the NPC's affinity score
            currentNPC.npcAffinity += currentNPC.gardenResponseAffinity[buttonNumber];
        }
        else if (locationValue == 1)
        {
            dialogueBox.text = currentNPC.barDateReaction[buttonNumber];
            currentNPC.npcAffinity += currentNPC.gardenResponseAffinity[buttonNumber];
        }
        else if (locationValue == 2)
        {
            dialogueBox.text = currentNPC.arcadeDateReaction[buttonNumber];
            currentNPC.npcAffinity += currentNPC.gardenResponseAffinity[buttonNumber];
        }
        else if (locationValue == 3)
        {
            dialogueBox.text = currentNPC.aquariumDateReaction[buttonNumber];
            currentNPC.npcAffinity += currentNPC.gardenResponseAffinity[buttonNumber];
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
