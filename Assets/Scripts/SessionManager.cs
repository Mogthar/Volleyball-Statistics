using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public string currentSessionName {get; private set;}
    public PassingData passingData;
    private List<DataModule> _dataModules;

    [SerializeField] private GameObject _passingHitMark;
    // Start is called before the first frame update
    void Start()
    {
        passingData = new PassingData(_passingHitMark, GameManager.UI.passingMenu);
        _dataModules = new List<DataModule>();

        _dataModules.Add(passingData);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNewSession(string newSessionName){
        currentSessionName = newSessionName;
        RestartDataModules();
    }

    public void SaveCurrentSession(){

    }

    private void RestartDataModules(){
        // go through modules and assign new objects

    }
}
