using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterFlow : MonoBehaviour
{
    public void GoNext(){
        AsyncOperation op = SceneManager.LoadSceneAsync("Assets/Scenes/HQScene");
    }
    
}
