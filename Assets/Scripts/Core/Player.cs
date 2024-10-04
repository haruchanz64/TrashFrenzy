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
        
        
        [Header("Components")]
        [SerializeField] private InputActionReference movementInput;
        [SerializeField] private InputActionReference dashInput;
        [SerializeField] private InputActionReference combatInput;
        [SerializeField] private InputActionReference weaponSwitchInput;

        private void Awake()
        {

        }

        public void MovePlayer(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            GetComponent<Rigidbody2D>().velocity = movementInput * movementSpeed;
        }

        public void ConsumeTrash(InputAction.CallbackContext context)
        {
            // TODO: Implement trash consumption
            Debug.Log("Trash Consumed");
        }
    }
}
