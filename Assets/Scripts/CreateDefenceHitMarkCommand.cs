using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDefenceHitMarkCommand : CreateHitMarkCommand
{
    private AttackPosition _attackPosition;
    private DefenceData _defenceData;

    public CreateDefenceHitMarkCommand(Vector3 position, int score, GameObject prefab, GameObject parent, DefenceData defenceModule, AttackPosition attackPosition) : base(position, score, prefab, parent, defenceModule){
        _attackPosition = attackPosition;
        _defenceData = defenceModule;
    }

    public override void Execute(){
        _hitMark = Object.Instantiate(_hitMarkPrefab, _hitMarkPosition, Quaternion.identity, _parent.transform);
        _defenceData.AddHitMark((int) _attackPosition, _hitMark);
        _defenceData.AddDefenceScore(_attackPosition, _hitMarkScore);

        if(_hitMark.TryGetComponent(out Image hitMarkImage)){
            hitMarkImage.color = _defenceData.ScoreToColourConversion(_hitMarkScore);
        }
    }

    public override void Undo(){
        _defenceData.RemoveHitMark((int) _attackPosition, _hitMark);
        Object.Destroy(_hitMark);
        _hitMark = null;

        _defenceData.RemoveDefenceScore(_attackPosition, _hitMarkScore);
    }
}
