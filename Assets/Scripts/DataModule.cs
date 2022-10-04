using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataModule
{
    protected List<Command> _commandList;
    protected GameObject _hitMarkPrefab;

    public DataModule(GameObject hitMarkPrefab){
      _commandList = new List<Command>();
      _hitMarkPrefab = hitMarkPrefab;
    }

    public void UndoLastCommand(){
        if(_commandList.Count > 0){
            _commandList.Last().Undo();
            _commandList.RemoveAt(_commandList.Count - 1);
        }
    }
}
