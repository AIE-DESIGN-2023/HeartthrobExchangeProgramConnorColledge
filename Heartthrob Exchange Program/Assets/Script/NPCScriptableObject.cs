using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using static ActivityScriptableObject;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPCScriptableObject", order = 1)]
public class NPCScriptableObject : ScriptableObject
{
    public string npcName;
    public int npcAffinity;
    public int scheduledLocation;

    //Manages sprites
    [Space]
    [Header("Sprite Manager")]
    [Space]
    public Sprite bodySprite;
    public Sprite happyFace;
    public Sprite blushingFace;
    public Sprite angryFace;
    public Sprite sadFace;



    //Dialogue script variables and int values, divided by location
    [Space]
    [Header("Date's first dialogue prompts")]
    [Space]

    public string[] GardensDialoguePromptText;
    public string[] BarDialoguePromptText;
    public string[] ArcadeDialoguePromptText;
    public string[] AquariumDialoguePromptText;


    //arrays for assigning player's dialogue responses
    public string[] GardenPlayerResponse;

    [Space]
    public int[] GardenResponseAffinity;


    public string[] BarPlayerResponse;

    [Space]
    public int[] BarResponseAffinity;


    public string[] ArcadePlayerResponse;

    [Space]
    public int[] ArcadeResponseAffinity;


    public string[] AquariumPlayerResponse;
    [Space]
    public int[] AquariumResponseAffinity;




}
