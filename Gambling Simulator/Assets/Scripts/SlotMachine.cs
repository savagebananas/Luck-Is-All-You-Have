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
    public const int spinCost = 500;
    public GameObject welcome;

    private int timesLost = 0;

    // Audio
    public AudioManager audioManager;

    void Update() { 
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning) {
            if (PlayerCash.getCash()>=spinCost) {
                welcome.GetComponent<Animator>().SetTrigger("FadeOut");
                StartCoroutine(SpinReels());
            } else {
                
            }
        }
    }


    private IEnumerator SpinReels()
    {
        if(isSpinning)
            yield break; // Prevent multiple spins at the same time

        PlayerCash.addCash(-spinCost);
        isSpinning = true;

        // Increasing chance to win
        // More losing = more chance to win
        int randomChance = Random.Range(1, 51);
        int randomTile = Random.Range(1, slotSymbols.Length); // Random Tile for win event (not including jackpot)

        // Win Event 
        if (randomChance <= timesLost) 
        {
            for (int i = 0; i < slotReels.Length; i++)
            {
                StartCoroutine(SpinReel(slotReels[i], randomTile, true));
                yield return new WaitForSeconds(.3f); // Stagger the start of each reel spin
            }
        }
        // Normal Event
        else
        {
            for (int i = 0; i < slotReels.Length; i++)
            {

                StartCoroutine(SpinReel(slotReels[i], randomTile, false));
                yield return new WaitForSeconds(.3f); // Stagger the start of each reel spin
            }
        }



        yield return new WaitForSeconds(spinDuration); // Wait for the last reel to stop

        CheckWinCondition();
    }

    private IEnumerator SpinReel(Image reel, int randomTile, bool winEvent)
    {
        audioManager.PlaySFX("SlotSpin");


        float endTime = Time.time + spinDuration;
        
        while (Time.time < endTime)
        {
            int randomSymbolIndex = Random.Range(0, slotSymbols.Length);
            reel.sprite = slotSymbols[randomSymbolIndex];
            yield return new WaitForSeconds(0.05f); // Time between symbol changes to simulate spinning
        }

        if (winEvent)
        {
            Debug.Log("Win Event Slot: " + randomTile);
            reel.sprite = slotSymbols[randomTile];
        }

        audioManager.PlaySFX("Slot Reels Stopping");

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