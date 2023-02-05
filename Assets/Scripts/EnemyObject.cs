using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyObject : DamageableObject
{

    public const string SPEED_ANIM_PARAM = "Speed";
    public const string ATACK_ANIM_PARAM = "Attack";

    [SerializeField] private Animator animator;

    NavMeshAgent navMeshAgent;
    GameObject currentTarget;
    Wallet wallet;
    int enemyDefaultReward = 1;

    Vector3 previousPosition;
    float curSpeed = 0;


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

        Transform target = null;
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
                target = player.transform;
                ShortestDistance = distance;
                currentTarget = player;
            }

        }

        if (target != null)
        {
            navMeshAgent.destination = target.position;
            navMeshAgent.isStopped = false;
        }
    }

    void OnDestroy()
    {
        wallet.AddCoin(enemyDefaultReward);
    }

    private void Start()
    {
        base.Start();
        FindClosestPlayer();
        wallet = GameObject.Find("COIN_COUNTER").GetComponent<Wallet>();
    }

    protected void Attack()
    {

        if (target == null)
        { //there is no target, nothing to do here
            return;
        }

        
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance <= navMeshAgent.stoppingDistance)
        {
            DamageableObject damageableComp = target.GetComponent<DamageableObject>();

            if (damageableComp.IsItAlive())
            {
                if (CanAttack())
                {
                    lastAttackTime = Time.time;
                    damageableComp.TakeDamage(attackPower);
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
            navMeshAgent.ResetPath();
            navMeshAgent.SetDestination(target.transform.position);
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
            Vector3 newTargetPosition = currentTarget.transform.position;
            newTargetPosition.y = 0;
            transform.LookAt(newTargetPosition);
        }

        animator.SetFloat(SPEED_ANIM_PARAM, curSpeed);
        Attack();
    }
}
