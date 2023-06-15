using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffinityNotebook : MonoBehaviour
{
    public TMP_Text[] notebookName;
    public GameObject[] affinityFaces;

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

    private NPCScriptableObject[] allNPCs;

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

}
