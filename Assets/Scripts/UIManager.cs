using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
