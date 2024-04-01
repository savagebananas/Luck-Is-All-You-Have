using System.Collections;
using System.Collections.Generic;
using Minigames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KenoGame : MinigameBase
{
    // Game
    public KenoBag playerBag;
    public KenoBag opponentBag;
    public int winningNumber;
    public int potNum;
    public int attempts;
    private bool canPress = true;
    private bool gameEnd = false;
    
    // UI
    public TextMeshProUGUI welcomeText;
    public TextMeshProUGUI winningNumberText;
    public TextMeshProUGUI coinsInBagText;

    // Visual
    public AnimationClip bagOpenClip;

    void Start()
    {
        winningNumber = Random.Range(1, 21); // Number between 1 - 20
        winningNumberText.text = winningNumber.ToString();

        playerBag.FillBag(20);
        opponentBag.FillBag(20);
        coinsInBagText.text = "Coins Left: " + playerBag.availableNums.Count;

        playerBag.RemoveCoinUI();
        opponentBag.RemoveCoinUI();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerBag.availableNums.Count > 0 && canPress && !gameEnd)
        {
            welcomeText.GetComponent<Animator>().SetTrigger("fadeOut");

            int playerCoin = playerBag.DrawCoin();
            int opponentCoin = opponentBag.DrawCoin();

            coinsInBagText.text = "Coins Left: " + playerBag.availableNums.Count;

            if (playerCoin == opponentCoin && playerCoin == winningNumber)
            {
                Debug.Log("Tie");
                gameEnd = true;
            }
            else if (playerCoin == winningNumber)
            {
                Debug.Log("Player Win");
                gameEnd = true;
            }
            else if (opponentCoin == winningNumber)
            {
                Debug.Log("Begger Win");
                gameEnd = true;
            }

            // Bag Aniamtion
            playerBag.OpenBagVisual();
            opponentBag.OpenBagVisual();


            // Cooldown till next press
            StartCoroutine(canPressCooldown());
            StartCoroutine(DisplayCoinNum());
        }
    }

    IEnumerator DisplayCoinNum()
    {
        yield return new WaitForSeconds(bagOpenClip.length);

        playerBag.UpdateCoinUI();
        opponentBag.UpdateCoinUI();
    }

    IEnumerator canPressCooldown()
    {
        canPress = false;

        yield return new WaitForSeconds(bagOpenClip.length + 1);

        playerBag.CloseBagVisual();
        opponentBag.CloseBagVisual();
        playerBag.RemoveCoinUI();
        opponentBag.RemoveCoinUI();

        canPress = true;
    }
}
