using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Button rollButton;
    [SerializeField] private DiceRoller diceRoller;

    private void Awake() {

        rollButton.onClick.AddListener(RollDice);
    }

    private void RollDice() {

        if(diceRoller != null) {
            diceRoller.RollDice();
        }
    }
}
