using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Button ResetButton;

    public readonly UICommandQueue CommandQueue = new UICommandQueue();


}
