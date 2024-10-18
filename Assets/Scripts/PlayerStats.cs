using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrashFrenzy.ScriptableObjects
{
    [CreateAssetMenu(menuName ="Stats")]
    public class PlayerStats : ScriptableObject
    {
        public float hitPoints;
        public float movementSpeed;
        public float toxinResistance;
    }
}