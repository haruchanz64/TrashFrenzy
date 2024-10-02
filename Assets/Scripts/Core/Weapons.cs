/*
 * Weapon.cs
 * 
 * This class is responsible for managing the weapons that the player can use.
 * Includes the weapon types and the current weapon that the player is using.
 * Also the system that handles weapon switching.
 * 
 */
using UnityEngine;
namespace TrashFrenzy.Core.Weapon
{
    public class Weapons : MonoBehaviour
    {
        [Header("Weapons")]
        [SerializeField] private WeaponType[] weapons;
        [SerializeField] private WeaponType currentWeapon;
        [SerializeField] private Transform weaponHolder;
    }
}
