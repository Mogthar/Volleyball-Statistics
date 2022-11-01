using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionMenu : GameMenu
{
    [SerializeField] private TMP_Text sessionNameText;
    [SerializeField] private QuitSessionPopUp quitPopUp;

    // Start is called before the first frame update
    void Start()
    {
        ClosePopUp();
    }



    public void ClosePopUp(){
        quitPopUp.gameObject.SetActive(false);
    }

    private void ChangeSessionName(string newName){
        sessionNameText.text = newName;
    }

    public void OnPassing(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.passingMenu);
    }

    public void OnAttack(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.attackMenu);
    }

    public void OnDefence(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.defenceMenu);
    }

    public void OnService(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.servingMenu);
    }

    public void OnQuitSession(){
        quitPopUp.gameObject.SetActive(true);
    }

    public override void OnTransitionIn() {
        ChangeSessionName(GameManager.Session.currentSessionName);
    }

    public override void OnTransitionOut() {
        ClosePopUp();
    }




}
