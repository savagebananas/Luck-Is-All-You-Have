using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public Image[] slotReels; // Assign via Inspector
    public Sprite[] slotSymbols; // Assign via Inspector
    public Button spinButton; // Assign via Inspector

    void Start()
    {
        spinButton.onClick.AddListener(() => StartCoroutine(SpinReels()));
    }

    private IEnumerator SpinReels()
    {
        spinButton.interactable = false; // Disable button during spin

        for (int i = 0; i < slotReels.Length; i++)
        {
            // This loop will simulate spinning each reel.
            int randomSymbolIndex = Random.Range(0, slotSymbols.Length);
            slotReels[i].sprite = slotSymbols[randomSymbolIndex];

            // Simulate the reel spin delay.
            yield return new WaitForSeconds(0.5f);
        }

        spinButton.interactable = true; // Re-enable the button after spinning

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        // This is a simple win condition check: if all symbols are the same.
        if (slotReels[0].sprite == slotReels[1].sprite && slotReels[1].sprite == slotReels[2].sprite)
        {
            Debug.Log("You Win!");
        }
        else
        {
            Debug.Log("Try Again.");
        }
    }
}