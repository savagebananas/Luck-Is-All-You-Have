using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KenoBag : MonoBehaviour
{
    public List<int> availableNums = new List<int>();
    private int currentNum;

    private Animator animator;

    public TextMeshProUGUI coinText;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Draws Coin from bag by removing it and returning the number drawn
    /// </summary>
    /// <returns></returns>
    public int DrawCoin()
    {
        // Draw number and remove it from bag
        int indexToRemove = Random.Range(0, availableNums.Count);
        currentNum = availableNums[indexToRemove];
        availableNums.Remove(indexToRemove);

        return currentNum;
    }

    /// <summary>
    /// Fills bag with one of each coin/number
    /// </summary>
    /// <param name="maxNum"> number of coins in bag (inclusive) </param>
    public void FillBag(int maxNum)
    {
        for (int i = 1; i <= maxNum; i++)
        {
            availableNums.Add(i);
        }
    }

    /// <summary>
    /// Clears Coin Bag
    /// </summary>
    public void ClearBag()
    {
        availableNums.Clear();
    }

    public void OpenBagVisual()
    {
        animator.SetBool("isOpen", true);
    }

    public void CloseBagVisual()
    {
        animator.SetBool("isOpen", false);
    }

    public void UpdateCoinUI()
    {
        coinText.text = currentNum.ToString();
    }

    public void RemoveCoinUI()
    {
        coinText.text = "";
    }
}
