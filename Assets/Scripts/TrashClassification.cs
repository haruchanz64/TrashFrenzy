using System.Collections;
using System.Collections.Generic;
using TrashFrenzy.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
namespace TrashFrenzy.Core
{
    public class TrashClassification : MonoBehaviour
    {
        [SerializeField] private TrashType trashType;
        [SerializeField] private SpriteRenderer trashSprite;
        [SerializeField] private float movementSpeed = 0.5f;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            trashSprite.sprite = TrashSprite;

            float horizontalVelocity = Random.Range(-movementSpeed, movementSpeed);

            rb.velocity = new Vector2(horizontalVelocity, -movementSpeed);
        }

        public TrashType GetTrashType()
        {
            return trashType;
        }
        public string TrashName { get { return trashType.trashName; } }
        public TrashVariant TrashVariant { get { return trashType.trashVariant; } }
        public ToolClass RequiredTool { get { return trashType.requiredTool; } }
        public Sprite TrashSprite { get { return trashType.trashSprite; } }
    }
}