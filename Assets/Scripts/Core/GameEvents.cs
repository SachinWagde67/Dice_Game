using UnityEngine;
using System;
using System.Collections;

public static class GameEvents {

    public static Action<int> OnDiceRollCompleted;
    public static Action<int> OnDiceResultProcessed;
    public static Action<int, float, float> OnEquationUpdated;
    public static Action<SpiritCardView> OnSpiritCardActivated;
}