using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewSessionPopUp : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private TMP_InputField inputField;

    public void OnBackButton(){
        inputField.text = "";
        mainMenu.ClosePopUp();
    }

    public void OnCreateSession(){
        string newSessionName = inputField.text;
        inputField.text = "";
        GameManager.Session.StartNewSession(newSessionName);
        // close pop up via main menu
        // close main menu via UI manager
    }

}
