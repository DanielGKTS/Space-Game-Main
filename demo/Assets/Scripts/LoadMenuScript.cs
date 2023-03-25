using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public string run; 



    
    private IEnumerator change()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(run);  

    }
}



