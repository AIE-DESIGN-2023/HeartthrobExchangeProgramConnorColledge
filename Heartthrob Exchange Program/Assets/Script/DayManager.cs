using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int[] days;
    public int currentDay;    

    public void UpdateDay()
    {
        currentDay++;
        if(currentDay >= days.Length)
        {
            currentDay = 0;
        }
        Debug.Log(days[currentDay].ToString());
    }
}
