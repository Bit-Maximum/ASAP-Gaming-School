using System.Runtime.CompilerServices;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Animator ANIM;

    public bool IsActive;

    private void Awake()
    {
        Debug.Log("Awake");
        ANIM = GetComponent<Animator>();
        
        IsActive = true;
    }
    private void Start()
    {
        ANIM.SetTrigger("On");
    }

    public void SetActive()
    {
        Debug.Log("Active");

        IsActive = true;
    }

    public void SetDisabled()
    {
        Debug.Log("Disable");
        ANIM.SetTrigger("Off");
        IsActive = false;
    }
}
