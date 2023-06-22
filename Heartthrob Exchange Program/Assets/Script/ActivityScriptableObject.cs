using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActivityScriptableObject", order = 2)]
public class ActivityScriptableObject : ScriptableObject 
{
    //establishes stat types that scriptable can manipulate
    public enum PlayerStats
    {
        stress,
        academics,
        athletics,
        arts,
        tech,
        culture,
        conversationalism,
        confidence,
        appearance
    }

    //array that lists each stat type seperately
    public PlayerStats[] playerStats;

    //int array listed against playerStats array to determine their incremental/decremental value
    public int[] value;
}
