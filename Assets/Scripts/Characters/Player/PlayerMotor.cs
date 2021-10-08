using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Characters.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMotor : MonoBehaviour
    {
        Transform target;
        public NavMeshAgent agent;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
                FaceTarget();
            }
        }
        public void MoveToPoint(Vector3 point)
        {
            agent.SetDestination(point);
        }
        public void FollowTarget(Interactable newTarget)
        {
            agent.updateRotation = false;

            target = newTarget.transform;
        }
        public void StopFollowingTarget()
        {
            target = null;

            agent.stoppingDistance = 0;
            agent.updateRotation = true;
        }
        void FaceTarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        }
    }
}