using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpiritCardController : MonoBehaviour {

    [SerializeField] private List<SpiritCardView> spiritCards = new List<SpiritCardView>();

    private void OnEnable() {
        GameEvents.OnDiceRollCompleted += Evaluate;
    }

    private void OnDisable() {
        GameEvents.OnDiceRollCompleted -= Evaluate;
    }

    private void Evaluate(int diceValue) {

        bool cardTriggered = false;

        foreach(SpiritCardView card in spiritCards) {

            if(diceValue == 3 && card.GetCardData().triggerType == DiceTriggerType.ThreeOnDice) {

                cardTriggered = true;
                StartCoroutine(ApplyPointsEffectRoutine(diceValue, card));

            } else if(diceValue == 6 && card.GetCardData().triggerType == DiceTriggerType.SixOnDice) {

                cardTriggered = true;
                StartCoroutine(ApplyMultiplierEffectRoutine(diceValue, card));

            }
        }

        if(!cardTriggered) {
            GameEvents.OnDiceResultProcessed?.Invoke(diceValue);
        }
    }

    private IEnumerator ApplyPointsEffectRoutine(int diceValue, SpiritCardView card) {

        GameEvents.OnSpiritCardActivated?.Invoke(card);

        yield return new WaitForSeconds(0.5f);

        GameCalculator.Instance.AddPoints(diceValue, card.GetCardData().pointsModifier);
    }

    private IEnumerator ApplyMultiplierEffectRoutine(int diceValue, SpiritCardView card) {

        GameEvents.OnSpiritCardActivated?.Invoke(card);

        yield return new WaitForSeconds(0.5f);

        GameCalculator.Instance.SetMultiplier(diceValue, card.GetCardData().multiplierOverride);
    }
}