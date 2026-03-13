using UnityEngine;
using TMPro;
using System.Collections;

public class UIEquationView : MonoBehaviour {

    [Header("UI References")]
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text multiplierText;
    [SerializeField] private TMP_Text totalText;

    [Header("Animation Settings")]
    [SerializeField] private float popScale = 1.5f;
    [SerializeField] private float animationDuration = 0.3f;

    private void OnEnable() {
        GameEvents.OnEquationUpdated += UpdateEquation;
    }

    private void OnDisable() {
        GameEvents.OnEquationUpdated -= UpdateEquation;
    }

    private void UpdateEquation(int points, float multiplier, float total) {

        StartCoroutine(UpdateRoutine(points, multiplier, total));
    }

    private IEnumerator UpdateRoutine(int points, float multiplier, float total) {

        yield return AnimateText(pointsText, points);
        yield return AnimateText(multiplierText, multiplier);
        yield return AnimateText(totalText, total);
    }

    private IEnumerator AnimateText(TMP_Text text, float value) {

        text.text = value.ToString();

        Vector3 originalScale = text.transform.localScale;
        Vector3 targetScale = originalScale * popScale;

        float timer = 0f;

        while(timer < animationDuration) {

            timer += Time.deltaTime;
            text.transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / animationDuration);
            yield return null;
        }

        timer = 0f;

        while(timer < animationDuration) {

            timer += Time.deltaTime;
            text.transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / animationDuration);
            yield return null;
        }

        yield return null;

        text.transform.localScale = originalScale;
    }
}