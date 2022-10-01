using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModule
{
    private List<Command> commandHistory;

    public DataModule(){
      commandHistory = new List<Command>();
    }

    public void ExecuteCommand (Command command){
        command.Execute();
        commandHistory.Add(command);
    }

    public void UndoCommand(){
        int numCommands = commandHistory.Count;
        if(numCommands > 0){
            commandHistory[numCommands - 1].Undo();
            commandHistory.RemoveAt(numCommands - 1);
        }
    }
}
