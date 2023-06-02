using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBehaviourScript : MonoBehaviour
{
 

    //Stat values variables
    public int stressValue;
    public int athleticsValue;
    public int academicsValue;
    public int artsValue;
    public int techValue;
    public int cultureValue;
    public int conversationalismValue;
    public int confidenceValue;
    public int appearanceValue;

    //button variables
    public GameObject workoutButton;
    public GameObject studyButton;
    public GameObject drawButton;
    public GameObject fashionButton;
    public GameObject socialiseButton;
    public GameObject computerButton;
    public GameObject restButton;
    public GameObject languageButton;
    public GameObject saveButton;
    public GameObject notesButton;
    public GameObject phoneButton;

    void Start()
    {
        stressValue = 0;
        athleticsValue = 40;
        academicsValue = 40;
        artsValue = 40;
        techValue = 40;
        cultureValue = 32;
        conversationalismValue = 5;
        confidenceValue = 15;
        appearanceValue = 55;
    }



    //void for determining activity selection
    public void ActivitySelection(ActivityScriptableObject activity)
    {
        int statNumber = 0;
        foreach(ActivityScriptableObject.PlayerStats stat in activity.playerStats)
        {
            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.stress)
            {
                stressValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.academics)
            {
                academicsValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.athletics)
            {
                athleticsValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.arts)
            {
                artsValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.tech)
            {
                techValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.culture)
            {
                cultureValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.conversationalism)
            {
                conversationalismValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.confidence)
            {
                confidenceValue += activity.value[statNumber];
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.appearance)
            {
                appearanceValue += activity.value[statNumber];
            }
            statNumber++;
        }
        
    }






}
