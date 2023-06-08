using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    private DayManager dayManager;
    private void Start()
    {
        dayManager = FindObjectOfType<DayManager>();
    }
    //Function that loads in a scene
    public void LoadScene()
    {
        //updates day when new scene is loaded
        dayManager.UpdateDay();
        
        //Runs other scenes over the Activity Menu scene so the stats are not unloaded
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene()
    {
        
        SceneManager.UnloadSceneAsync(sceneName);
        

        
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
