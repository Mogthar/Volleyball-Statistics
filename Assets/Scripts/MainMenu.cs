using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NewSessionPopUp sessionPopUp;
    // Start is called before the first frame update
    void Start()
    {
        sessionPopUp.gameObject.SetActive(false);
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
        sessionPopUp.gameObject.SetActive(true);
    }

    public void OnLoadSession(){

    }

    public void ClosePopUp(){
        sessionPopUp.gameObject.SetActive(false);
    }
}
