using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogServiceErrorCommand : Command
{
    private ServingData _dataModule;

    public LogServiceErrorCommand(ServingData dataModule){
        _dataModule = dataModule;
    }

    public override void Execute(){
        _dataModule.AddServiceError();
    }

    public override void Undo(){
        _dataModule.RemoveServiceError();
    }
}
