using UnityEngine;
using UnityEngine.InputSystem;
namespace TrashFrenzy.Core.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] private WeaponType[] weapons;
        [SerializeField] private WeaponType currentWeapon;
        [SerializeField] private Transform weaponHolder;

        [Header("Weapon System")]
        [SerializeField] private float weaponSwitchDelay = 0.5f;

        [Header("Components")]
        [SerializeField] private InputActionAsset inputActionAsset;
    }
}
