using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;

    [SerializeField]
    public GameObject load;

    [SerializeField]
    public GameObject loadingSlider;

    private bool isPaused = false;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit(string levelToLoad)
    {
        Time.timeScale = 1f;
        load.SetActive(true);
        StartCoroutine(LoadLevelAsync(levelToLoad));
        //Application.Quit();
    }


    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.60f);
            loadingSlider.GetComponent<Slider>().value = progressValue;
            yield return null;
        }
    }


}
