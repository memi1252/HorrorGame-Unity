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
    
    public GameObject eraserObject = null;
    public GameObject crossObject= null;
    public GameObject baseBallObject= null;
    public GameObject nailObject= null;
    public GameObject mirrorObject= null;
    
    public bool eraser;
    public bool cross;
    public bool baseBall;
    public bool nail;
    public bool mirror;

    public bool full=false;
    
    public bool ineraser;
    public bool incross;
    public bool inbaseBall;
    public bool innail;
    public bool inmirror;
    
    
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
            incross = false;
            full = false;
        });
        eraserButton.onClick.AddListener(() =>
        {
            eraserButton.gameObject.SetActive(false);
            eraserInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.eraser = true;
            ineraser = false;
            full = false;
        });
        baseBallButton.onClick.AddListener(() =>
        {
            baseBallButton.gameObject.SetActive(false);
            baseBallInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.baseBall = true;
            inbaseBall = false;
            full = false;
        });
        nailButton.onClick.AddListener(() =>
        {
            nailButton.gameObject.SetActive(false);
            nailInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.nail = true;
            innail = false;
            full = false;
        });
        mirrorButton.onClick.AddListener(() =>
        {
            mirrorButton.gameObject.SetActive(false);
            mirrorInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.mirror = true;
            inmirror = false;
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
        offeringInventory();

        if (Input.GetKeyDown(KeyCode.E))
        {
            offeringUI.Instance.Hide();
            RotateToMouse.Instance.anglepause = true;
            RotateToMouse.Instance.pause = true;
            player.Instance.ui = false;
            player.Instance.move = true;
        }
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

    private void offeringInventory()
    {
        if (player.Instance.alternumber == 1)
        {
            if (flashButton.gameObject.activeSelf)
            {
                eraserObject = flashButton.gameObject;
            }else if (eraserButton.gameObject.activeSelf)
            {
                eraserObject = eraserButton.gameObject;
                ineraser = true;
            }else if (crossButton.gameObject.activeSelf)
            {
                eraserObject = crossButton.gameObject;
            }else if (baseBallButton.gameObject.activeSelf)
            {
                eraserObject = baseBallButton.gameObject;
            }else if (nailButton.gameObject.activeSelf)
            {
                eraserObject = nailButton.gameObject;
            }else if (mirrorButton.gameObject.activeSelf)
            {
                mirrorObject  = mirrorButton.gameObject;
            }else {
                if (eraserObject != null)
                {
                    if (eraserObject == eraserButton.gameObject)
                    {
                        eraserButton.gameObject.SetActive(true);
                        eraserObject = null;
                        if (InventoryUI.Instance.eraser)
                        {
                            eraserButton.gameObject.SetActive(false);
                            ineraser = false;
                        }
                    }
                    else if (eraserObject == crossButton.gameObject)
                    {
                        crossButton.gameObject.SetActive(true);
                        eraserObject = null;
                        
                        if (InventoryUI.Instance.cross)
                        {
                            crossButton.gameObject.SetActive(false);
                        }
                    }
                    else if (eraserObject == baseBallButton.gameObject)
                    {
                        baseBallButton.gameObject.SetActive(true);
                        eraserObject = null;
                        if (InventoryUI.Instance.baseBall)
                        {
                            baseBallButton.gameObject.SetActive(false);
                        }
                    }
                    else if (eraserObject == nailButton.gameObject)
                    {
                        nailButton.gameObject.SetActive(true);
                        eraserObject = null;
                        if (InventoryUI.Instance.nail)
                        {
                            nailButton.gameObject.SetActive(false);
                        }
                    }
                    else if (eraserObject == flashButton.gameObject)
                    {
                        flashButton.gameObject.SetActive(true);
                        eraserObject = null;
                        if (InventoryUI.Instance.flash)
                        {
                            flashButton.gameObject.SetActive(false);
                        }
                    }
                    else if (eraserObject == mirrorButton.gameObject)
                    {
                        mirrorButton.gameObject.SetActive(true);
                        eraserObject = null;
                        if (InventoryUI.Instance.mirror)
                        {
                            mirrorButton.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    eraserObject = null;
                }
            }
            
            if (gameObject.activeSelf && eraserObject != null) {
                eraserObject.SetActive(true);
                if(eraserObject != null)
                    full = true;
            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
            {
                eraserButton.gameObject.SetActive(false);
                crossButton.gameObject.SetActive(false);
                baseBallButton.gameObject.SetActive(false); 
                nailButton.gameObject.SetActive(false);
                mirrorButton.gameObject.SetActive(false);
                full = false;
            }
        }
        else if (player.Instance.alternumber == 2)
        {
            if (flashButton.gameObject.activeSelf)
            {
                crossObject = flashButton.gameObject;
            }else if (eraserButton.gameObject.activeSelf)
            {
                crossObject = eraserButton.gameObject;
            }else if (crossButton.gameObject.activeSelf)
            {
                crossObject = crossButton.gameObject;
                incross = true;
            }else if (baseBallButton.gameObject.activeSelf)
            {
                crossObject = baseBallButton.gameObject;
            }else if (nailButton.gameObject.activeSelf)
            {
                crossObject = nailButton.gameObject;
            }else if (mirrorButton.gameObject.activeSelf)
            {
                mirrorObject  = mirrorButton.gameObject;
            }else {
                if (crossObject != null)
                {
                    if (crossObject == eraserButton.gameObject)
                    {
                        eraserButton.gameObject.SetActive(true);
                        crossObject = null;
                        if (InventoryUI.Instance.eraser)
                        {
                            eraserButton.gameObject.SetActive(false);
                        }
                    }
                    else if (crossObject == crossButton.gameObject)
                    {
                        crossButton.gameObject.SetActive(true);
                        crossObject = null;
                        if (InventoryUI.Instance.cross)
                        {
                            crossButton.gameObject.SetActive(false);
                            incross = false;
                        }
                    }
                    else if (crossObject == baseBallButton.gameObject)
                    {
                        baseBallButton.gameObject.SetActive(true);
                        crossObject = null;
                        if (InventoryUI.Instance.baseBall)
                        {
                            baseBallButton.gameObject.SetActive(false);
                        }
                    }
                    else if (crossObject == nailButton.gameObject)
                    {
                        nailButton.gameObject.SetActive(true);
                        crossObject = null;
                        if (InventoryUI.Instance.nail)
                        {
                            nailButton.gameObject.SetActive(false);
                        }
                    }
                    else if (crossObject == flashButton.gameObject)
                    {
                        flashButton.gameObject.SetActive(true);
                        crossObject = null;
                        if (InventoryUI.Instance.flash)
                        {
                            flashButton.gameObject.SetActive(false);
                        }
                    }
                    else if (crossObject == mirrorButton.gameObject)
                    {
                        mirrorButton.gameObject.SetActive(true);
                        crossObject = null;
                        if (InventoryUI.Instance.mirror)
                        {
                            mirrorButton.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    crossObject = null;
                }
            }
            
            if (gameObject.activeSelf && crossObject != null) {
                crossObject.SetActive(true);
                if(crossObject != null)
                    full = true;
            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
            {
                eraserButton.gameObject.SetActive(false);
                crossButton.gameObject.SetActive(false);
                baseBallButton.gameObject.SetActive(false); 
                nailButton.gameObject.SetActive(false);
                mirrorButton.gameObject.SetActive(false);
                full = false;
            }
        }
        else if (player.Instance.alternumber == 3)
        {
            if (flashButton.gameObject.activeSelf)
            {
                baseBallObject = flashButton.gameObject;
            }else if (eraserButton.gameObject.activeSelf)
            {
                baseBallObject = eraserButton.gameObject;
            }else if (crossButton.gameObject.activeSelf)
            {
                baseBallObject = crossButton.gameObject;
            }else if (baseBallButton.gameObject.activeSelf)
            {
                baseBallObject = baseBallButton.gameObject;
                inbaseBall = true;
            }else if (nailButton.gameObject.activeSelf)
            {
                baseBallObject = nailButton.gameObject;
            }else if (mirrorButton.gameObject.activeSelf)
            {
                mirrorObject  = mirrorButton.gameObject;
            }else {
                if (baseBallObject != null)
                {
                    if (baseBallObject == eraserButton.gameObject)
                    {
                        eraserButton.gameObject.SetActive(true);
                        baseBallObject = null;
                        if (InventoryUI.Instance.eraser)
                        {
                            eraserButton.gameObject.SetActive(false);
                        }
                    }
                    else if (baseBallObject == crossButton.gameObject)
                    {
                        crossButton.gameObject.SetActive(true);
                        baseBallObject = null;
                        if (InventoryUI.Instance.cross)
                        {
                            crossButton.gameObject.SetActive(false);
                        }
                    }
                    else if (baseBallObject == baseBallButton.gameObject)
                    {
                        baseBallButton.gameObject.SetActive(true);
                        baseBallObject = null;
                        if (InventoryUI.Instance.baseBall)
                        {
                            baseBallButton.gameObject.SetActive(false);
                            inbaseBall = false;
                        }
                    }
                    else if (baseBallObject == nailButton.gameObject)
                    {
                        nailButton.gameObject.SetActive(true);
                        baseBallObject = null;
                        if (InventoryUI.Instance.nail)
                        {
                            nailButton.gameObject.SetActive(false);
                        }
                    }
                    else if (baseBallObject == flashButton.gameObject)
                    {
                        flashButton.gameObject.SetActive(true);
                        baseBallObject = null;
                        if (InventoryUI.Instance.flash)
                        {
                            flashButton.gameObject.SetActive(false);
                        }
                    }
                    else if (baseBallObject == mirrorButton.gameObject)
                    {
                        mirrorButton.gameObject.SetActive(true);
                        baseBallObject = null;
                        if (InventoryUI.Instance.mirror)
                        {
                            mirrorButton.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    baseBallObject = null;
                }
            }
            
            if (gameObject.activeSelf && baseBallObject != null) {
                baseBallObject.SetActive(true);
                if(baseBallObject != null)
                    full = true;
            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
            {
                eraserButton.gameObject.SetActive(false);
                crossButton.gameObject.SetActive(false);
                baseBallButton.gameObject.SetActive(false); 
                nailButton.gameObject.SetActive(false);
                mirrorButton.gameObject.SetActive(false);
                full = false;
            }
        }
        else if (player.Instance.alternumber == 4)
        {
            if (flashButton.gameObject.activeSelf)
            {
                nailObject = flashButton.gameObject;
            }else if (eraserButton.gameObject.activeSelf)
            {
                nailObject = eraserButton.gameObject;
            }else if (crossButton.gameObject.activeSelf)
            {
                nailObject = crossButton.gameObject;
            }else if (baseBallButton.gameObject.activeSelf)
            {
                nailObject = baseBallButton.gameObject;
            }else if (nailButton.gameObject.activeSelf)
            {
                nailObject = nailButton.gameObject;
                innail = true;
            }else if (mirrorButton.gameObject.activeSelf)
            {
                mirrorObject  = mirrorButton.gameObject;
            }else {
                if (nailObject != null)
                {
                    if (nailObject == eraserButton.gameObject)
                    {
                        eraserButton.gameObject.SetActive(true);
                        nailObject = null;
                        if (InventoryUI.Instance.eraser)
                        {
                            eraserButton.gameObject.SetActive(false);
                        }
                    }
                    else if (nailObject == crossButton.gameObject)
                    {
                        crossButton.gameObject.SetActive(true);
                        nailObject = null;
                        if (InventoryUI.Instance.cross)
                        {
                            crossButton.gameObject.SetActive(false);
                        }
                    }
                    else if (nailObject == baseBallButton.gameObject)
                    {
                        baseBallButton.gameObject.SetActive(true);
                        nailObject = null;
                        if (InventoryUI.Instance.baseBall)
                        {
                            baseBallButton.gameObject.SetActive(false);
                        }
                    }
                    else if (nailObject == nailButton.gameObject)
                    {
                        nailButton.gameObject.SetActive(true);
                        nailObject= null;
                        if (InventoryUI.Instance.nail)
                        {
                            nailButton.gameObject.SetActive(false);
                            innail = false;
                        }
                    }
                    else if (nailObject == flashButton.gameObject)
                    {
                        flashButton.gameObject.SetActive(true);
                        nailObject = null;
                        if (InventoryUI.Instance.flash)
                        {
                            flashButton.gameObject.SetActive(false);
                        }
                    }
                    else if (nailObject == mirrorButton.gameObject)
                    {
                        mirrorButton.gameObject.SetActive(true);
                        nailObject = null;
                        if (InventoryUI.Instance.mirror)
                        {
                            mirrorButton.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    nailObject = null;
                }
            }
            
            if (gameObject.activeSelf &&nailObject != null) {
                nailObject.SetActive(true);
                if(nailObject != null)
                    full = true;
            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
            {
                eraserButton.gameObject.SetActive(false);
                crossButton.gameObject.SetActive(false);
                baseBallButton.gameObject.SetActive(false); 
                nailButton.gameObject.SetActive(false);
                mirrorButton.gameObject.SetActive(false);
                full = false;
            }
        }
        else if (player.Instance.alternumber == 5)
        {
            if (flashButton.gameObject.activeSelf)
            {
                mirrorObject = flashButton.gameObject;
            }else if (eraserButton.gameObject.activeSelf)
            {
                mirrorObject = eraserButton.gameObject;
            }else if (crossButton.gameObject.activeSelf)
            {
                mirrorObject = crossButton.gameObject;
            }else if (baseBallButton.gameObject.activeSelf)
            {
                mirrorObject = baseBallButton.gameObject;
            }else if (nailButton.gameObject.activeSelf)
            {
                mirrorObject = nailButton.gameObject;
            }else if (mirrorButton.gameObject.activeSelf)
            {
                mirrorObject  = mirrorButton.gameObject;
                inmirror = true;
            }else {
                if (mirrorObject != null)
                {
                    if (mirrorObject == eraserButton.gameObject)
                    {
                        eraserButton.gameObject.SetActive(true);
                        mirrorObject = null;
                        if (InventoryUI.Instance.eraser)
                        {
                            eraserButton.gameObject.SetActive(false);
                        }
                    }
                    else if (mirrorObject == crossButton.gameObject)
                    {
                        crossButton.gameObject.SetActive(true);
                        mirrorObject = null;
                        if (InventoryUI.Instance.cross)
                        {
                            crossButton.gameObject.SetActive(false);
                        }
                    }
                    else if (mirrorObject == baseBallButton.gameObject)
                    {
                        baseBallButton.gameObject.SetActive(true);
                        mirrorObject = null;
                        if (InventoryUI.Instance.baseBall)
                        {
                            baseBallButton.gameObject.SetActive(false);
                        }
                    }
                    else if (mirrorObject == nailButton.gameObject)
                    {
                        nailButton.gameObject.SetActive(true);
                        mirrorObject= null;
                        if (InventoryUI.Instance.nail)
                        {
                            nailButton.gameObject.SetActive(false);
                        }
                    }
                    else if (mirrorObject == flashButton.gameObject)
                    {
                        flashButton.gameObject.SetActive(true);
                        mirrorObject = null;
                        if (InventoryUI.Instance.flash)
                        {
                            flashButton.gameObject.SetActive(false);
                        }
                    }
                    else if (mirrorObject == mirrorButton.gameObject)
                    {
                        mirrorButton.gameObject.SetActive(true);
                        mirrorObject = null;
                        if (InventoryUI.Instance.mirror)
                        {
                            mirrorButton.gameObject.SetActive(false);
                            inmirror = false;
                        }
                    }
                }
                else
                {
                    mirrorObject = null;
                }
            }
            
            if (gameObject.activeSelf &&mirrorObject != null) {
                mirrorObject.SetActive(true);
                if(mirrorObject != null)
                    full = true;
            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
            {
                eraserButton.gameObject.SetActive(false);
                crossButton.gameObject.SetActive(false);
                baseBallButton.gameObject.SetActive(false); 
                nailButton.gameObject.SetActive(false);
                mirrorButton.gameObject.SetActive(false);
                full = false;
            }
        }
    }

    public void Show()
    {
        player.Instance.ui = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        eraserButton.gameObject.SetActive(false);
        crossButton.gameObject.SetActive(false);
        baseBallButton.gameObject.SetActive(false); 
        nailButton.gameObject.SetActive(false);
        mirrorButton.gameObject.SetActive(false);
        full = false;
        gameObject.SetActive(false);
    }
}