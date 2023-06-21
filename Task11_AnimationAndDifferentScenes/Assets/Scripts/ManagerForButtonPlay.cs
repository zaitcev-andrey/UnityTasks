using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerForButtonPlay : MonoBehaviour
{
    public void GoToMainMenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
