using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.PlayerControllers;
using System;


// Terminology on rotatinon:
// Yaw - рыскание, on the Y axis
//Pitch - наклон, on the X axis
// Roll - вращение, on Z axis


public class PlayerMovement : BaseMovementController {

    [SerializeField]
    float turnAngleMultiplyer;

    private Transform currentTransform;

    public Transform ControllerObject
    {
        get { return currentTransform; }

        set { currentTransform = value; }
    }

    public PlayerMovement(Transform controllingObject) {
        ControllerObject = controllingObject;
        movementSpeed = 100f;
        turnAngleMultiplyer = 10f;
        turningSpeed = 30f;
    }

    // Yawning
    private void Turn() {
        var turnAngle = Time.deltaTime * turningSpeed;

        var yaw = turnAngle * Input.GetAxis("Horizontal") * turnAngleMultiplyer;
        var pitch = turnAngle * Input.GetAxis("Pitch");
        var roll = turnAngle * Input.GetAxis("Roll") * turnAngleMultiplyer;

        isActive = yaw != 0 || pitch != 0 || roll != 0;

        currentTransform.Rotate(pitch, yaw, -roll);
    }

    // moving up and down strictly
    void TurnForTwoDimension() {
        currentTransform.position += GetMovementDistance(currentTransform.up) * Input.GetAxis("2dView");
    }

    // could be also named as Thrusting - like adding power to it
    void MovingForwardAndBack() {
        currentTransform.position += GetMovementDistance(currentTransform.forward) * Input.GetAxis("Vertical");
    }

   private void MovingForward() {
        if (Input.GetAxis("Vertical") > 0) {
            Vector3 powerToMove = GetMovementDistance(currentTransform.forward) * Input.GetAxis("Vertical");

            isActive = powerToMove != Vector3.zero;

            currentTransform.position += powerToMove;
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //    InfectFumes(true);
        //else if (Input.GetKeyUp(KeyCode.W))
        //    InfectFumes(false);
    }

    //private void InfectFumes(bool flag) {
    //    foreach (var fume in fumes)
    //        fume.Activate(flag);
    //}

    public override void Move()
    {
        Turn();
        MovingForward();
    }
}
