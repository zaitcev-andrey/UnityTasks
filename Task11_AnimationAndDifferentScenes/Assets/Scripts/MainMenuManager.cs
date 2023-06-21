using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void ChooseSceneOnClick(int index)
    {
        SceneManager.LoadScene(index);
    }
}
