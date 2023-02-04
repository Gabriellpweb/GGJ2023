using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TurretVisualAnimation : MonoBehaviour
{
    private const string IDLE_TRIGER = "Idle";
    private const string ATTACK_TRIGER = "Attack";
    private const string DIE_TRIGER = "Die";

    [SerializeField] private Animator animator;


    void Start()
    {
        if (animator == null)
        {
            
            Debug.LogError("No animator assigned.");
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(ATTACK_TRIGER);
        } 
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(DIE_TRIGER);
        }
    }
}
