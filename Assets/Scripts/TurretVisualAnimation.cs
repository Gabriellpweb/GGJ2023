using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TurretVisualAnimation : MonoBehaviour
{
    public const string IDLE_TRIGER = "Idle";
    public const string ATTACK_TRIGER = "Attack";
    public const string DIE_TRIGER = "Die";

    [SerializeField] private Animator animator;
    [SerializeField] private Tower towerController;

    void Start()
    {
        if (animator == null)
        {   
            Debug.LogError("No animator assigned.");
        }
        if (towerController == null)
        {
            Debug.LogError("No tower controler assigned.");
        }
        towerController.OnDie += TriggerDieAnimation;
    }



    public void TriggerAttackAnimation(object sender, System.EventArgs e)
    {
        animator.SetTrigger(ATTACK_TRIGER);
    }

    public void TriggerDieAnimation(object sender, System.EventArgs e)
    {
        animator.SetTrigger(DIE_TRIGER);
    }
}
