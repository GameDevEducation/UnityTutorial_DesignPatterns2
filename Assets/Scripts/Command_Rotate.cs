using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Rotate : BaseCommand
{
    [SerializeField] Vector3 RotationRate;
    [SerializeField] float RotationDuration;

    float Progress = 0f;

    protected override ECommandResult Execute_Internal()
    {
        if (RotationDuration <= 0)
            return ECommandResult.Failure;

        Progress += Time.deltaTime / RotationDuration;

        transform.Rotate(RotationRate * Time.deltaTime);

        return Progress >= 1f ? ECommandResult.Success : ECommandResult.InProgress;
    }
}
