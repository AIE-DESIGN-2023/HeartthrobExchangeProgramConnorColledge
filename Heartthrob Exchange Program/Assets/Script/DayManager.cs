using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    //array for checking day type
    public int[] days;

    //int variable for tracking the current day in the game state
    public int currentDay;

    public GameObject dateButton;
    public TMP_Text dateDisplay;


    public void Start()
    {
        currentDay = 0;
        dateDisplay.text = (currentDay + 1).ToString();

    }
    
    //function to call when an activity rolls to the next calendar day 
    public void UpdateDay()
    {
        
        currentDay++;
        
        //loops the days back around to the start. Mainly for testing purposes may remove later
        if (currentDay >= days.Length)
        {
            currentDay = 0;
        }

    }

    //function to call every time the currentDay is updated
    public void EventManager()
    {
        //Check to see if today is a weekday
        if (days[currentDay] == 0)
        {
            dateButton.SetActive(false);
        }
        //Check to see if today is a weekend
        else if (days[currentDay] == 1)
        {
            dateButton.SetActive(false);
        }
        //Check to see if a Date is scheduled for today
        else if (days[currentDay] == 2)
        {
            dateButton.SetActive(true);
        }

    }

    //ensures the current day is always displayed to the player
    public void Update()
    {
        EventManager();

        //adds +1 to the current day variable, as the array containing current days begins with 0 rather than one
        dateDisplay.text = (currentDay + 1).ToString();
    }
}