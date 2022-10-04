using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHitMarkCommand : Command
{
    private GameObject _hitMark;

    private Vector3 _hitMarkPosition;
    private int _hitMarkScore;
    private GameObject _hitMarkPrefab;
    private GameObject _parent;

    public CreateHitMarkCommand(Vector3 position, int score, GameObject prefab, GameObject parent){
        _hitMarkPosition = position;
        _hitMarkScore = score;
        _hitMarkPrefab = prefab;
        _parent = parent;
    }

    public override void Execute(){
        _hitMark = Object.Instantiate(_hitMarkPrefab, _hitMarkPosition, Quaternion.identity, _parent.transform);
    }

    public override void Undo(){
        Object.Destroy(_hitMark);
        _hitMark = null;
    }
}
