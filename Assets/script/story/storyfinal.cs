using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storyfinal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
            blackUI.Instance.Show();
            soundManager.Instance.audioSource.Stop();
            soundManager.Instance.walkAudioSource.Stop();
            soundManager.Instance.runAudioSource.Stop();
            StartCoroutine(finalSecen());
        }
    }
    

    IEnumerator finalSecen()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("finalScene");
    }
}
