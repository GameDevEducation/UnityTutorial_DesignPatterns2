using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECommandResult
{
    Success,
    Failure,
    InProgress
}

public abstract class BaseCommand : MonoBehaviour
{
    public bool IsExecuting { get; private set; } = false;

    public ECommandResult Execute()
    {
        IsExecuting = true;

        var result = Execute_Internal();
        if (result != ECommandResult.InProgress)
            IsExecuting = false;

        return result;
    }

    protected void Update()
    {
        if (IsExecuting)
        {
            Execute();
        }
    }

    public void PrepareToExecute()
    {
        PrepareToExecute_Internal();
    }

    public void CleanupAfterExecution()
    {
        CleanupAfterExecution_Internal();
    }

    protected virtual void PrepareToExecute_Internal() { }
    protected virtual void CleanupAfterExecution_Internal() { }

    protected abstract ECommandResult Execute_Internal();
}
