using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(SessionManager))]
public class GameManager : MonoBehaviour
{
    public static UIManager UI {get; private set;}
    public static SessionManager Session {get; private set;}

    void Awake(){
      UI = GetComponent<UIManager>();
      Session = GetComponent<SessionManager>();
    }


    void Start()
    {

    }


    /*
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
    */

}
