using UnityEngine;
using UnityEngine.Tilemaps;

public class HidenArea : MonoBehaviour
{
    private Tilemap MAP;
    private Animator ANIM;

    [SerializeField] private Color tranparent;
    [SerializeField] private Color visible;
   

    private void Awake()
    {
        MAP = GetComponent<Tilemap>();
        ANIM = GetComponent<Animator>();
    }

    public void SetTransparent()
    {
        //MAP.color = tranparent;
        ANIM.SetTrigger("CollisionEnter");
    }

    public void SetVisible()
    {
        //MAP.color = visible;
        ANIM.SetTrigger("CollisionExit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent<PlayerMovement>(out var playerMovement))
            MAP.color = tranparent;
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (TryGetComponent<PlayerMovement>(out var playerMovement))
    //        MAP.color = visible;
    //}
}
