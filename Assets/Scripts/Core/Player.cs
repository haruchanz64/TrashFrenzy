using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TrashFrenzy.Core;
namespace TrashFrenzy.Core
{
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed = 12f;
        [SerializeField] private float dashForce = 24f;


        [Header("Input Actions")]
        [SerializeField] private InputActionReference movementInput;
        [SerializeField] private InputActionReference dashInput;
        [SerializeField] private InputActionReference combatInput;
        [SerializeField] private InputActionReference weaponSwitchInput;

        [Header("COmponents")]
        [SerializeField] private Rigidbody2D rigidbody2D;
        private void Awake()
        {

        }

        public void MovePlayer(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            rigidbody2D.velocity = movementInput * movementSpeed * Time.deltaTime;
        }

        public void ConsumeTrash(InputAction.CallbackContext context)
        {

        }

        public void HandleDash(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                rigidbody2D.AddForce(rigidbody2D.velocity.normalized * dashForce, ForceMode2D.Impulse);
            }
        }

        public void SwitchWeapon(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                Weapon weapon = GetComponent<Weapon>();
                weapon.GetCurrentWeapon();
            }
        }
    }
}