using UnityEngine;
using System.Collections;

public class SpiritCardView : MonoBehaviour {

    [SerializeField] private SpiritCardData cardData;
    [SerializeField] private float scaleDuration;
    [SerializeField] private float scaleMultiplier;

    public SpiritCardData GetCardData() {
        return cardData;
    }

    private void OnEnable() {
        GameEvents.OnSpiritCardActivated += Activate;
    }

    private void OnDisable() {
        GameEvents.OnSpiritCardActivated -= Activate;
    }

    private void Activate(SpiritCardView card) {

        if(card.GetCardData() != cardData) {
            return;
        }

        StartCoroutine(ActivationEffect());
    }

    private IEnumerator ActivationEffect() {

        Vector3 start = transform.localScale;
        Vector3 big = start * scaleMultiplier;

        float t = 0;

        while(t < scaleDuration) {

            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(start, big, t / scaleDuration);
            yield return null;
        }

        t = 0;

        while(t < scaleDuration) {

            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(big, start, t / scaleDuration);
            yield return null;
        }
    }
}