using UnityEngine;
using UnityEngine.UI;

public class boxUI : MonoBehaviour
{
    [SerializeField] private Button crossBoxButton;
    [SerializeField] private Button flashBoxButton;
    [SerializeField] private Button eraserBoxButton;
    [SerializeField] private Button baseBallBoxButton;
    [SerializeField] public Button crossInventoryBoxButton;
    [SerializeField] public Button flashInventoryBoxButton;
    [SerializeField] public Button eraserInventoryBoxButton;
    [SerializeField] public Button baseBallInventoryBoxButton;
    public static boxUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        crossBoxButton.onClick.AddListener(() =>
        {
            crossBoxButton.gameObject.SetActive(false);
            crossInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.cross = true;
        });
        crossInventoryBoxButton.onClick.AddListener(() =>
        {
            crossBoxButton.gameObject.SetActive(true);
            crossInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.cross = false;
        });
        flashBoxButton.onClick.AddListener(() =>
        {
            flashBoxButton.gameObject.SetActive(false);
            flashInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.flash = true;
        });
        flashInventoryBoxButton.onClick.AddListener(() =>
        {
            flashBoxButton.gameObject.SetActive(true);
            flashInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.flash = false;
        });
        eraserBoxButton.onClick.AddListener(() =>
        {
            eraserBoxButton.gameObject.SetActive(false);
            eraserInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.eraser = true;
        });
        eraserInventoryBoxButton.onClick.AddListener(() =>
        {
            eraserBoxButton.gameObject.SetActive(true);
            eraserInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.eraser = false;
        });
        baseBallBoxButton.onClick.AddListener(() =>
        {
            baseBallBoxButton.gameObject.SetActive(false);
            baseBallInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.baseBall = true;
        });
        baseBallInventoryBoxButton.onClick.AddListener(() =>
        {
            baseBallBoxButton.gameObject.SetActive(true);
            baseBallInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.baseBall = false;
        });
        Hide();
        player.Instance.ui = false;
    }


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
            pauseUI.Instance.Hide();
        }

        if (InventoryUI.Instance.flash)
        {
            flashInventoryBoxButton.gameObject.SetActive(true);
            flash.Instance.gameObject.SetActive(true);
        }
        else
        {
            flashInventoryBoxButton.gameObject.SetActive(false);
            flash.Instance.gameObject.SetActive(false);
        }

        if (InventoryUI.Instance.eraser) eraserInventoryBoxButton.gameObject.SetActive(true);
    }

    public void Show()
    {
        player.Instance.h = 0;
        player.Instance.v = 0;
        player.Instance.ui = true;
        StoryLineUI.Instance.Hide();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}