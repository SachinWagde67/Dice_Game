using UnityEngine;

public class DiceTester : MonoBehaviour {

    [SerializeField] private DiceRoller dice;

    void Update() {

        if(Input.GetKeyDown(KeyCode.Space)) {
            dice.RollDice();
        }
    }
}