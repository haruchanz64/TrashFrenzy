using UnityEngine;
using UnityEngine.InputSystem;
namespace TrashFrenzy.Core
{
    public class Weapon : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] private WeaponType[] weapons;
        [SerializeField] private WeaponType currentWeapon;
        [SerializeField] private Transform weaponHolder;

        [Header("Weapon System")]
        [SerializeField] private float weaponSwitchDelay = 0.5f;
        [SerializeField] private bool canSwitchWeapon = true;
        [SerializeField] private int currentWeaponIndex = 0;
        [Header("Components")]
        [SerializeField] private InputActionAsset inputActionAsset;

        public void GetCurrentWeapon()
        {
            
        }
    }
}
