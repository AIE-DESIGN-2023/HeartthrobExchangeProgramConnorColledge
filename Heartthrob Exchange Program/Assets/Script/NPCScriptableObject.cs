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
    public Sprite bodySprite;
    public Sprite happyFace;
    public Sprite blushingFace;
    public Sprite angryFace;
    public Sprite sadFace;
    

}
