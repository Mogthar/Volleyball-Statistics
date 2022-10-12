using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateHitMarkCommand : Command
{
    private GameObject _hitMark;

    private Vector3 _hitMarkPosition;
    private int _hitMarkScore;
    private GameObject _hitMarkPrefab;
    private GameObject _parent;
    private DataModule _dataModule;

    public CreateHitMarkCommand(Vector3 position, int score, GameObject prefab, GameObject parent, DataModule module){
        _hitMarkPosition = position;
        _hitMarkScore = score;
        _hitMarkPrefab = prefab;
        _parent = parent;
        _dataModule = module;
    }

    public override void Execute(){
        _hitMark = Object.Instantiate(_hitMarkPrefab, _hitMarkPosition, Quaternion.identity, _parent.transform);
        _dataModule.AddHitMark(_hitMarkScore, _hitMark);

        // NEEDS TO BE CHECKED
        if(_hitMark.TryGetComponent(out Image hitMarkImage)){
            hitMarkImage.color = _dataModule.ScoreToColourConversion(_hitMarkScore);
        }
    }

    public override void Undo(){
        _dataModule.RemoveHitMark(_hitMarkScore, _hitMark);
        Object.Destroy(_hitMark);
        _hitMark = null;
    }
}
