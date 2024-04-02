using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SlotMachine : MonoBehaviour
{
    public Image[] slotReels; // Assign via Inspector
    public Sprite[] slotSymbols; // Assign via Inspector
    private bool isSpinning = false;
    private float spinDuration = 1.0f; // Duration of each reel spin
    public const int spinCost = 250;
    public GameObject welcome;

    private int timesLost = 0;

    // Audio
    public AudioManager audioManager;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning) {
            welcome.GetComponent<Animator>().SetTrigger("FadeOut");
            StartCoroutine(SpinReels());
        }
    }


    private IEnumerator SpinReels()
    {
        if(isSpinning)
            yield break; // Prevent multiple spins at the same time

        PlayerCash.addCash(-spinCost);
        isSpinning = true;

        int randomTile = Random.Range(0, slotSymbols.Length);

        for (int i = 0; i < slotReels.Length; i++)
        {
            StartCoroutine(SpinReel(slotReels[i], randomTile));
            yield return new WaitForSeconds(.3f); // Stagger the start of each reel spin
        }

        yield return new WaitForSeconds(spinDuration); // Wait for the last reel to stop

        CheckWinCondition();
    }

    private IEnumerator SpinReel(Image reel, int randomTile)
    {
        float endTime = Time.time + spinDuration;

        while (Time.time < endTime)
        {
            int randomSymbolIndex = Random.Range(0, slotSymbols.Length);
            reel.sprite = slotSymbols[randomSymbolIndex];
            yield return new WaitForSeconds(0.05f); // Time between symbol changes to simulate spinning
        }

        // Increasing chance to win
        // More losing = more chance to win
        int randomChance = Random.Range(1, 101);
        if (randomChance <= timesLost) // Win Event 
        {
            Debug.Log("BiG NIGGA GAY");
            reel.sprite = slotSymbols[randomTile];
        }
    }

    private void CheckWinCondition()
    {

        Sprite horseShoe = slotSymbols[4];
        Sprite seven = slotSymbols[0];

        // Simple win condition check: if all symbols are the same
        if (slotReels[0].sprite == slotReels[1].sprite && slotReels[1].sprite == slotReels[2].sprite)
        {
            Sprite s1 = slotReels[0].sprite;
            // jackpot
            if (s1 == seven)
            {
                audioManager.PlaySFX("Slot Jackpot");
                Debug.Log("Jackpot");
                StartCoroutine(AddCash(3f, 25000));

            }

            // 3 horseshoe
            else if (s1 == horseShoe)
            {
                audioManager.PlaySFX("Slot Win");
                Debug.Log("3 Horseshoe");
                StartCoroutine(AddCash(1.5f, 5000));
            }

            // 3 fruit
            else
            {
                audioManager.PlaySFX("Slot Win");
                Debug.Log("3 fruit");
                StartCoroutine(AddCash(1.5f, 1000));
            }

            timesLost = 0;
        }
        else
        {
            timesLost++;
            isSpinning = false;
        }
    }

    IEnumerator AddCash(float seconds, int money)
    {
        yield return new WaitForSeconds(seconds);
        PlayerCash.addCash(money);
        audioManager.PlaySFX("CashWin");
        isSpinning = false;
    }
}