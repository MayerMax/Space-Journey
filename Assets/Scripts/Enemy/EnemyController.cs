using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerShip;

        [SerializeField]
        private float collideOffset = 2.5f;

        void Update() {
            // AvoidObstaclesAndTurn();
            Turn();
            MoveForward();

            ShootingLogic();
        }

        void Start() {


        }

        private Vector3 CurrentPosition()
        {
            return playerShip.position - transform.position;
        }

       

        private void MoveForward()
        {
            float speed = 40f;

            transform.position += transform.forward * Time.deltaTime * speed;
        }

        private void Turn()
        {
            Vector3 pos = CurrentPosition();
            float speedDamp = 1.3f;
            Quaternion rotation = Quaternion.LookRotation(pos);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedDamp * Time.deltaTime);

        }

        private void ShootingLogic()
        {
            if (IsInFront())
                EmittingShot();
        }

        private bool IsInFront()
        {
            Vector3 targetVector = CurrentPosition();
            float angle = Vector3.Angle(transform.right, targetVector);

            // Можно поработать над углом
            if (Mathf.Abs(angle) < 90 && Mathf.Abs(angle) > 0)
                return true;

            return false;
        }
        // Пока что на стадии разработки
        // уточнить расстояние до корабля и.т.д , пока 50 - грязная константа 
        private void EmittingShot()
        {
            RaycastHit hit;
            Ray shootingRay = new Ray(transform.position, playerShip.position - transform.position);
            if (Physics.Raycast(shootingRay, out hit, 50))
            {
                if (hit.collider.tag == "Player")
                    Debug.DrawRay(transform.position, playerShip.position - transform.position, Color.green);
                // Заменить Debug на выстрел и передать управление и реализовать взаимодействие

            }
        }

        private void AvoidObstaclesAndTurn() {
            Vector3 currOffset = Vector3.zero;

            Vector3 left = transform.position - Vector3.right * collideOffset;
            Vector3 right = transform.position + Vector3.right * collideOffset;
            Vector3 up = transform.position + Vector3.up * collideOffset;
            Vector3 down = transform.position - Vector3.up * collideOffset;

            if (Physics.Raycast(left, transform.forward, 200))
                currOffset += Vector3.right;
            else if (Physics.Raycast(right, transform.forward, 200))
                currOffset -= Vector3.left;

            if (Physics.Raycast(up, transform.forward, 200))
                currOffset -= Vector3.up;
            else if (Physics.Raycast(up, transform.forward, 200))
                currOffset += Vector3.down;

            if (currOffset != Vector3.zero)
                transform.Rotate(currOffset * 5f * Time.deltaTime);
            else
                Turn();




        }
    }
}
