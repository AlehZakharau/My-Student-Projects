using Characters.Player;
using UnityEngine;

namespace Alpha.Bonuses
{
    public class HealthBonus : Bonus
    {
        protected override void AddPoint(GameObject player)
        {
            player.GetComponent<PlayerHealth>().AddHealth(addPoints);
        }
    }
}