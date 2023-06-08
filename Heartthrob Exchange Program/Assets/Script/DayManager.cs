using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int[] days;
    public int currentDay;
    public GameObject dateButton;


    public void Start()
    {
        currentDay = 1;
    }
    public void UpdateDay()
    {
        
        currentDay++;
        if (currentDay >= days.Length)
        {
            currentDay = 0;
        }
        Debug.Log(days[currentDay].ToString());
    }

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
}