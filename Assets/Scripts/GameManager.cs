using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Passing passing;
    MainScreen mainScreen;
    Scorer scorer;
    SessionScreen sessionScreen;
    Defence defence;

    void Awake()
    {
        passing = FindObjectOfType<Passing>();
        mainScreen = FindObjectOfType<MainScreen>();
        scorer = FindObjectOfType<Scorer>();
        sessionScreen = FindObjectOfType<SessionScreen>();
        defence = FindObjectOfType<Defence>();
    }
    void Start() 
    {
        mainScreen.gameObject.SetActive(true);
        sessionScreen.gameObject.SetActive(false);
        passing.gameObject.SetActive(false);
        defence.gameObject.SetActive(false);
    }

    // main screen controls
    public void OnNewSessionButtonPress()
    {
        defence.ResetDefence();
        passing.ResetPassing();

        mainScreen.gameObject.SetActive(false);
        sessionScreen.gameObject.SetActive(true);
    }

    public void QuitProgram()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

    // session screen controls
    public void OnBackFromSessionScreenButtonPress()
    {
        // save the session somehow or have a screen that pops up to ask to save a new session
        sessionScreen.gameObject.SetActive(false);
        mainScreen.gameObject.SetActive(true);
    }

    public void OnPassingButtonPress()
    {
        sessionScreen.gameObject.SetActive(false);
        passing.UpdateGraphics();
        passing.gameObject.SetActive(true);
    }

    public void OnDefenceButtonPress()
    {
        sessionScreen.gameObject.SetActive(false);
        // might need some update graphics method here
        defence.gameObject.SetActive(true);
    }

    
    // passing screen controls
    public void OnBackFromPassingScreenButtonPress()
    {
        // save the session somehow or have a screen that pops up to ask to save a new session
        passing.gameObject.SetActive(false);
        sessionScreen.gameObject.SetActive(true);
    }

    // defence screen controls
    public void OnBackFromDefenceScreenButtonPress()
    {
        // save the session somehow or have a screen that pops up to ask to save a new session
        defence.gameObject.SetActive(false);
        sessionScreen.gameObject.SetActive(true);
    }

}
