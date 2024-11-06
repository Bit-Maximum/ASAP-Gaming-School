using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private Animator ANIM;
    private Rigidbody2D RB;

    [SerializeField] private GlobalLightManager globalLight;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text ComboText;
    [SerializeField] private TMP_Text BallsLeftText;
    [SerializeField] private TMP_Text HealthText;

    [SerializeField] private int score = 0;
    [SerializeField] private int scoreBaseMultyplier = 1;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int ballsLeft = 3;
    
    public int ballsCounter = 0;

    [SerializeField] private int comboDurationTime;
    [SerializeField] private float stunByAttackDurationTime;
    [SerializeField] private float stunByTaranDurationTime;

    private int scoreMultyplier;

    [SerializeField][Range(0.1f, 1f)] private float StunnedSlowTimeScale;
    [SerializeField] private float StunnedSlowTimeDuration;

    public Vector2 TakeAttackDamageFeedbackForce;
    public Vector2 TakeTaranDamageFeedbackForce;

    private bool IsStunned;

    private float LastComboTime = 0;
    private float LastStunnedTime = 0;
    private float LastTimeSlowed = 0;

    private void Awake()
    {
        ANIM = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();

        ChageScore(0);
        DropScoreMultyplier();
        TakeDamage(0);
        ShowBallsLeft();

        ballsCounter = 0;
}

    private void Update()
    {
        LastComboTime -= Time.deltaTime;
        LastStunnedTime -= Time.deltaTime;
        LastTimeSlowed -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (maxHealth < 1)
            Die();

        if (IsStunned && LastStunnedTime < 0)
        {
            ANIM.SetTrigger("StunEnded");
            IsStunned = false;
        }

        if (scoreMultyplier > scoreBaseMultyplier && LastComboTime < 0)
        {
            ChangeScoreMultyplier(-1);
        }

        if (Time.timeScale < 1 && LastTimeSlowed < 0)
        {
            ResetTimeScale();
        }
    }

    #region Setters
    public void ChageScore(int amount)
    {
        score += amount * scoreMultyplier;
        ScoreText.text = $"Score: {score}";
    }

    public void TakeDamage(int amount)
    {
        maxHealth -= amount;
        if (maxHealth <= 0)
            Die();
        HealthText.text = $"Healt: {maxHealth}";
    }

    public void Heal(int amount)
    {
        maxHealth += amount;
        HealthText.text = $"Healt: {maxHealth}";
    }

    public void DropScoreMultyplier()
    {
        scoreMultyplier = scoreBaseMultyplier;
        if (scoreMultyplier > 1)
        {
            ComboText.text = $"{scoreMultyplier}xCombo";
        } else
        {
            ComboText.text = "";
        }
    }

    public void ChangeScoreMultyplier(int amount)
    {
        scoreMultyplier += amount;
        LastComboTime = comboDurationTime;
        if (scoreMultyplier <= scoreBaseMultyplier)
        {
            DropScoreMultyplier();
        }
        else
        {
            ComboText.text = $"{scoreMultyplier}xCombo";

        }
    }

    public void UpdateBallsLeftCounter()
    {
        --ballsLeft;
        ++ballsCounter;
        BallsLeftText.text = $"Осталось клубков: {ballsLeft}";
    }

    public void SetBallsLeftCounter(int newValue)
    {
        ballsLeft = newValue;
        BallsLeftText.text = $"Осталось клубков: {ballsLeft}";
    }

    public void StunAttackPlayer(int fromDirection)
    {
        DropScoreMultyplier();
        LastStunnedTime = stunByAttackDurationTime;
        ANIM.SetTrigger("Stunned");
        IsStunned = true;
        TakeAttackDamageFeedback(fromDirection);
    }

    public void StunTaranPlayer(int fromDirection)
    {
        DropScoreMultyplier();
        LastStunnedTime = stunByTaranDurationTime;
        ANIM.SetTrigger("Stunned");
        IsStunned = true;

        TemparelySlowTimeScale();
        TakeTaranDamageFeedback(fromDirection);
    }
    #endregion

    #region Getters
    public int GetScore()
    {
        return score;
    }

    public int GetScoreMultyplier()
    {
        return scoreMultyplier;
    }

    public int GetCurrentHealth()
    {
        return maxHealth;
    }
    #endregion

    #region SHOW IN UI METHODS
    private void ShowBallsLeft()
    {
        BallsLeftText.text = $"Осталось клубков: {ballsLeft}";
    }
    #endregion

    public void TakeAttackDamageFeedback(int dir)
    {
        Vector2 force = new Vector2(TakeAttackDamageFeedbackForce.x, TakeAttackDamageFeedbackForce.y);
        force.x *= dir; //apply force in opposite direction of enemy

        if (Mathf.Sign(RB.velocity.x) != Mathf.Sign(force.x))
            force.x -= RB.velocity.x;

        if (RB.velocity.y < 0) //checks whether player is falling, if so we subtract the velocity.y (counteracting force of gravity). This ensures the player always reaches our desired jump force or greater
            force.y -= RB.velocity.y;

        //Unlike in the run we want to use the Impulse mode.
        //The default mode will apply are force instantly ignoring masss
        RB.AddForce(force, ForceMode2D.Impulse);
    }

    public void TakeTaranDamageFeedback(int dir)
    {
        Vector2 force = new Vector2(TakeTaranDamageFeedbackForce.x, TakeTaranDamageFeedbackForce.y);
        force.x *= dir; //apply force in opposite direction of enemy

        if (Mathf.Sign(RB.velocity.x) != Mathf.Sign(force.x))
            force.x -= RB.velocity.x;

        if (RB.velocity.y < 0) //checks whether player is falling, if so we subtract the velocity.y (counteracting force of gravity). This ensures the player always reaches our desired jump force or greater
            force.y -= RB.velocity.y;

        //Unlike in the run we want to use the Impulse mode.
        //The default mode will apply are force instantly ignoring masss
        RB.AddForce(force, ForceMode2D.Impulse);
    }

    private void TemparelySlowTimeScale()
    {
        LastTimeSlowed = StunnedSlowTimeDuration;
        Time.timeScale = StunnedSlowTimeScale;
        globalLight.SetDungerGamma();
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1;
        globalLight.ResetGamma();
    }

    private void Die()
    {
        ANIM.SetTrigger("Die");
    }

    public void Destroy()
    {
        gameManager.PlayerDied();
        //gameObject.SetActive(false);
    }
}
