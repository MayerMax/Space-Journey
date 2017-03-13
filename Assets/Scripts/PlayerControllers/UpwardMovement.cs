using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.PlayerControllers;

namespace Assets.Scripts.PlayerControllers
{
    class UpwardMovement : BaseMovementController
    {
        public override void Move()
        {
            Turn();
            MoveForward();
        }

        private Transform currentTransform;

        public Transform ControllerObject
        {
            get { return currentTransform; }

            set { currentTransform = value; }
        }

        public UpwardMovement(Transform controllingObject)
        {
            ControllerObject = controllingObject;
            movementSpeed = 100f;
            turningSpeed = 30f;
        }

        private void MoveForward() {
            if (Input.GetAxis("2dView") > 0)
            ControllerObject.position += GetMovementDistance(currentTransform.forward);
        }

        private void Turn() {
            
            ControllerObject.position +=  ControllerObject.right* Time.deltaTime * 50f * Input.GetAxis("Horizontal");
        }


    }
}
