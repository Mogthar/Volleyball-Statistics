using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public string currentSessionName {get; private set;}
    // Start is called before the first frame update
    void Start()
    {

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
