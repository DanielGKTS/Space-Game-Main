using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    [SerializeField] GameObject loadingPanel;

    private IEnumerator change()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");

    }
}
