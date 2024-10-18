using System.Collections;
using System.Collections.Generic;
using TrashFrenzy.Mechanics;
using TrashFrenzy.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace TrashFrenzy.Core
{
    public class Health : MonoBehaviour
    {
        [Header("Health Statistics")]
        [SerializeField] private PlayerStats playerStats;

        [SerializeField] private float maxHealth;
        [SerializeField] private float currentHealth;

        public float CurrentHealth
        {
            get
            {
                return currentHealth;
            }
        }

        public float MaxHealth
        {
            get
            {
                return maxHealth;
            }
        }

        [Header("Health - UI")]
        [SerializeField] private Image healthBarImage;
        [SerializeField] private Image healthIcon;
        [SerializeField] private Gradient gradient;

        [Header("Chances")]
        [SerializeField] private int maxChances = 5;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;

            healthBarImage.color = gradient.Evaluate(healthBarImage.fillAmount);
            healthIcon.color = gradient.Evaluate(healthBarImage.fillAmount);
        }

        public void ApplyDamage(float damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        }

        public void Heal(float healAmount)
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }


        private void CheckIfPlayerDead()
        {
            if (currentHealth < 0f)
            {
                Destroy(this);
            }
        }
    }
}
