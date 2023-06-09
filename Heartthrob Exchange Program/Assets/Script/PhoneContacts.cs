using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PhoneContacts : MonoBehaviour
{

    //Scriptable object variables
    public NPCScriptableObject[] allNPCs;
    private NPCScriptableObject npcName;

    public TMP_Text phoneHeader;
    public GameObject phoneBody;
    public GameObject contactButtons;
    public GameObject headImages;
    public GameObject phoneButton;
    public GameObject phoneFocus;
    public GameObject exitButton;
    public string displayedName;
    //public int buttonNumber;



    // Start is called before the first frame update
    void Start()
    {
        phoneBody.SetActive(false);
        phoneFocus.SetActive(false);    
    }

    //function to open the contact list when player clicks the phone button
    public void OpenContacts()
    {
        phoneBody.SetActive(true);
        phoneFocus.SetActive(true);
        
    }

    //function to close the contact list when player clicks the exit button
    public void CloseContacts()
    {
        phoneBody.SetActive(false);
        phoneFocus.SetActive(false);
    }

    public void ContactAssigner()
    {
   
    }

    //function that starts the text sequence when player selects a contact
    public void ContactSelected(int buttonNumber)
    {
        if (buttonNumber == 0)
        {
            phoneHeader.text = "0";
        }
        else if (buttonNumber == 1)
        {
            phoneHeader.text = "1";
        }
        else if (buttonNumber == 2)
        {
            phoneHeader.text = "2";
        }
        else if (buttonNumber == 3)
        {
            phoneHeader.text = "3;";
        }
        else if (buttonNumber == 4)
        {
            phoneHeader.text = "4";
        }
        else if (buttonNumber == 5)
        {
            phoneHeader.text = "5";
        }
        else if (buttonNumber == 6)
        {
            phoneHeader.text = "6";
        }
        else if (buttonNumber == 7)
        {
            phoneHeader.text = "7";
        }
    }

}
