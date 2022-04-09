using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Defence : MonoBehaviour
{
    [SerializeField] GameObject[] attackButtons;
    [SerializeField] public GameObject hitMark;
    [SerializeField] GameObject court;
    [SerializeField] float hitmarkAlpha = 0.5f;
    
    // a list to store the commmands
    private List<CreateHitMarkCommand> commandList = new List<CreateHitMarkCommand>();

    // an array of lists to store new hit marks
    private List<GameObject>[] hitMarkList;

    private bool[] buttonState;
    
    // command class that creates a new hit mark; used for the command pattern
    public class CreateHitMarkCommand
    {
        private GameObject hitMarkPrefab;
        private int attackPositionIndex;
        private GameObject newHitMark;
        private Vector3 hitMarkPosition;
        private Defence parentDefence;
        public CreateHitMarkCommand(int attPosIndex, Vector3 hitMarkPos, GameObject hitMarkObject, Defence parent)
        {
            attackPositionIndex = attPosIndex;
            hitMarkPosition = hitMarkPos;
            hitMarkPrefab = hitMarkObject;
            parentDefence = parent;
        }
        public GameObject Execute()
        {
            if(hitMarkPrefab == null)
            {
                return null;
            }
            else
            {
                newHitMark = Instantiate(hitMarkPrefab, hitMarkPosition, Quaternion.identity, parentDefence.transform);
                return newHitMark;
            }
        }
        public void Undo(List<GameObject>[] listOfHitmarks)
        {
            if(newHitMark == null)
            {
                return;
            }
            else
            {
                // remove hit mark from the list
                listOfHitmarks[attackPositionIndex].Remove(newHitMark);
                // destroy the hitmark
                Destroy(newHitMark);
                // might need to somehow destroy this object but might not be needed thanks to GC
            }
        }
    }

    void Awake()
    {
        // initialize the array of lists that holds hit marks corresponding to different buttons
        hitMarkList = new List<GameObject>[attackButtons.Length];
        buttonState = new bool[attackButtons.Length];
        for(int i = 0; i < attackButtons.Length; i++)
        {
            hitMarkList[i] = new List<GameObject>();
            buttonState[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttackButtonPress(GameObject attackButton)
    {
        int indexOfAttackButton = Array.IndexOf(attackButtons, attackButton);
        ToggleButtons(indexOfAttackButton);
        // switch the state of the toggled button

        for(int i = 0; i < attackButtons.Length; i++)
        {
            for(int j = 0; j < hitMarkList[i].Count; j++)
            {
                SpriteRenderer hitmarkSpriteRenderer = hitMarkList[i][j].GetComponent<SpriteRenderer>();
                Color originalColor = hitmarkSpriteRenderer.color;
                if (buttonState[i])
                {
                    hitmarkSpriteRenderer.color = new Color (originalColor.r, originalColor.g, originalColor.b, 1.0f);
                }
                else
                {
                    hitmarkSpriteRenderer.color = new Color (originalColor.r, originalColor.g, originalColor.b, hitmarkAlpha);
                }   
            }
        }
    }

    private void ToggleButtons(int indexOfPressedButton)
    {
        if(buttonState[indexOfPressedButton] & !AreAllButtonsToggled())
        {
            ToggleAllButtons();
        }
        else
        {
            ToggleOneButton(indexOfPressedButton);
        }
    }

    private bool AreAllButtonsToggled()
    {
        for(int i = 0; i < buttonState.Length; i++)
        {
            if(!buttonState[i])
            {
                return false;
            }
        }
        return true;
    }
    private void ToggleAllButtons()
    {
        for(int i = 0; i < buttonState.Length; i++)
        {
            buttonState[i] = true;
        }
    }
    private void ToggleOneButton(int indexOfToggledButton)
    {
        for(int i = 0; i < buttonState.Length; i++)
        {
            if(i == indexOfToggledButton)
            {
                buttonState[i] = true;
            }
            else
            {
                buttonState[i] = false;
            }
        }
    }
    public void CreateHitMark(Vector3 position, GameObject attackButton)
    {
        // check if arrow is above the pitch before creating the mark
        // apparently its better to directly store the pinter hover as an object and act on it directly rather than store the game object it is attached to
        if(court.GetComponent<PointerHover>().isPointerOverObject)
        {
            int indexOfAttackButton = Array.IndexOf(attackButtons, attackButton);
            CreateHitMarkCommand command = new CreateHitMarkCommand(indexOfAttackButton, position, hitMark, this);
            commandList.Add(command);
            GameObject nextHitMark = command.Execute();
            hitMarkList[indexOfAttackButton].Add(nextHitMark);
        }
    }

    public void OnUndoButtonPress()
    {
        UndoLastCommand();
    }

    private void UndoLastCommand()
    {
        int numberOfCommands = commandList.Count;
        if(numberOfCommands > 0)
        {
            CreateHitMarkCommand lastCommand = commandList[numberOfCommands-1];
            commandList.RemoveAt(numberOfCommands - 1);
            lastCommand.Undo(hitMarkList);
            // potentially set last command to null if need be
        }
    }
    public void ResetDefence()
    {
        // clear the command list (hopefully the commands will disappear from the memory?)
        commandList.Clear();
        // go through hitmarks and destroy them
        for(int i = 0; i < attackButtons.Length; i++)
        {
            for(int j = 0; j < hitMarkList[i].Count; j++)
            {
                Destroy(hitMarkList[i][j]);
            }
        }
        // finally clear the hitmark lists
        for(int i = 0; i < attackButtons.Length; i++)
        {
            hitMarkList[i].Clear();
        }
    }
}


// might need to have the list of commands changed into and array to have a fixed number of commands that one can udno