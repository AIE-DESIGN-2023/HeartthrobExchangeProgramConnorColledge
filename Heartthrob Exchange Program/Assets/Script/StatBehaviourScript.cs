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

    //Scriptable object variables
    //public NPCScriptableObject[] allNPCs;
    //public NPCScriptableObject currentNPC;



    //Starts with set default values
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
        
        //aligns the stat values to a game object so players can always view their current stats
        DisplayStat();



        dayManager = FindObjectOfType<DayManager>();
        
    }

 


    //void for determining activity selection
    public void ActivitySelection(ActivityScriptableObject activity)
    {
        //establishes a variable to increment when looping the activity check function
        int statNumber = 0;
        
        //calls the dayManager script in order to check the current day and determine if any date events are scheduled for the day,
        // which would enable the date button
        dayManager.EventManager();
        
        //runs a loop to check each stat type against the associated scriptable object to see if it needs to update any stats
        foreach(ActivityScriptableObject.PlayerStats stat in activity.playerStats)
        {
            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.stress)
            {
                //increases/decreases stress value by the amount dictate by the activity scriptable object
                stressValue += activity.value[statNumber];
                
                //stops stress value from descending into a negative value
                if(stressValue <= 0)
                {
                    stressValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.academics)
            {
                //increases/decreases academics value by the amount dictate by the activity scriptable object
                academicsValue += activity.value[statNumber];

                //stops academics value from descending into a negative value
                if (academicsValue <= 0)
                {
                    academicsValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.athletics)
            {
                //increases/decreases athletics value by the amount dictate by the activity scriptable object
                athleticsValue += activity.value[statNumber];

                //stops athletics value from descending into a negative value
                if (athleticsValue <= 0)
                {
                    athleticsValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.arts)
            {
                //increases/decreases arts value by the amount dictate by the activity scriptable object
                artsValue += activity.value[statNumber];

                //stops arts value from descending into a negative value
                if (artsValue <= 0)
                {
                    artsValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.tech)
            {
                //increases/decreases tech value by the amount dictate by the activity scriptable object
                techValue += activity.value[statNumber];

                //stops tech value from descending into a negative value
                if (techValue <= 0)
                {
                    techValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.culture)
            {
                //increases/decreases culture value by the amount dictate by the activity scriptable object
                cultureValue += activity.value[statNumber];

                //stops culture value from descending into a negative value
                if (cultureValue <= 0)
                {
                    cultureValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.conversationalism)
            {
                //increases/decreases conversationalism value by the amount dictate by the activity scriptable object
                conversationalismValue += activity.value[statNumber];

                //stops conversationalism value from descending into a negative value
                if (conversationalismValue <= 0)
                {
                    conversationalismValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.confidence)
            {
                //increases/decreases confidence value by the amount dictate by the activity scriptable object
                confidenceValue += activity.value[statNumber];

                //stops confidence value from descending into a negative value
                if (confidenceValue <= 0)
                {
                    confidenceValue = 0;
                }
            }

            if (activity.playerStats[statNumber] == ActivityScriptableObject.PlayerStats.appearance)
            {
                //increases/decreases appearance value by the amount dictate by the activity scriptable object
                appearanceValue += activity.value[statNumber];

                //stops appearance value from descending into a negative value
                if (appearanceValue <= 0)
                {
                    appearanceValue = 0;
                }
            }
            
            //increments statNumber value so check can loop through each stat type properly
            statNumber++;
        }
        
        //updates displayed stats to player so they can see changes
        DisplayStat();
        
        //calls dayManager script and tells it to update current day to the next calendar day
        dayManager.UpdateDay();
        
    }


    //aligns the stat values to a game object so players can always view their current stats
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



