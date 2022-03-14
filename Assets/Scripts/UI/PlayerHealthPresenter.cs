using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthPresenter : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] Image healthBarOverlay;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float visibilitySpan = 10f;
    float colorAlpha = 0f;
    float decreaseAmount;

    void Start()
    {
        decreaseAmount = 1f / visibilitySpan;

        playerHealth.onHealthChange += UpdateUI;
        UpdateUI();

        colorAlpha = 0f;
        UpdateUIAlpha();
    }

    IEnumerator DescreaseAlpha()
    {
        while (colorAlpha > 0f)
        {
            Debug.Log("Entrou");
            colorAlpha -= Time.deltaTime;
            UpdateUIAlpha();
            yield return new WaitForEndOfFrame();
        }

    }

    private void UpdateUI()
    {
        colorAlpha = 1f;
        UpdateUIAlpha();

        StopAllCoroutines();
        StartCoroutine(DescreaseAlpha());

        healthBar.fillAmount = (float)playerHealth.GetCurrentHealth() / (float)playerHealth.GetFullHealth();
    }

    void UpdateUIAlpha()
    {
        healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, colorAlpha);
        healthBarOverlay.color = new Color(healthBarOverlay.color.r, healthBarOverlay.color.g, healthBarOverlay.color.b, colorAlpha);
    }
}
