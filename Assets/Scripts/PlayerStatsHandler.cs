using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrashFrenzy.ScriptableObjects;
namespace TrashFrenzy.Core
{
    public class PlayerStatsHandler : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        public float GetHitPoints() { return playerStats.hitPoints;  }

        public float GetMovementSpeed() { return playerStats.movementSpeed; }

        public float GetToxinResistance() {  return playerStats.toxinResistance; }
    }
}