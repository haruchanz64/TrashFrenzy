using UnityEngine;
using TrashFrenzy.ScriptableObjects;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TrashFrenzy.Core
{
    public class ToolManager : MonoBehaviour
    {
        [Header("Tool Swap")]
        [SerializeField] private ToolType[] toolType;
        private int currentToolIndex = 0;

        [Header("Trash UI")]
        [SerializeField] private Image trashProgression;
        private float trashProgressionCount = 0f;
        [SerializeField] private Image[] trashVariantsIcon;
        [SerializeField] private Image trashConsumeAction;

        // Source: Philippine Solid Waste Management Act of 2000 (Republic Act No. 9003)
        private static readonly Color BiodegradableColor = new Color(0f, 1f, 0f); // Green
        private static readonly Color NonBiodegradableColor = new Color(0f, 0f, 0f); // Black
        private static readonly Color RecyclableColor = new Color(0f, 0.5f, 1f); // Blue

        [Header("References")]
        [SerializeField] private Health health;
        [SerializeField] private Transform weaponTransform;
        [SerializeField] private CircleCollider2D circleCollider;

        private int unlockedTrashVariant = 0; // 0: Biodegradable, 1: Non_Biodegradable, 2: Recyclable

        private void Start()
        {
            UpdateTrashVariantIcons();
            UpdateConsumeActionColor();
        }

        private void Update()
        {
            trashProgression.fillAmount = trashProgressionCount / 100;

            if (trashProgressionCount >= 30f && unlockedTrashVariant == 0)
            {
                unlockedTrashVariant = 1;
                UpdateTrashVariantIcons();
            }
            else if (trashProgressionCount >= 60f && unlockedTrashVariant == 1)
            {
                unlockedTrashVariant = 2;
                UpdateTrashVariantIcons();
            }
        }

        private void UpdateConsumeActionColor()
        {
            switch (toolType[currentToolIndex].toolClass)
            {
                case ToolClass.Biodegradable:
                    trashConsumeAction.color = BiodegradableColor;
                    break;
                case ToolClass.NonBiodegradable:
                    trashConsumeAction.color = NonBiodegradableColor;
                    break;
                case ToolClass.Recyclable:
                    trashConsumeAction.color = RecyclableColor;
                    break;
                default:
                    Debug.LogError("Unhandled ToolClass type");
                    break;
            }
        }

        public void SwapToolLoadout(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                currentToolIndex = (currentToolIndex + 1) % toolType.Length;
            }
            UpdateConsumeActionColor();
        }

        public void ConsumeTrash(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(circleCollider.transform.position, circleCollider.radius);

                foreach (Collider2D hitCollider in hitColliders)
                {
                    TrashClassification hitTrashType = hitCollider.GetComponent<TrashClassification>();

                    if (hitTrashType != null)
                    {
                        if (toolType[currentToolIndex].toolClass == hitTrashType.RequiredTool || unlockedTrashVariant >= (int)hitTrashType.TrashVariant)
                        {
                            trashProgressionCount += 2f;
                            Destroy(hitTrashType.gameObject);
                        }
                        else
                        {
                            health.ApplyDamage(5f);
                            Destroy(hitTrashType.gameObject);
                        }
                    }
                }
            }
        }

        private void UpdateTrashVariantIcons()
        {
            Color unlockedColor = Color.white;
            Color lockedColor = Color.black;

            for (int i = 0; i < trashVariantsIcon.Length; i++)
            {
                if (i <= unlockedTrashVariant)
                {
                    trashVariantsIcon[i].color = unlockedColor;
                }
                else
                {
                    trashVariantsIcon[i].color = lockedColor;
                }
            }
        }
    }
}