using System.Collections;
using TrashFrenzy.Core;
using TrashFrenzy.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace TrashFrenzy.Mechanics
{
    public class ToxicityMeter : MonoBehaviour
    {
        [Header("Toxic Meter - UI")]
        [SerializeField] private Image toxicMeterFill;

        [Header("Toxicity Meter - Parameters")]
        [SerializeField] private bool isToxicStatusEnabled = true;
        [SerializeField] private float toxicMeterDamage = 0.01f;
        [SerializeField] private float toxicTickInterval = 1.25f;
        [SerializeField] private float toxicMeterFillRate = 0.01f;
        [SerializeField] private float maxToxicity = 1.0f;
        private float currentToxicity = 0f;

        [Header("Health System")]
        [SerializeField] private Health health;

        private Coroutine toxicityCoroutine;

        private void Start()
        {
            toxicityCoroutine = StartCoroutine(FillToxicityMeter());
        }

        private IEnumerator FillToxicityMeter()
        {
            while (currentToxicity < maxToxicity)
            {
                if (isToxicStatusEnabled)
                {
                    currentToxicity += toxicMeterFillRate * Time.deltaTime;
                    toxicMeterFill.fillAmount = currentToxicity;

                    if (currentToxicity >= maxToxicity)
                    {
                        StartCoroutine(ApplyDamageOverTime());
                    }
                }
                yield return null;
            }
        }

        public IEnumerator ApplyDamageOverTime()
        {
            while (currentToxicity >= maxToxicity)
            {
                float scaledDamage = toxicMeterDamage * currentToxicity;

                health.ApplyDamage(scaledDamage);

                yield return new WaitForSeconds(toxicTickInterval);
            }
        }


        public void PickUpAntidote()
        {
            if (toxicityCoroutine != null)
            {
                StopCoroutine(toxicityCoroutine);
            }
            StartCoroutine(FreezeToxicMeter(5f));
            StartCoroutine(ReduceToxicMeter(5f, currentToxicity * 0.8f));
        }

        public IEnumerator FreezeToxicMeter(float seconds)
        {
            isToxicStatusEnabled = false;
            yield return new WaitForSeconds(seconds);
            isToxicStatusEnabled = true;

            toxicityCoroutine = StartCoroutine(FillToxicityMeter());
        }

        public IEnumerator ReduceToxicMeter(float seconds, float reduction)
        {
            yield return new WaitForSeconds(seconds);
            currentToxicity = reduction;
            toxicMeterFill.fillAmount = currentToxicity;
        }
    }
}
