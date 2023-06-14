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
    

    //Manages sprites
    [Space]
    [Header("Sprite Manager")]
    [Space]
    public Sprite bodySprite;
    public Sprite happyFace;
    public Sprite blushingFace;
    public Sprite angryFace;
    public Sprite sadFace;

    //Variables to determines scheduled dates characteristics
    [Space]
    [Header("Schedule variables")]
    [Space]
    public int scheduledLocation;
    public int scheduledDay;
    public int scheduledNPC;


    //Dialogue script variables and int values, divided by location
    [Space]
    [Header("Garden Dialogue")]
    [Space]

    public string[] GardensDialoguePromptText;
    public string[] GardenPlayerResponse;
    public int[] GardenResponseAffinity;
    public string[] GardenDateReaction;


    [Space]
    [Header("Bar Dialogue")]
    [Space]

    public string[] BarDialoguePromptText;
    public string[] BarPlayerResponse;
    public int[] BarResponseAffinity;
    public string[] BarDateReaction;

    [Space]
    [Header("Arcade Dialogue")]
    [Space]



    public string[] ArcadeDialoguePromptText;
    public string[] ArcadePlayerResponse;
    public int[] ArcadeResponseAffinity;
    public string[] ArcadeDateReaction;




    [Space]
    [Header("Aquarium Dialogue")]
    [Space]

    public string[] AquariumDialoguePromptText;
    public string[] AquariumPlayerResponse;
    public int[] AquariumResponseAffinity;
    public string[] AquariumDateReaction;


}
