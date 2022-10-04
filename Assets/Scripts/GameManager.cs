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
}
