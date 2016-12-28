using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DamageTaken
{
    public int PlayerDamageTaken { get; set; }
    public bool PlayerCriticalStrike { get; set; }
    public int EnemyDamageTaken { get; set; }
    public bool EnemyCriticalStrike { get; set; }

    public DamageTaken(int playerDamageTaken, bool playerCriticalStrike,
        int enemyDamageTaken, bool enemyCriticalStrike)
    {
        PlayerDamageTaken = playerDamageTaken;
        PlayerCriticalStrike = playerCriticalStrike;
        EnemyDamageTaken = enemyDamageTaken;
        EnemyCriticalStrike = enemyCriticalStrike;
    }
}
