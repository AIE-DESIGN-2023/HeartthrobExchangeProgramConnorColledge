using System.Collections;
using System.Collections.Generic;

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
    public Sprite neutralFace;
    public Sprite angryFace;
    public Sprite sadFace;

    //Variables to determines scheduled dates characteristics
    [Space]
    [Header("Schedule variables")]
    [Space]
    public int scheduledLocation;
    public int scheduledDay;
    public int scheduledNPC;

    //int values to determine emotional thresholds for affinity check script
    [Space]
    [Header("Emotional State Thresholds")]
    [Space]
    public int angerThreshold;
    public int unimpressedThreshold;
    public int sadThreshold;
    public int neutralThreshold;
    public int amusedThreshold;
    public int happyThreshold;
    public int blushingThreshold;


    //strings that the phone can get text messages from
    [Space]
    [Header("Text messages")]
    [Space]
    public string dateQuestion;
    public string dateApproval;

    //Dialogue script variables and int values, divided by location
    [Space]
    [Header("Garden Dialogue")]
    [Space]

    public string[] gardensDialoguePromptText;
    public string[] gardenPlayerResponse;
    public int[] gardenResponseAffinity;
    public string[] gardenDateReaction;


    [Space]
    [Header("Bar Dialogue")]
    [Space]

    public string[] barDialoguePromptText;
    public string[] barPlayerResponse;
    public int[] barResponseAffinity;
    public string[] barDateReaction;

    [Space]
    [Header("Arcade Dialogue")]
    [Space]



    public string[] arcadeDialoguePromptText;
    public string[] arcadePlayerResponse;
    public int[] arcadeResponseAffinity;
    public string[] arcadeDateReaction;




    [Space]
    [Header("Aquarium Dialogue")]
    [Space]

    public string[] aquariumDialoguePromptText;
    public string[] aquariumPlayerResponse;
    public int[] aquariumResponseAffinity;
    public string[] aquariumDateReaction;


}
