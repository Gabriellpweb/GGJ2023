using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyObject : DamageableObject
{

    public const string SPEED_ANIM_PARAM = "Speed";
    public const string ATACK_ANIM_PARAM = "Attack";

    [SerializeField] private Animator animator;
    [SerializeField] float attackDistanceThreshold = 1f;

    NavMeshAgent navMeshAgent;
    GameObject currentTarget;
    int enemyDefaultReward = 4;

    Vector3 previousPosition;
    float curSpeed = 0;

    Bounds lastTargetBounds;


    private bool isPlayer(GameObject collidedGameObject)
    {
        if (collidedGameObject == null)
        {
            //Debug.Log("CollidedGameObject Null");
            return false ;
        }

        if (!collidedGameObject.CompareTag(DamageableObject.getPlayerTag()))
        {
            //Debug.Log("Wrong Tag");
            return false;
        }

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("it scratched me");

        GameObject collidedGameObject = other.gameObject;
        if (!isPlayer(other.gameObject)) {
            return;
        }

     
        target = other.gameObject;
        lastTargetBounds = other.bounds;
        float halfSize = lastTargetBounds.size.x / 2;
        if (halfSize > navMeshAgent.stoppingDistance)
        {
            navMeshAgent.isStopped = true;
        }
        
    }

    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void FindClosestPlayer()
    {
        NavMeshPath path = new NavMeshPath();
        GameObject[] players = GameObject.FindGameObjectsWithTag(DamageableObject.getPlayerTag());
        float ShortestDistance = float.MaxValue;

        Transform playerTarget = null;
        foreach (GameObject player in players)
        {
            Debug.Log($"Player units found {player.name}");

            if (!NavMesh.CalculatePath(transform.position, player.transform.position, navMeshAgent.areaMask, path))
            { //err during calc
                continue;
            }

            Debug.Log($"Validating distance");
            float distance = Vector3.Distance(transform.position, path.corners[0]);
            for (int i = 1; i < path.corners.Length; i++)
            {
                distance += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }

            if (distance < ShortestDistance)
            {
                Debug.Log($"Shortest one found!");
                playerTarget = player.transform;
                ShortestDistance = distance;
                currentTarget = player;
            }

        }

        if (playerTarget != null)
        {
            navMeshAgent.destination = playerTarget.position;
            navMeshAgent.isStopped = false;
        }
    }

    void OnDestroy()
    {
        Wallet.instance.AddCoin(enemyDefaultReward);
    }

    private void Start()
    {
        base.Start();
        FindClosestPlayer();
    }

    protected void Attack()
    {

        if (target == null)
        { //there is no target, nothing to do here
            //Debug.Log("Attack method target NULL");
            currentTarget = null;
            return;
        }

        //Debug.Log($"Attacked HP {Time.time - lastAttackTime > attackRate}");
        
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        float halfSize = lastTargetBounds.size.x / 2;
        Debug.Log($"half size: {halfSize}, navmesh dist: {navMeshAgent.stoppingDistance}");
        if (targetDistance <= navMeshAgent.stoppingDistance || halfSize > navMeshAgent.stoppingDistance - attackDistanceThreshold)
        {
            DamageableObject damageableComp = target.GetComponent<DamageableObject>();

            if (damageableComp.IsItAlive())
            {
                if (CanAttack())
                {
                    lastAttackTime = Time.time;
                    damageableComp.TakeDamage(attackPower);
                    //Debug.Log($"Attacked HP {damageableComp.lifePoints}");
                    animator.SetTrigger(ATACK_ANIM_PARAM);
                }
            }
            else
            {
                target = null;
                currentTarget = null;
                navMeshAgent.isStopped = true;
            }
        } else
        {
            if (Time.deltaTime % 2 == 0)
            {
                navMeshAgent.ResetPath();
                navMeshAgent.SetDestination(target.transform.position);
            }
        }
        
    }

    private bool CanAttack()
    {
        if (Time.time - lastAttackTime > attackRate)
        {
            return true;
        }

        return false;
    }

    private void Update()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        if (currentTarget == null)
        {
            FindClosestPlayer();
        }
        else
        {
            // Look to the current target
            if (currentTarget != null)
            {
                Vector3 newTargetPosition = currentTarget.transform.position;
                newTargetPosition.y = 0;
                transform.LookAt(newTargetPosition);
            }
        }

        animator.SetFloat(SPEED_ANIM_PARAM, curSpeed);
        Attack();
    }
}
