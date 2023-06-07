using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActivityScriptableObject", order = 2)]
public class ActivityScriptableObject : ScriptableObject 
{
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
    public PlayerStats[] playerStats;
    public int[] value;
}
