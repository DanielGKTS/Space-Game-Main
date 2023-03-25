using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncL : MonoBehaviour
{
    //objects that our scenes are laoded into 
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject lorePanel;

    [SerializeField] Slider loadingSlider;


    //Function that starts up the game with a string that tells you which level to load 
    public void OnClickPLay(string levelToLoad)
    {
        //The set active method tells the compiler which scenes are active 
        MainMenu.SetActive(false);
        lorePanel.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelAsync(levelToLoad));

    }


    public void GotoLore()
    {
        MainMenu.SetActive(false);
        lorePanel.SetActive(true);
        loadingScreen.SetActive(false);
    }

    public void GoBack()
    {
        MainMenu.SetActive(true);
        lorePanel.SetActive(false);
        loadingScreen.SetActive(false);
    }

    
    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        //Used to load scene scenes asynchronously 
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.60f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
