using System.Collections;
using System.Collections.Generic;
using TrashFrenzy.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TrashFrenzy.Core
{
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed = 24f;
        [SerializeField] private float dashForce = 48f;
        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float dashCooldown = 1f;

        [Header("Components")]
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private GameManager gameManager;
        private Vector2 movement;
        private bool isDashing;
        private float lastDashTime;

        [Header("Animation Parameters")]
        [SerializeField] private Animator animator;



        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (!isDashing)
            {
                MoveCharacter();
            }
        }

        private void MoveCharacter()
        {
            Vector2 moveVelocity = movement.normalized * movementSpeed;
            rigidbody2D.linearVelocity = new Vector2(moveVelocity.x, moveVelocity.y);
        }

        private void MovePlayer(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector2>();
        }

        private void StopMovement(InputAction.CallbackContext context)
        {
            movement = Vector2.zero;
        }

        private void HandleDash(InputAction.CallbackContext context)
        {
            if (context.performed && Time.time >= lastDashTime + dashCooldown && !isDashing)
            {
                StartCoroutine(Dash());
            }
        }

        private IEnumerator Dash()
        {
            isDashing = true;
            lastDashTime = Time.time;

            Vector2 dashDirection = rigidbody2D.linearVelocity.normalized;
            rigidbody2D.linearVelocity = dashDirection * dashForce;

            yield return new WaitForSeconds(dashDuration);

            isDashing = false;
        }

        private void HandleSizeGrow()
        {

        }
    }
}
