using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnQuit(){
      #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
      #endif

      Application.Quit();
    }

    public void OnNewSession(){

    }

    public void OnLoadSession(){
      
    }
}
