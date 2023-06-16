using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AffinityNotebook : MonoBehaviour
{
    public TMP_Text[] notebookName;
    //public SpriteRenderer[] affinityFaces;
    public Image[] affinityFaces;

    //face sprite sources

    public Sprite angryFace;
    public Sprite unimpressedFace;
    public Sprite sadFace;
    public Sprite neutralFace;
    public Sprite amusedFace;
    public Sprite happyFace;
    public Sprite blushingFace;



    //UI Objects
    public GameObject exitNotes;
    public GameObject noteBook;
    public GameObject pageOne;
    public GameObject pageTwo;
    public GameObject noteFocus;

    public NPCScriptableObject[] allNPCs;

    public void Start()
    {
        noteBook.SetActive(false);
        exitNotes.SetActive(false);
        pageOne.SetActive(false);
        pageTwo.SetActive(false);
        noteFocus.SetActive(false);
    }
   
    //Opens notebook for player when they click on the 'Notes' button
    public void OpenNotebook()
    {
        noteBook.SetActive(true);
        exitNotes.SetActive(true);
        pageOne.SetActive(true);
        pageTwo.SetActive(true);
        noteFocus.SetActive(true);
        AffinityCheck();
    }

    //Closes notebook for player when they click on the 'Exit' button
    public void CloseNotebook()
    {
        noteBook.SetActive(false);
        exitNotes.SetActive(false);
        pageOne.SetActive(false);
        pageTwo.SetActive(false);
        noteFocus.SetActive(false);
    }

    //checks affinity score and per NPC and prints appropriate visual marker sprite to the player
    public void AffinityCheck()
    {
        for (int i = 0; i < allNPCs.Length; i++)
        {
            if (allNPCs[i].npcAffinity < allNPCs[i].unimpressedThreshold)
            {
                affinityFaces[i].sprite = angryFace;
            }
            else if (allNPCs[i].npcAffinity >= allNPCs[i].unimpressedThreshold && allNPCs[i].npcAffinity < allNPCs[i].sadThreshold)
            {
                affinityFaces[i].sprite = unimpressedFace;
            }
            else if (allNPCs[i].npcAffinity >= allNPCs[i].sadThreshold && allNPCs[i].npcAffinity < allNPCs[i].neutralThreshold)
            {
                affinityFaces[i].sprite = sadFace;
            }
            else if (allNPCs[i].npcAffinity >= allNPCs[i].neutralThreshold && allNPCs[i].npcAffinity < allNPCs[i].amusedThreshold)
            {
                affinityFaces[i].sprite = neutralFace;
            }
            else if (allNPCs[i].npcAffinity >= allNPCs[i].amusedThreshold && allNPCs[i].npcAffinity < allNPCs[i].happyThreshold)
            {
                affinityFaces[i].sprite = amusedFace;
            }
            else if (allNPCs[i].npcAffinity >= allNPCs[i].amusedThreshold && allNPCs[i].npcAffinity < allNPCs[i].blushingThreshold)
            {
                affinityFaces[i].sprite = happyFace;
            }
            else if (allNPCs[i].npcAffinity >= allNPCs[i].blushingThreshold)
            {
                affinityFaces[i].sprite = blushingFace;
            }
            else
            {
                affinityFaces[i].sprite = neutralFace;
            }
        }
    }


}
