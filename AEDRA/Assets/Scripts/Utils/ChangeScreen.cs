using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for load scenes
/// </summary>
public class ChangeScreen : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Method to change the actual scene for other with the especified index
    /// </summary>
    /// <param name="nextPage">Index of the scene to load in unity</param>
    public void ChangeScene(int nextPage){
        SceneManager.LoadScene(nextPage);
    }
}
