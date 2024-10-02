using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TrashFrenzy.Core.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed = 12f;
        [SerializeField] private float dashForce = 24f;
        
        
        [Header("Components")]
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private Rigidbody2D rb2d;

        private void Awake()
        {
            InitializeComponentsOnAwake();
        }

        private void Update()
        {
            MovePlayer();
            HandleCombat();
        }

        private void LateUpdate()
        {
            HandleDash();
            HandleWeaponSwitch();
        }

        private void InitializeComponentsOnAwake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            inputActionAsset = GetComponent<InputActionAsset>();
        }

        private void MovePlayer()
        {
            Vector2 movementInput = inputActionAsset.FindAction("Move").ReadValue<Vector2>();
            rb2d.velocity = movementInput * movementSpeed;
        }

        private void HandleCombat()
        {

        }

        private void HandleDash()
        {

        }

        private void HandleWeaponSwitch()
        {

        }
    }
}
