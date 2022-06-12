using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    
    public void LaunchGameScene()
    {
        SceneManager.LoadScene(1);
    }

}
