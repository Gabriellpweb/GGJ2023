using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMeshObject : MonoBehaviour
{
    //public NavMeshAgent navMeshAgent;
    ////[SerializeField] private Transform movePositionTransform;
    //private void Awake()
    //{
    //    navMeshAgent = GetComponent<NavMeshAgent>();
    //}


    //public void FindClosestPlayer()
    //{
    //    NavMeshPath path = new NavMeshPath();
    //    GameObject[] players = GameObject.FindGameObjectsWithTag(DamageableObject.getPlayerTag());
    //    float ShortestDistance = float.MaxValue;

    //    Transform target = null;

    //    foreach (GameObject player in players) {
    //        if (!NavMesh.CalculatePath(transform.position, player.transform.position, navMeshAgent.areaMask, path)) { //err during calc
    //            continue;
    //        }

    //        float distance = Vector3.Distance(transform.position, path.corners[0]);
    //        for (int i = 1; i < path.corners.Length; i++) {
    //            distance += Vector3.Distance(path.corners[i-1], path.corners[i]);
    //        }

    //        if (distance < ShortestDistance) {
    //            target = player.transform;
    //            ShortestDistance = distance;
    //        } 
            
    //    }

    //    if (target != null) {
    //        navMeshAgent.destination = target.position;
    //    }

    //    Debug.Log("Eu fui executado ");
    //}

    private void Start()
    {
        //FindClosestPlayer();    
    }

    private void Update()
    {
        //FindClosestPlayer();
        //navMeshAgent.destination = movePositionTransform.position;
    }
}
