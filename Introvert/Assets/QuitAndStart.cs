using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAndStart : MonoBehaviour
{
    [SerializeField] private GameObject _controls;
    [SerializeField] private GameObject _mainMenu;
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ControlsScreenOpen()
    {
        _mainMenu.SetActive(false);
        _controls.SetActive(true);
    }
    public void ControlsScreenClose()
    {
        _mainMenu.SetActive(true);
        _controls.SetActive(false);
    }
}
