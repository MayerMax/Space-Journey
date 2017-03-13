using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.PlayerControllers;
using System;

public class MoveUpOnly : BaseMovementController {
    private Transform currentTransform;

    public MoveUpOnly(Transform FollowingTransform) {
        ControllerObject = FollowingTransform;
    }

    public Transform ControllerObject
    {
        get { return currentTransform; }

        set { currentTransform = value; }
    }

    public override void Move()
    {
        UpForTwoDimensions();
        TurnForTwoDimensions();
    }

    private void TurnForTwoDimensions() {

        ControllerObject.position += GetMovementDistance(currentTransform.forward) * Input.GetAxis("Horizontal");
    }

    private void UpForTwoDimensions() {
        ControllerObject.position += GetMovementDistance(currentTransform.up) * Input.GetAxis("2dView");

    }
}
