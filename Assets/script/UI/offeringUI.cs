using UnityEngine;
using UnityEngine.UI;

public class offeringUI : MonoBehaviour
{
    [SerializeField] public Button crossInventoryBoxButton;
    [SerializeField] public Button eraserInventoryBoxButton;
    [SerializeField] public Button baseBallInventoryBoxButton;
    [SerializeField] public Button nailInventoryBoxButton;
    [SerializeField] public Button mirrorInventoryBoxButton;
    [SerializeField] public Button flashInventoryBoxButton;
    [SerializeField] public Button crossButton;
    [SerializeField] public Button eraserButton;
    [SerializeField] public Button baseBallButton;
    [SerializeField] public Button nailButton;
    [SerializeField] public Button mirrorButton;
    [SerializeField] public Button flashButton;
    [SerializeField] Image flashXImage;
    [SerializeField] Image crossXImage;
    [SerializeField] Image eraserXImage;
    [SerializeField] Image baseBallXImage;
    [SerializeField] Image nailXImage;
    [SerializeField] Image mirrorXImage;

    public bool eraser;
    public bool cross;
    public bool baseBall;
    public bool nail;
    public bool mirror;

    public bool full=false;
    
    public static offeringUI Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        Hide();
        flashInventoryBoxButton.onClick.AddListener(() =>
        {
            flashInventoryBoxButton.gameObject.SetActive(false);
            flashButton.gameObject.SetActive(true);
            InventoryUI.Instance.flash = false;
            if (full)
            {
                flashButton.gameObject.SetActive(false);
                flashInventoryBoxButton.gameObject.SetActive(true);
                InventoryUI.Instance.flash = true;
            }
            full = true;
        });
        crossInventoryBoxButton.onClick.AddListener(() =>
        {
            crossInventoryBoxButton.gameObject.SetActive(false);
            crossButton.gameObject.SetActive(true);
            InventoryUI.Instance.cross = false;
            if (full)
            {
                crossButton.gameObject.SetActive(false);
                crossInventoryBoxButton.gameObject.SetActive(true);
                InventoryUI.Instance.cross = true;
            }
            full = true;
        });
        eraserInventoryBoxButton.onClick.AddListener(() =>
        {
            eraserInventoryBoxButton.gameObject.SetActive(false);
            eraserButton.gameObject.SetActive(true);
            InventoryUI.Instance.eraser = false;
            if (full)
            {
                eraserButton.gameObject.SetActive(false);
                eraserInventoryBoxButton.gameObject.SetActive(true);
                InventoryUI.Instance.eraser = true;
            }
            full = true;
        });
        baseBallInventoryBoxButton.onClick.AddListener(() =>
        { 
            baseBallInventoryBoxButton.gameObject.SetActive(false);
            baseBallButton.gameObject.SetActive(true);
            InventoryUI.Instance.baseBall = false;
            if (full)
            {
                baseBallButton.gameObject.SetActive(false);
                baseBallInventoryBoxButton.gameObject.SetActive(true);
                InventoryUI.Instance.baseBall = true;
            }
            full = true;
        });
        nailInventoryBoxButton.onClick.AddListener(() =>
        {
            nailInventoryBoxButton.gameObject.SetActive(false);
            nailButton.gameObject.SetActive(true);
            InventoryUI.Instance.nail = false;
            if (full)
            {
                nailButton.gameObject.SetActive(false);
                nailInventoryBoxButton.gameObject.SetActive(true);
                InventoryUI.Instance.nail = true;
            }
            full = true;
        });
        mirrorInventoryBoxButton.onClick.AddListener(() =>
        { 
            mirrorInventoryBoxButton.gameObject.SetActive(false);
            mirrorButton.gameObject.SetActive(true);
            InventoryUI.Instance.mirror = false; 
            if (full)
            {
                mirrorButton.gameObject.SetActive(false);
                mirrorInventoryBoxButton.gameObject.SetActive(true);
                InventoryUI.Instance.mirror = true;
            }
            full = true;
        });
        flashButton.onClick.AddListener(() =>
        {
            flashButton.gameObject.SetActive(false);
            flashInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.flash = true;
            full = false;
        });
        crossButton.onClick.AddListener(() =>
        {
            crossButton.gameObject.SetActive(false);
            crossInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.cross = true;
            full = false;
        });
        eraserButton.onClick.AddListener(() =>
        {
            eraserButton.gameObject.SetActive(false);
            eraserInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.eraser = true;
            full = false;
        });
        baseBallButton.onClick.AddListener(() =>
        {
            baseBallButton.gameObject.SetActive(false);
            baseBallInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.baseBall = true;
            full = false;
        });
        nailButton.onClick.AddListener(() =>
        {
            nailButton.gameObject.SetActive(false);
            nailInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.nail = true;
            full = false;
        });
        mirrorButton.onClick.AddListener(() =>
        {
            mirrorButton.gameObject.SetActive(false);
            mirrorInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.mirror = true;
            full = false;
        });
    }

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v = 0;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
            player.Instance.ui = false;
            pauseUI.Instance.Hide();
        }
    
        if (InventoryUI.Instance.flash) flashInventoryBoxButton.gameObject.SetActive(true);
        if (InventoryUI.Instance.eraser) eraserInventoryBoxButton.gameObject.SetActive(true);
        if (InventoryUI.Instance.cross) crossInventoryBoxButton.gameObject.SetActive(true);
        if (InventoryUI.Instance.baseBall) baseBallInventoryBoxButton.gameObject.SetActive(true);
        if (InventoryUI.Instance.nail) nailInventoryBoxButton.gameObject.SetActive(true);
        if (InventoryUI.Instance.mirror) mirrorInventoryBoxButton.gameObject.SetActive(true);
        no();
        soundManager.Instance.walkAudioSource.Stop();
        soundManager.Instance.runAudioSource.Stop();
    }

    private void no()
    {
        if (eraser)
        {
            if (crossButton.gameObject.activeSelf || baseBallButton.gameObject.activeSelf
                                                  || nailButton.gameObject.activeSelf
                                                  || mirrorButton.gameObject.activeSelf
                                                  || flashButton.gameObject.activeSelf) {
                flashXImage.gameObject.SetActive(true);
                crossXImage.gameObject.SetActive(true);
                baseBallXImage.gameObject.SetActive(true);
                nailXImage.gameObject.SetActive(true);
                mirrorXImage.gameObject.SetActive(true);
            }
            eraserXImage.gameObject.SetActive(false);
        }else if (cross)
        {
            if(eraserButton.gameObject.activeSelf || baseBallButton.gameObject.activeSelf
                                                  || nailButton.gameObject.activeSelf
                                                  || mirrorButton.gameObject.activeSelf
                                                  || flashButton.gameObject.activeSelf) {
                flashXImage.gameObject.SetActive(true);
                eraserXImage.gameObject.SetActive(true);
                baseBallXImage.gameObject.SetActive(true);
                nailXImage.gameObject.SetActive(true);
                mirrorXImage.gameObject.SetActive(true);
            }
            crossXImage.gameObject.SetActive(false);
        }
        else if (baseBall)
        {
            if(crossButton.gameObject.activeSelf || eraserButton.gameObject.activeSelf
                                                  || nailButton.gameObject.activeSelf
                                                  || mirrorButton.gameObject.activeSelf
                                                  || flashButton.gameObject.activeSelf) {
                flashXImage.gameObject.SetActive(true);
                crossXImage.gameObject.SetActive(true);
                eraserXImage.gameObject.SetActive(true);
                nailXImage.gameObject.SetActive(true);
                mirrorXImage.gameObject.SetActive(true);
            }
            baseBallXImage.gameObject.SetActive(false);
        }
        else if (nail)
        {
            if(crossButton.gameObject.activeSelf || baseBallButton.gameObject.activeSelf
                                                  || eraserButton.gameObject.activeSelf
                                                  || mirrorButton.gameObject.activeSelf
                                                  || flashButton.gameObject.activeSelf) {
                flashXImage.gameObject.SetActive(true);
                crossXImage.gameObject.SetActive(true);
                baseBallXImage.gameObject.SetActive(true);
                eraserXImage.gameObject.SetActive(true);
                mirrorXImage.gameObject.SetActive(true);
            }
            nailXImage.gameObject.SetActive(false);
        }
        else if (mirror)
        {
            if(crossButton.gameObject.activeSelf || baseBallButton.gameObject.activeSelf
                                                  || nailButton.gameObject.activeSelf
                                                  || eraserButton.gameObject.activeSelf
                                                  || flashButton.gameObject.activeSelf) {
                flashXImage.gameObject.SetActive(true);
                crossXImage.gameObject.SetActive(true);
                baseBallXImage.gameObject.SetActive(true);
                nailXImage.gameObject.SetActive(true);
                eraserXImage.gameObject.SetActive(true);
            }
            mirrorXImage.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        player.Instance.ui = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}