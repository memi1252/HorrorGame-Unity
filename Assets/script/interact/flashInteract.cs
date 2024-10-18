using UnityEngine;

public class flashInteract : MonoBehaviour
{
    [SerializeField] public Light Light;
    public static flashInteract Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }


    public void Interact()
    {
        var flash1 = Instantiate(itemManager.Instance.item[0], player.Instance.itemPos.transform, false);
        soundManager.Instance.lightaudio = flash1;
        soundManager.Instance.lightSwithAudioSource = soundManager.Instance.lightaudio.GetComponent<AudioSource>();
        soundManager.Instance.lightSwithAudioSource.resource = soundManager.Instance.lightSwith;
        soundManager.Instance.lightSwithAudioSource.mute =false;
        player.Instance.itemPos.transform.position = flash1.transform.position;
        flash.Instance.pickUpFlash = true;
        Light.gameObject.SetActive(false);
        player.Instance.isFlash = true;
        InventoryUI.Instance.flash = true;
    }
}