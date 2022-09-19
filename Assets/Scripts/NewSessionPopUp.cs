using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewSessionPopUp : MonoBehaviour
{
    // [SerializeField] private MainMenu mainMenu;
    [SerializeField] private TMP_InputField inputField;

    public void OnBackButton(){
        inputField.text = "";
        GameManager.UI.mainMenu.ClosePopUp();
    }

    public void OnCreateSession(){
        string newSessionName = inputField.text;
        inputField.text = "";
        GameManager.Session.StartNewSession(newSessionName);
        GameManager.UI.TransitionBetweenMenus(GameManager.UI.mainMenu, GameManager.UI.sessionMenu);
    }

}
