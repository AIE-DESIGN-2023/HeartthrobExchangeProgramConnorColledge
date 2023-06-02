using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    //stat display variables
    public TMP_Text stressText;
    public TMP_Text academicsText;
    public TMP_Text athleticsText;
    public TMP_Text artsText;
    public TMP_Text techText;
    public TMP_Text cultureText;
    public TMP_Text conversationText;
    public TMP_Text confidenceText;
    public TMP_Text appearanceText;

    private DayManager dayManager;


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
        DisplayStat();

        dayManager = FindObjectOfType<DayManager>();
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
        DisplayStat();
        dayManager.UpdateDay();
        
    }


    public void DisplayStat()
    {
        stressText.text = stressValue.ToString();
        academicsText.text = academicsValue.ToString();
        athleticsText.text = athleticsValue.ToString();
        artsText.text = artsValue.ToString();
        techText.text = techValue.ToString();
        cultureText.text = cultureValue.ToString();
        conversationText.text = conversationalismValue.ToString();
        confidenceText.text = confidenceValue.ToString();
        appearanceText.text = appearanceValue.ToString();
        
        
    }



}
