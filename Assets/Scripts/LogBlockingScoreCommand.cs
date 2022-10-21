using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBlockingScoreCommand : Command
{
    private int _blockScore;
    private AttackPosition _attackPosition;
    private DefenceData _dataModule;

    public LogBlockingScoreCommand(int blockScore, AttackPosition attackPosition, DefenceData dataModule){
        _attackPosition = attackPosition;
        _blockScore = blockScore;
        _dataModule = dataModule;
    }

    public override void Execute(){
        _dataModule.AddBlockingScore(_blockScore, _attackPosition);
    }

    public override void Undo(){
        _dataModule.RemoveBlockingScore(_blockScore, _attackPosition);
    }
}
