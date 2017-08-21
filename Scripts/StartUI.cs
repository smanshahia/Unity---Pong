using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {

    public Button play;
    public Button quit;
    public AudioSource playAudio;
    public AudioSource quitAudio;
    public Text ready;
    float count;

    private void Awake()
    {
        play.onClick.AddListener(Play);
        quit.onClick.AddListener(Quit);
        ready.gameObject.SetActive(false);
        Time.timeScale = 1;
        count = 15;
        StopAllCoroutines();
    }

    private void  Play()
    {
        play.interactable = false;
        StartCoroutine("PlayWait");
    }

    IEnumerator PlayWait()
    {

        playAudio.Play();
        ready.gameObject.SetActive(true);
        while(count <= 135)
        {
            var rect = ready.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(ready.GetComponent<RectTransform>().rect.width, count);
            count += 15;
            yield return new WaitForSeconds(0.6f);
        }

        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        quit.interactable = false;
        StartCoroutine("QuitWait");
    }

    IEnumerator QuitWait()
    {
        quitAudio.Play();
        yield return new WaitForSeconds(1.4f);
        Application.Quit();
    }
}
