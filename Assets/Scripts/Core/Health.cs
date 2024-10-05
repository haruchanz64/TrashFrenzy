using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrashFrenzy.Core
{
    public class Health : MonoBehaviour
    {
        [Header("Health Statistics")]
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;

        [Header("UI")]
        [SerializeField] private Image healthBarImage;
        [SerializeField] private Gradient gradient;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;

            healthBarImage.color = gradient.Evaluate(healthBarImage.fillAmount);
        }

        public void ApplyDamage(float damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            CheckIfDead();
        }

        public void Heal(float healAmount)
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }

        private void CheckIfDead()
        {
            if (currentHealth <= 0)
            {
                Debug.Log("Player is dead...");
            }
        }
    }
}
