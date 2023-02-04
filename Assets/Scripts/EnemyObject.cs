using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyObject : DamageableObject
{

    NavMeshAgent navMeshAgent;
    GameObject currentTarget;

  

    private bool isPlayer(GameObject collidedGameObject)
    {
        if (collidedGameObject == null)
        {
            Debug.Log("CollidedGameObject Null");
            return false ;
        }

        if (!collidedGameObject.CompareTag(DamageableObject.getPlayerTag()))
        {
            Debug.Log("Wrong Tag");
            return false;
        }

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("it scratched me");

        GameObject collidedGameObject = other.gameObject;
        if (!isPlayer(other.gameObject)) {
            return;
        }

        target = other.gameObject;
        

       // Destroy(collidedGameObject); //test
   

    }

    
    //[SerializeField] private Transform movePositionTransform;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void FindClosestPlayer()
    {
        NavMeshPath path = new NavMeshPath();
        GameObject[] players = GameObject.FindGameObjectsWithTag(DamageableObject.getPlayerTag());
        float ShortestDistance = float.MaxValue;

        Transform target = null;

        foreach (GameObject player in players)
        {
            if (!NavMesh.CalculatePath(transform.position, player.transform.position, navMeshAgent.areaMask, path))
            { //err during calc
                continue;
            }

            float distance = Vector3.Distance(transform.position, path.corners[0]);
            for (int i = 1; i < path.corners.Length; i++)
            {
                distance += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }

            if (distance < ShortestDistance)
            {
                target = player.transform;
                ShortestDistance = distance;
                currentTarget = player;
            }

        }

        if (target != null)
        {
            navMeshAgent.destination = target.position;
        }

        Debug.Log("Eu fui executado ");
    }


    private void Start()
    {
        FindClosestPlayer();
        
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            FindClosestPlayer();
        }

        
    }
}
