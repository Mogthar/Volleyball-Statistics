using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataModule
{
    protected List<Command> _commandList;
    protected GameObject _hitMarkPrefab;
    protected Dictionary<int, List<GameObject>> _hitMarkCollection;
    protected GameMenu _sisterMenu;

    public DataModule(GameObject hitMarkPrefab, GameMenu sisterMenu){
      _commandList = new List<Command>();
      _hitMarkCollection = new Dictionary<int, List<GameObject>>();
      _hitMarkPrefab = hitMarkPrefab;
      _sisterMenu = sisterMenu;
    }

    public void UndoLastCommand(){
        if(_commandList.Count > 0){
            _commandList.Last().Undo();
            _commandList.RemoveAt(_commandList.Count - 1);
            _sisterMenu.UpdateGraphics();
        }

    }

    public void AddHitMark(int score, GameObject newHitMark){
        if(_hitMarkCollection.ContainsKey(score)){
            _hitMarkCollection[score].Add(newHitMark);
        }
        else{
            _hitMarkCollection.Add(score, new List<GameObject>());
            _hitMarkCollection[score].Add(newHitMark);
        }
    }

    public void RemoveHitMark(int score, GameObject hitMark){
        // need to add checking for existence of hit mark
        _hitMarkCollection[score].Remove(hitMark);
    }
}
