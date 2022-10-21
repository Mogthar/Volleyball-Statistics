using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateHitMarkCommand : Command
{
    protected GameObject _hitMark;

    protected Vector3 _hitMarkPosition;
    protected int _hitMarkScore;
    protected GameObject _hitMarkPrefab;
    protected GameObject _parent;
    protected DataModule _dataModule;

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
