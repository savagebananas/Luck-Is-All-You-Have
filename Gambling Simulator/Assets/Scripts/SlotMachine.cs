using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public Image[] slotReels; // Assign via Inspector
    public Sprite[] slotSymbols; // Assign via Inspector
    public Button spinButton; // Assign via Inspector
    private bool isSpinning = false;
    private float spinDuration = 2.0f; // Duration of each reel spin

    public const int spinCost = 10;


    void Start()
    {
        spinButton.onClick.AddListener(() => StartCoroutine(SpinReels()));
    }

    private IEnumerator SpinReels()
    {
        if(isSpinning)
            yield break; // Prevent multiple spins at the same time

        PlayerCash.addCash(-spinCost);
        isSpinning = true;
        spinButton.interactable = false; // Disable button during spin

        for (int i = 0; i < slotReels.Length; i++)
        {
            StartCoroutine(SpinReel(slotReels[i]));
            yield return new WaitForSeconds(0.2f); // Stagger the start of each reel spin
        }

        yield return new WaitForSeconds(spinDuration); // Wait for the last reel to stop

        spinButton.interactable = true; // Re-enable the button after spinning
        isSpinning = false;

        CheckWinCondition();
    }

    private IEnumerator SpinReel(Image reel)
    {
        float endTime = Time.time + spinDuration;

        while (Time.time < endTime)
        {
            int randomSymbolIndex = Random.Range(0, slotSymbols.Length);
            reel.sprite = slotSymbols[randomSymbolIndex];
            yield return new WaitForSeconds(0.1f); // Time between symbol changes to simulate spinning
        }
    }

    private void CheckWinCondition()
    {

        Sprite horseShoe = slotSymbols[4];
        Sprite seven = slotSymbols[5];
        // Simple win condition check: if all symbols are the same
        if (slotReels[0].sprite == slotReels[1].sprite && slotReels[1].sprite == slotReels[2].sprite)
        {
            Sprite s1 = slotReels[0].sprite;
            //Give Payouts based on symbol
            if (s1 == seven) {
                PlayerCash.addCash(700);
            }
            if (s1 == horseShoe) {
                PlayerCash.addCash(500);
            } else {
                PlayerCash.addCash(300);
            }
            
        }
    }
}