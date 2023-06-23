using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PhoneContacts : MonoBehaviour
{

    private DayManager dayManager;

    //Scriptable object variables
    public NPCScriptableObject[] allNPCs;
    public NPCScriptableObject currentNPC;

    [Space]
    [Header("Parent UI Objects")]
    [Space]
    public GameObject phoneBody;
    public GameObject headImages;
    public GameObject phoneFocus;
    public GameObject travelGuide;
    public GameObject dateCalendar;
    public GameObject calendarFocus;
    public GameObject textsContainer;


    [Space]
    [Header("UI Buttons Children")]
    [Space]
    public GameObject contactButtons;
    public GameObject phoneButton;
    public GameObject exitButton;
    public GameObject sendButton;
    public GameObject returnButton;

    [Space]
    [Header("Travel Guide Buttons")]
    [Space]
    public GameObject[] locationButtons;

    [Space]
    [Header("Calendar Buttons")]
    [Space]
    public GameObject[] calendarButtons;


    [Space]
    [Header("Text Objects")]
    [Space]
    public TMP_Text phoneHeader;

    private string textedLocation;
    private string textedDay;

    [Space]
    [Header("Text Sequence Objects")]
    [Space]

    //text exchange variables
    public GameObject sentContainer1;
    public TMP_Text sentText1;
    public GameObject sentContainer2;
    public TMP_Text sentText2;
    public GameObject receivedContainer1;
    public TMP_Text receivedText1;
    public GameObject receivedContainer2;
    public TMP_Text receivedText2;
    public string text1Content;
    public string text2Content;
    private string text3Content;
    public string text4Content;

    private int textSequence;


    public int dateModifier;

    


    // Start is called before the first frame update
    void Start()
    {
        phoneBody.SetActive(false);
        phoneFocus.SetActive(false);
        travelGuide.SetActive(false);
        dateCalendar.SetActive(false);
        calendarFocus.SetActive(false);


        dayManager = FindObjectOfType<DayManager>();
        ScheduleClear();





    }

    //Clears all the NPCs schedules on their writable scripts to not include any dates
    public void ScheduleClear()
    {
        for (int i = 0; i < allNPCs.Length; i++)
        {
            if (allNPCs[i].scheduledDay != -1)
            {
                allNPCs[i].scheduledDay = -1;
            }
        }
    }


    //function to open the contact list when player clicks the phone button
    public void OpenContacts()
    {
        //opens required contact list objects and closes unrequired objects
        phoneBody.SetActive(true);
        phoneFocus.SetActive(true);
        contactButtons.SetActive(true);
        headImages.SetActive(true);
        exitButton.SetActive(true);
        sendButton.SetActive(false);
        returnButton.SetActive(false);
        textsContainer.SetActive(false);

        textSequence = 0;
        AlreadyScheduled();

        //turns off text sequence objects
        sentContainer1.SetActive(false);
        sentText1.text = "";
        sentContainer2.SetActive(false);
        sentText2.text = "";
        receivedContainer1.SetActive(false);
        receivedText1.text = "";
        receivedContainer2.SetActive(false);
        receivedText2.text = "";

    }

    //function to close the contact list when player clicks the exit button
    public void CloseContacts()
    {
        phoneBody.SetActive(false);
        phoneFocus.SetActive(false);
    }

    //function to return to contact list from a text exchance
    public void ReturnContacts()
    {
        phoneHeader.text = "Contacts";
        contactButtons.SetActive(true);
        headImages.SetActive(true);
        returnButton.SetActive(false);
        sendButton.SetActive(false);
        exitButton.SetActive(true);
        sentContainer1.SetActive(false);
        sentContainer2.SetActive(false);
        receivedContainer1.SetActive(false);
        receivedContainer2.SetActive(false);
        textsContainer.SetActive (false);
        textSequence = 0;
    }

    public void OpenTexts()
    {
        textsContainer.SetActive(true);
        sendButton.SetActive(true);
        returnButton.SetActive(true);
        exitButton.SetActive(false);

    }

    //function that starts the text sequence when player selects a contact
    public void ContactSelected(int buttonNumber)
    {
        phoneHeader.text = allNPCs[buttonNumber].npcName;
        currentNPC = allNPCs[buttonNumber];
        contactButtons.SetActive(false);
        headImages.SetActive(false);

        //assigns each NPCs scheduledNPC value to it's position in the array
        for (int i = 0; i < allNPCs.Length; i++)
        {
            if (allNPCs[i] == currentNPC)
            {
                currentNPC.scheduledNPC = i;
                break;
            }          
        }

        OpenTexts();
    }
    
    public void NextText()
    {
        if (textSequence == 0)
        {
            StartExchange();
        }
        else if (textSequence == 1)
        {
            LocationQuestion();
        }
        else if (textSequence == 2)
        {
            LocationOffer();
        }
        else
        {
            AcceptanceRefusal();
        }
    }
    public void StartExchange()
    {
        sentContainer1.SetActive(true);
        sentText1.text = text1Content;
        textSequence++;
        returnButton.SetActive(false);
    }

    public void LocationQuestion()
    {
        if (currentNPC.scheduledDay == -1)
        {
            receivedContainer1.SetActive(true);
            receivedText1.text = currentNPC.dateQuestion;
            travelGuide.SetActive(true);
            sendButton.SetActive(false);
        }
        else
        {
            receivedContainer1.SetActive(true);
            receivedText1.text = "You're suffocating me, Jerry!";
            sendButton.SetActive(false);
            returnButton.SetActive(true);
        }
        
    }

    //function for managing players location selection and updating variable on NPC's writable script
    public void LocationSelection(int locationNumber)
    {
        //when button is clicked on, updates the scheduled location variable to aligned button variable
        currentNPC.scheduledLocation = locationNumber;
        
        textSequence++;
        travelGuide.SetActive(false);
        AlreadyScheduled();
        dateCalendar.SetActive(true);
        calendarFocus.SetActive(true);
        
        //sets a string for later use in constructing the date offer text message
        if(locationNumber == 0)
        {
            textedLocation = " botanical gardens ";
        }
        else if(locationNumber == 1)
        {
            textedLocation = " bar ";
        }
        else if(locationNumber == 2)
        {
            textedLocation = " arcade ";
        }
        else if(locationNumber== 3)
        {
            textedLocation = " aquarium ";
        }
        
        
    }

    //function for managing players day of the month selection and updating variable on NPC's writable script
    public void DaySelection(int dayNumber)
    {
        currentNPC.scheduledDay = dayNumber;
        dateCalendar.SetActive(false);
        calendarFocus.SetActive(false);
        sendButton.SetActive(true);
        
        //establishes which of the 28 days has become a date event day
        dateModifier = dayNumber;

        //sets a string for later use in constructing the date offer text message
        if(dayNumber == 0)
        {
            textedDay = "1st";
        }
        else if (dayNumber == 1)
        {
            textedDay = "2nd";
        }
        else if (dayNumber == 2)
        {
            textedDay = "3rd";
        }
        else if (dayNumber == 3)
        {
            textedDay = "4th";
        }
        else if (dayNumber == 4)
        {
            textedDay = "5th";
        }
        else if (dayNumber == 5)
        {
            textedDay = "6th";
        }
        else if (dayNumber == 6)
        {
            textedDay = "7th";
        }
        else if (dayNumber == 7)
        {
            textedDay = "8th";
        }
        else if (dayNumber == 8)
        {
            textedDay = "9th";
        }
        else if (dayNumber == 9)
        {
            textedDay = "10th";
        }
        else if (dayNumber == 10)
        {
            textedDay = "11th";
        }
        else if (dayNumber == 11)
        {
            textedDay = "12th";
        }
        else if (dayNumber == 12)
        {
            textedDay = "13th";
        }
        else if (dayNumber == 13)
        {
            textedDay = "14th";
        }
        else if (dayNumber == 14)
        {
            textedDay = "15th";
        }
        else if (dayNumber == 15)
        {
            textedDay = "16th";
        }
        else if (dayNumber == 16)
        {
            textedDay = "17th";
        }
        else if (dayNumber == 17)
        {
            textedDay = "18th";
        }
        else if (dayNumber == 18)
        {
            textedDay = "19th";
        }
        else if (dayNumber == 19)
        {
            textedDay = "20th";
        }
        else if (dayNumber == 20)
        {
            textedDay = "21st";
        }
        else if (dayNumber == 21)
        {
            textedDay = "22nd";
        }
        else if (dayNumber == 22)
        {
            textedDay = "23rd";
        }
        else if (dayNumber == 23)
        {
            textedDay = "24th";
        }
        else if (dayNumber == 24)
        {
            textedDay = "25th";
        }
        else if (dayNumber == 25)
        {
            textedDay = "26th";
        }
        else if (dayNumber == 26)
        {
            textedDay = "27th";
        }
        else if (dayNumber == 27)
        {
            textedDay = "28th";
        }


        NextText();
    }

    public void LocationOffer()
    {
        sentContainer2.SetActive(true);
        TextSentence();
        sentText2.text = text3Content;
        textSequence++;
    }
    public void AcceptanceRefusal()
    {
        receivedContainer2.SetActive(true);
        receivedText2.text = currentNPC.dateApproval;
        textSequence = 0;
        sendButton.SetActive(false);
        returnButton.SetActive(true);

        //updates Day Manager to set the selected date day as a date event day
        dayManager.days[dateModifier] = 2;
        

    }

    //formulates the date offer text to include the players inputted location and day of the month
    public void TextSentence()
    {
        text3Content = "How about the" + textedLocation + "on the " + textedDay + "?";
    }


    //checks what days of the month have dates scheduled and deactivates the associated buttons
    public void AlreadyScheduled()
    {
        for (int i = 0; i < allNPCs.Length; i++)
        {
            if(allNPCs[i].scheduledDay < 0)
            {
                continue;
            }
            for (int f = 0; f < calendarButtons.Length; f++)
            {

                if (allNPCs[i].scheduledDay == f)
                {
                    
                    calendarButtons[f].SetActive(false);
                    break;
                }                

            }
        }

    }
}
