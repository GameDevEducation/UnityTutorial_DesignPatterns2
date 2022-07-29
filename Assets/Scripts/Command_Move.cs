using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Move : BaseCommand
{
    [SerializeField] Vector3 MoveVelocity;
    [SerializeField] float MoveDuration;

    float Progress = 0f;

    public void Configure(Vector3 velocity, float duration)
    {
        MoveVelocity = velocity;
        MoveDuration = duration;
    }

    protected override ECommandResult Execute_Internal()
    {
        if (MoveDuration <= 0)
            return ECommandResult.Failure;

        Progress += Time.deltaTime / MoveDuration;

        transform.Translate(MoveVelocity * Time.deltaTime);

        return Progress >= 1f ? ECommandResult.Success : ECommandResult.InProgress;
    }
}
