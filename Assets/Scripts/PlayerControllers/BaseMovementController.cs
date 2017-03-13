using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.PlayerControllers
{
    public abstract class BaseMovementController : MonoBehaviour
    {

        [SerializeField]
        protected float movementSpeed;
        public float MovementSpeed {
            get { return movementSpeed; }
            set { movementSpeed = value; }
        }

        [SerializeField]
        protected float turningSpeed;
        public float TurningSpeed {
            get { return turningSpeed; }
            set { turningSpeed = value; }
        }

        protected bool isActive;
        public bool IsActive {
            get { return isActive; }
        }

        Transform ControllerObject { get; set; }

        public abstract void Move();

        public Vector3 GetMovementDistance(Vector3 direction) {
            return direction * 50 * Time.deltaTime;
        }
    }
}
