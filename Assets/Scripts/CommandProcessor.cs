using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    List<BaseCommand> Commands;

    int CurrentCommandIndex = 0;
    bool IsCommandIndexValid => CurrentCommandIndex >= 0 && CurrentCommandIndex < Commands.Count;
    BaseCommand CurrentCommand => IsCommandIndexValid ? Commands[CurrentCommandIndex] : null;

    // Start is called before the first frame update
    void Start()
    {
        Commands = new List<BaseCommand>(GetComponents<BaseCommand>());
    }

    // Update is called once per frame
    void Update()
    {
        ProcessCommands();
    }

    void ProcessCommands()
    {
        if (!IsCommandIndexValid)
            return;

        if (!CurrentCommand.IsExecuting)
            CurrentCommand.PrepareToExecute();

        var result = CurrentCommand.Execute();
        if (result == ECommandResult.Success)
        {
            CurrentCommand.CleanupAfterExecution();

            ++CurrentCommandIndex;
        }
        else if (result == ECommandResult.Failure)
            CurrentCommandIndex = Commands.Count;
    }

    public void EnqueueCommand(BaseCommand newCommand)
    {
        Commands.Add(newCommand);
    }
}
