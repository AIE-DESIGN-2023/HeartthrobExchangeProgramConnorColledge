using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    public int[] days;
    public int currentDay;
    public GameObject dateButton;
    public TMP_Text dateDisplay;


    public void Start()
    {
        currentDay = 0;
        dateDisplay.text = (currentDay + 1).ToString();

    }
    public void UpdateDay()
    {
        
        currentDay++;
        if (currentDay >= days.Length)
        {
            currentDay = 0;
        }
        Debug.Log(days[currentDay].ToString());
        dateDisplay.text = (currentDay + 1).ToString(); 
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
    public void Update()
    {
        EventManager();
    }
}