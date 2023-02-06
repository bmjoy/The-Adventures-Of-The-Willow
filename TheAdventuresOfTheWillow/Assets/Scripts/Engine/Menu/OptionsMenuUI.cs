using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OptionsMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private bool isPaused;
    public CursorManager cursorManager;
	
	public GameObject optionsFirstButton;


    public void EscapeMenu(InputAction.CallbackContext context)
	{
        if (context.performed)
     	{
			isPaused = !isPaused;
		}
    }

    private void Update()
    {
		/*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }*/
        if (isPaused)
        {
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(optionsFirstButton);
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        OptionsMenu.SetActive(true);
		cursorManager.cursorAppear();
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        OptionsMenu.SetActive(false);
        isPaused = false;
		cursorManager.cursorDisappear();
    }

}
