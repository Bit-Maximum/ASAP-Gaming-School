using UnityEngine;

public class Flashlight : MonoBehaviour
{
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
        IsActive = false;
    }
}
