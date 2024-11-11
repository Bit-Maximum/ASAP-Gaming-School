using System.Runtime.CompilerServices;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Animator ANIM;

    public bool IsActive;

    private void Awake()
    {
        ANIM = GetComponent<Animator>();
        IsActive = true;
    }
    private void Start()
    {
        ANIM.SetTrigger("On");
    }

    public void SetActive()
    {
        IsActive = true;
    }

    public void SetDisabled()
    {
        ANIM.SetTrigger("Off");
        IsActive = true;
    }
}
