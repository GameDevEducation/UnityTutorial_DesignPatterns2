using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandUI : MonoBehaviour
{
    [SerializeField] CommandProcessor TargetProcessor;

    public void OnCommand_PosX()
    {
        var newCommand = TargetProcessor.gameObject.AddComponent<Command_Move>();
        newCommand.Configure(new Vector3(3f, 0f, 0f), 3f);
        TargetProcessor.EnqueueCommand(newCommand);
    }

    public void OnCommand_NegX()
    {
        var newCommand = TargetProcessor.gameObject.AddComponent<Command_Move>();
        newCommand.Configure(new Vector3(-3f, 0f, 0f), 3f);
        TargetProcessor.EnqueueCommand(newCommand);
    }

    public void OnCommand_PosY()
    {
        var newCommand = TargetProcessor.gameObject.AddComponent<Command_Move>();
        newCommand.Configure(new Vector3(0f, 3f, 0f), 3f);
        TargetProcessor.EnqueueCommand(newCommand);
    }

    public void OnCommand_NegY()
    {
        var newCommand = TargetProcessor.gameObject.AddComponent<Command_Move>();
        newCommand.Configure(new Vector3(0f, -3f, 0f), 3f);
        TargetProcessor.EnqueueCommand(newCommand);
    }

    public void OnCommand_PosZ()
    {
        var newCommand = TargetProcessor.gameObject.AddComponent<Command_Move>();
        newCommand.Configure(new Vector3(0f, 0f, 3f), 3f);
        TargetProcessor.EnqueueCommand(newCommand);
    }

    public void OnCommand_NegZ()
    {
        var newCommand = TargetProcessor.gameObject.AddComponent<Command_Move>();
        newCommand.Configure(new Vector3(0f, 0f, -3f), 3f);
        TargetProcessor.EnqueueCommand(newCommand);
    }
}
