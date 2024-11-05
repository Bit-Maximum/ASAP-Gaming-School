using UnityEngine;

internal class Gems : MonoBehaviour
{
    [SerializeField] private int score = 5;

    // Создадим на пункт ниже
    private LevelManager levelManager;

    // Функция для установки менеджера
    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            // Обновим счет
            levelManager.UpdateScore(score);
            // Отключим текущий обьект, чтобы нельзя было еще раз собрать очки.
            gameObject.SetActive(false);
        }
    }
}