using System.Collections;
using System.Collections.Generic;
using Dialogue;
using Minigames;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Rendering.FilterWindow;

public class KenoGame : MinigameBase
{
    // Game
    public KenoBag playerBag;
    public KenoBag opponentBag;
    public int winningNumber;
    private bool canPress = true;
    private bool gameEnd = false;
    
    // UI
    public TextMeshProUGUI welcomeText;
    public TextMeshProUGUI winningNumberText;
    public TextMeshProUGUI coinsInBagText;

    // Visual
    public AnimationClip bagOpenClip;
    public GameObject playerWinningLight;
    public GameObject opponentWinningLight;
    public GameObject playerLosingLight;
    public GameObject opponentLosingLight;
    public GameObject tieGameLight;

    // Audio
    public AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

        winningNumber = Random.Range(1, 11); // Number between 1 - 10
        winningNumberText.text = winningNumber.ToString();

        playerBag.FillBag(10);
        opponentBag.FillBag(10);
        coinsInBagText.text = "Coins Left: " + playerBag.availableNums.Count;

        playerBag.RemoveCoinUI();
        opponentBag.RemoveCoinUI();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerBag.availableNums.Count > 0 && canPress && !gameEnd)
        {
            welcomeText.GetComponent<Animator>().SetTrigger("fadeOut");

            playerBag.DrawCoin();
            opponentBag.DrawCoin();

            int playerCoin = playerBag.currentNum;
            int opponentCoin = opponentBag.currentNum;

            coinsInBagText.text = "Coins Left: " + playerBag.availableNums.Count;

            if (playerCoin == opponentCoin && playerCoin == winningNumber)
            {
                Debug.Log("Tie");
                StartCoroutine(TieSequence());
                gameEnd = true;
            }
            else if (playerCoin == winningNumber)
            {
                Debug.Log("Player Win");
                StartCoroutine(WinSequence());

                gameEnd = true;
            }
            else if (opponentCoin == winningNumber)
            {
                Debug.Log("Begger Win");
                StartCoroutine(LoseSequence());
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

        if (!gameEnd)
        {
            playerBag.CloseBagVisual();
            opponentBag.CloseBagVisual();
            playerBag.RemoveCoinUI();
            opponentBag.RemoveCoinUI();

            canPress = true;
        }     
    }


    #region Game Endings
    IEnumerator TieSequence()
    {
        yield return new WaitForSeconds(bagOpenClip.length);
        tieGameLight.SetActive(true);
        StartCoroutine(ChangeSceneAfterDialogue(new string[2] { "seems like a tie", "next time you wont be so lucky" }, 999));
        audioManager.PlaySFX("CashWin");
    }

    IEnumerator WinSequence()
    {
        yield return new WaitForSeconds(bagOpenClip.length);
        playerWinningLight.SetActive(true);
        opponentLosingLight.SetActive(true);
        StartCoroutine(ChangeSceneAfterDialogue(new string[2] { "ARGGGHGHHHHH", "*You win and take the money before he gets too angry*" }, 4999));
        audioManager.PlaySFX("CashWinBig");
    }
    IEnumerator LoseSequence()
    {
        yield return new WaitForSeconds(bagOpenClip.length);
        playerLosingLight.SetActive(true);
        opponentWinningLight.SetActive(true);
        StartCoroutine(ChangeSceneAfterDialogue(new string[2] {"you snoosze you losze!", "*COUGH COUGH*"}, 0));
    }

    IEnumerator ChangeSceneAfterDialogue(string[] sentences, int moneyAdded)
    {
        yield return StartCoroutine(DialogueManager.Instance.AnimateText(sentences));
        PlayerCash.addCash(moneyAdded);
        if (moneyAdded > 0) audioManager.PlaySFX("CashWin");
        GetComponent<MoveToScene>().GoToScene();
    }

    #endregion
}
