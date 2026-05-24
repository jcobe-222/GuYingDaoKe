using System;
public static class GameEvents
{
    public static event Action onEnemyKilled;

    public static void EnemyKilled()
    {
        onEnemyKilled?.Invoke();
    }
}