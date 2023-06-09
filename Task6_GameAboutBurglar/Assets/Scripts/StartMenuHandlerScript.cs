using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuHandlerScript : MonoBehaviour
{
    [SerializeField] private GameObject _canvasStartMenu;
    [SerializeField] private GameObject _canvasGame;

    private GameHandlerScript _handlerForGame;

    void Start()
    {
        _canvasStartMenu.SetActive(true);
        _canvasGame.SetActive(false);

        _handlerForGame = FindObjectOfType<GameHandlerScript>();
        _handlerForGame.enabled = false; // так мы выключаем Update у скрипта GameHandlerScript на объекте Канваса
    }

    public void StartGameButton()
    {
        _canvasStartMenu.SetActive(false);
        _canvasGame.SetActive(true);
        FindObjectOfType<GameHandlerScript>().currentTime = 60f;
        _handlerForGame.enabled = true;
    }
}
