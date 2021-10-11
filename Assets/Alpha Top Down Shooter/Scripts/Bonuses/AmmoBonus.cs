using Alpha.Characters;
using Player;
using UnityEngine;

namespace Alpha.Bonuses
{
    public class AmmoBonus : Bonus
    {
        protected override void AddPoint(GameObject player)
        {
            player.GetComponent<PlayerMovement>().PlayerWeapon.AddAmmo(addPoints);
        }
    }
}