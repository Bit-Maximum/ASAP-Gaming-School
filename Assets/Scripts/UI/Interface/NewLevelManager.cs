using UnityEngine;

public class NewLevelManager : MonoBehaviour
{
    [SerializeField] private LevelHUD levelHUD;

    private NewLevelProgress progress;

    private void Awake()
    {
        progress = new NewLevelProgress();
    }

    public void UpdateScore(int score)
    {
        progress.LevelScore += score;
        levelHUD.CommandQueue.TryEnqueueCommand(new UpdateScoreCommand(progress.LevelScore));

    }
}