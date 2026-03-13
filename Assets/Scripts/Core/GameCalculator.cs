using UnityEngine;
using System.Collections;

public class GameCalculator : MonoBehaviour {

    public static GameCalculator Instance { get; private set; }

    private int points;
    private float multiplier;
    private float total;

    private float defaultMultiplier = 10f;

    private void Awake() {

        if(Instance != null && Instance != this) {

            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void OnEnable() {
        GameEvents.OnDiceResultProcessed += HandleDiceResult;
    }

    private void OnDisable() {
        GameEvents.OnDiceResultProcessed -= HandleDiceResult;
    }

    private void HandleDiceResult(int diceValue) {

        points = diceValue;
        multiplier = defaultMultiplier;

        CalculateTotal();
    }

    public void AddPoints(int diceValue, int value) {

        Debug.Log($"Points added - {value}");

        points = diceValue + value;
        multiplier = defaultMultiplier;

        CalculateTotal();
    }

    public void SetMultiplier(int diceValue, float value) {

        Debug.Log($"Multiplier added - {value}");

        points = diceValue;
        multiplier = value;

        CalculateTotal();
    }

    private void CalculateTotal() {

        total = points * multiplier;

        Debug.Log($"Total: {total}");

        GameEvents.OnEquationUpdated?.Invoke(points, multiplier, total);
    }
}