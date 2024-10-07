using System.Collections;
using System.Collections.Generic;
using TrashFrenzy.Mechanics;
using UnityEngine;
using UnityEngine.UI;

namespace TrashFrenzy.Core
{
    public class Health : MonoBehaviour
    {
        [Header("Health Statistics")]
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;

        [Header("Health - UI")]
        [SerializeField] private Image healthBarImage;
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

        
    }
}
