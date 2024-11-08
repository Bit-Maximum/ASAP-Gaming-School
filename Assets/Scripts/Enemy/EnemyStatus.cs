using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private AnimetionPatrolEnemy ANIM;
    private AudioManager audioManager;

    [SerializeField] private int score = 1;
    [SerializeField] private int scoreMultyplier = 1;
    [SerializeField] private int maxHealth = 3;

    [SerializeField] private float StunDuration = 1;
    public bool IsStuned;

    private float LastStunedTime;

    private void Awake()
    {
        ANIM = GetComponent<AnimetionPatrolEnemy>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        LastStunedTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (IsStuned && LastStunedTime < 0)
        {
            IsStuned = false;
            ANIM.TrigerStunEndedTriger();
        }
    }

    #region Setters
    public void TakeDamage(int amount)
    {
        audioManager.PlaySFX(audioManager.EnHurt);
        ANIM.TrigerHurtAnimation();
        LastStunedTime = StunDuration;
        IsStuned = true;

        maxHealth -= amount;
        if (maxHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        maxHealth += amount;
    }
    #endregion

    #region Getters
    public int GetScore()
    {
        return score * scoreMultyplier;
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
    #endregion

    private void Die()
    {
        ANIM.TrigerDieTriger();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
