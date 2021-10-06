using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Characters.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMotor : MonoBehaviour
    {
        NavMeshAgent agent;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        public void MoveToPoint(Vector3 point)
        {
            agent.SetDestination(point);
        }
    }
}