using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public string currentSessionName {get; private set;}

    public PassingData passingData;
    public AttackData attackData;
    public DefenceData defenceData;
    public ServingData servingData;
    private List<DataModule> _dataModules;

    [SerializeField] private GameObject _passingHitMark;
    [SerializeField] private GameObject _attackHitMark;
    [SerializeField] private GameObject _defenceHitMark;
    [SerializeField] private GameObject _servingHitMark;

    // Start is called before the first frame update
    void Awake()
    {
        // RestartDataModules();
    }


    public void StartNewSession(string newSessionName){
        currentSessionName = newSessionName;
        RestartDataModules();
    }

    public void SaveCurrentSession(){
        // loop through datamodules to save the data
        // create a new object  to store the data?
    }

    public void LoadSession(){
    }

    private void RestartDataModules(){
        if(_dataModules != null){
            _dataModules.Clear();
        }

        passingData = new PassingData(_passingHitMark, GameManager.UI.passingMenu);
        attackData = new AttackData(_attackHitMark, GameManager.UI.attackMenu);
        defenceData = new DefenceData(_defenceHitMark, GameManager.UI.defenceMenu);
        servingData = new ServingData(_servingHitMark, GameManager.UI.servingMenu);

        _dataModules = new List<DataModule>();
        _dataModules.Add(passingData);
        _dataModules.Add(attackData);
        _dataModules.Add(defenceData);
        _dataModules.Add(servingData);
    }
}
