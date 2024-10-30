using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionPatrolEnemy : MonoBehaviour
{
    public Animator ANIM;

    [SerializeField] public string attackSwingTrigetParameter;
    [SerializeField] public string attackTrigetParameter;
    [SerializeField] public string hurtTrigetParameter;
    [SerializeField] public string aggroTrigetParameter;
    [SerializeField] public string runFloatParameter;
    [SerializeField] public string lostTargetBoolParameter;
    [SerializeField] public string stunEndedTrigerParameter;
    [SerializeField] public string dieTrigerParameter;

    private void Awake()
    {
        ANIM = GetComponent<Animator>();
    }

    public void TrigerAttackAnimation()
    {
        ANIM.SetTrigger(attackTrigetParameter);
    }
    
    public void TrigerAttackSwingAnimation()
    {
        ANIM.SetTrigger(attackSwingTrigetParameter);
    }

    public void TrigerHurtAnimation()
    {
        ANIM.SetTrigger(hurtTrigetParameter);
    }

    public void TrigerAggroTriger()
    {
        ANIM.SetTrigger(aggroTrigetParameter);
    }

    public void TrigerStunEndedTriger()
    {
        ANIM.SetTrigger(stunEndedTrigerParameter);
    }

    public void TrigerDieTriger()
    {
        ANIM.SetTrigger(dieTrigerParameter);
    }

    public void UpdateRunAnimation(float currentSpeed)
    {
        ANIM.SetFloat(runFloatParameter, currentSpeed);
    }

    public void SetLostTargetPrarametr(bool newState)
    {
        ANIM.SetBool(lostTargetBoolParameter, newState);
    }
}
