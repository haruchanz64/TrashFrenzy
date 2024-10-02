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
        [SerializeField] private InputActionAsset inputActions;
        [SerializeField] private Rigidbody2D rb2d;
    }
}
