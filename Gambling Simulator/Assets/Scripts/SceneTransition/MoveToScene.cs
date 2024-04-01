using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public string sceneName;
    public GameObject blackUIScreen;
    public AnimationClip fadeToBlackClip;

    public void GoToScene()
    {
        StartCoroutine(SwitchScene(sceneName));
    }

    IEnumerator SwitchScene(string name)
    {
        blackUIScreen.SetActive(true);
        blackUIScreen.GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(fadeToBlackClip.length);
        SceneManager.LoadScene(name);
    }

}
