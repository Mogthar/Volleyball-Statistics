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

    // Update is called once per frame
    void Update()
    {

    }

    public void ClosePopUp(){
        quitPopUp.gameObject.SetActive(false);
    }

    public void OnQuitSession(){
        quitPopUp.gameObject.SetActive(true);
    }

    private void ChangeSessionName(string newName){
        sessionNameText.text = newName;
    }

    public override void OnTransitionIn() {
        ChangeSessionName(GameManager.Session.currentSessionName);
    }

    public override void OnTransitionOut() {
        ClosePopUp();
    }




}
