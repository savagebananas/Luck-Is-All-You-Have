using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SlotMachine : MonoBehaviour
{
    public Image[] slotReels; // Assign via Inspector
    public Sprite[] slotSymbols; // Assign via Inspector
    private bool isSpinning = false;
    private float spinDuration = 2.0f; // Duration of each reel spin
    private int tries = 10;
    public const int spinCost = 100;
    public TextMeshProUGUI welcome;
    public TextMeshProUGUI jackpot;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI attempts;
    void Start()
    {
        welcome.text = "Press space to play, you have 10 attempts!";
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning && tries!=0) {
            welcome.text = "";
            jackpot.text = "";
            StartCoroutine(SpinReels());
            tries--;
        }
    }


    private IEnumerator SpinReels()
    {
        if(isSpinning)
            yield break; // Prevent multiple spins at the same time

        PlayerCash.addCash(-spinCost);
        isSpinning = true;

        for (int i = 0; i < slotReels.Length; i++)
        {
            StartCoroutine(SpinReel(slotReels[i]));
            yield return new WaitForSeconds(0.2f); // Stagger the start of each reel spin
        }

        yield return new WaitForSeconds(spinDuration); // Wait for the last reel to stop

        isSpinning = false;
        attempts.text = "Attempts left:" + tries.ToString();
        if (tries == 0)
        {
            gameOver.text = "Game over! Thanks for playing!";
        }
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
                PlayerCash.addCash(7000);
                jackpot.text = "Jackpot!!";
            }
            if (s1 == horseShoe) {
                PlayerCash.addCash(5000);
                jackpot.text = "Three horshoes!!";
            } else {
                PlayerCash.addCash(3000);
                jackpot.text = "Three fruits!!";
            }
            
        }
    }
}