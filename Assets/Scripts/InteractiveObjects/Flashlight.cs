using System.Runtime.CompilerServices;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Animator ANIM;

    public bool IsActive;

    private void Awake()
    {
        IsActive = true;
    }

    public void SetActive()
    {
        IsActive = true;
    }

    public void SetDisabled()
    {
        ANIM.SetTrigger("Off");
        IsActive = false;
    }
}
