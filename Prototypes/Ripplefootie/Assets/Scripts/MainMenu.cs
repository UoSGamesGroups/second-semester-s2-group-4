using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    //Screen object references, active/inactive based on button press
    public GameObject controlsScreen;
    public GameObject menuScreen;

    //Button references to activate/deactivate
    public GameObject backButton;
    public GameObject startButton;
    public GameObject controlsButton;
    public GameObject exitButton;

    public GameObject titlePanel;

    //references for game over screen
    public GameObject blueWin;
    public GameObject redWin;
    public bool redWon = false;
    public bool blueWon = false;

    public void Awake()
    {
        blueWin = GameObject.FindGameObjectWithTag("BlueWin");
        redWin = GameObject.FindGameObjectWithTag("RedWin");
    }



    //called when "controls button" is pressed
    //activates the controls screen & back button
    //deacivates everything else
    public void ActivateControlsScreen()
    {
        controlsScreen.SetActive(true);
        backButton.SetActive(true);

        menuScreen.SetActive(false);
        startButton.SetActive(false);
        controlsButton.SetActive(false);
        exitButton.SetActive(false);
        titlePanel.SetActive(false);
    }

    //called when "back button" is pressed
    //deactivates the controls screen & back button
    //acivates everything else

    public void DeactivateControlsScreen()
    {
        controlsScreen.SetActive(false);
        backButton.SetActive(false);

        menuScreen.SetActive(true);
        startButton.SetActive(true);
        controlsButton.SetActive(true);
        exitButton.SetActive(true);
        titlePanel.SetActive(true);
    }

    public void  RedWinScreen()
    {
        redWin.SetActive(true);
        blueWin.SetActive(false);
    }

    public void BlueWinScreen()
    {
        blueWin.SetActive(true);
        redWin.SetActive(false);
    }

    //loads the game scene (set by the "start game" button)
    public void LoadByIndex(int sceneIndex)
    {        
        SceneManager.LoadScene(sceneIndex);

    }

    //quit the game when "quit game" button is pressed.
    public void QuitGame()

    {
        Application.Quit();
    }
}
