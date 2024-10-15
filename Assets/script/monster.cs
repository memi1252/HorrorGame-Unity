using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour
{
    [SerializeField] private GameObject playerDiePos;

    public Transform target;
    private Animator animator;
    private bool die;

    private NavMeshAgent nmAgent;
    public static monster Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (die)
        {
        }
        else
        {
            if (altarIN.Instance.altar)
                nmAgent.SetDestination(target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.Instance.move = false;
            RotateToMouse.Instance.anglepause = false;
            RotateToMouse.Instance.pause = false;
            playerDiePos.SetActive(true);
            die = true;
            other.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            RotateToMouse.Instance.eulerAngleX = 0;
            RotateToMouse.Instance.eulerAngleY = 180;
            player.Instance.die = true;
            Debug.Log("die");
            Destroy(gameObject);
        }
    }
}