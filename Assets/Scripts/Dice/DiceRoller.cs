using UnityEngine;
using System.Collections;

public class DiceRoller : MonoBehaviour {

    [Header("Roll Settings")]
    [SerializeField] private float upwardForce = 6f;
    [SerializeField] private float randomForce = 2f;
    [SerializeField] private float torqueForce = 10f;

    [Header("Faces")]
    [SerializeField] private Transform[] faces;

    private Rigidbody rb;
    private bool isRolling;
    private Vector3 startPosition;

    void Awake() {

        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    public void RollDice() {

        if(isRolling) {
            return;
        }

        StartCoroutine(RollRoutine());
    }

    private IEnumerator RollRoutine() {

        isRolling = true;

        ResetDice();
        rb.WakeUp();

        ApplyRollForce();

        yield return new WaitUntil(() => rb.IsSleeping());

        int result = GetTopFaceValue();

        Debug.Log($"Dice Result: {result}");

        GameEvents.OnDiceRollCompleted?.Invoke(result);

        yield return new WaitForSeconds(0.5f);

        ResetDice();

        isRolling = false;
    }

    private void ResetDice() {

        transform.position = startPosition;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void ApplyRollForce() {

        Vector3 randomDir = new Vector3(Random.Range(-randomForce, randomForce), upwardForce, Random.Range(-randomForce, randomForce));

        rb.AddForce(randomDir, ForceMode.Impulse);

        rb.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);
    }

    private int GetTopFaceValue() {

        float maxDot = -1f;
        int faceIndex = 0;

        for(int i = 0; i < faces.Length; i++) {

            float dot = Vector3.Dot(faces[i].forward, Vector3.up);

            if(dot > maxDot) {
                maxDot = dot;
                faceIndex = i;
            }
        }

        return faceIndex + 1;
    }
}