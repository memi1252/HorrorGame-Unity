using System.Collections;
using System.Diagnostics.SymbolStore;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour
{
    
    [SerializeField] private GameObject playerDiePos;
    [SerializeField] private GameObject monsterGameObject;

    public Transform target;
    public Material dieMaterial;
    private Animator animator;
    public bool die =true;
    public bool monsterdie = false;
    private bool dieing = false;

    private NavMeshAgent nmAgent;
    private Rigidbody rigidbody;
    
    public static monster Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        animator = monsterGameObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
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

        if (offeringUI.Instance.incross && offeringUI.Instance.ineraser && offeringUI.Instance.inbaseBall
            && offeringUI.Instance.innail && offeringUI.Instance.inmirror)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            if (!monsterdie)
            {
                target = gameObject.transform;
                player.Instance.move = false;
                animator.SetBool("monserAlterDIe", true);
                offeringUI.Instance.Hide();
                player.Instance.gameObject.GetComponent<LookAtCamera>().enabled = true;
                LookAtCamera.Instance.monster1 = LookAtCamera.Instance.monster2;
                transform.GetComponent<SphereCollider>().enabled = false;
                monsterGameObject.transform.GetChild(0).AddComponent<BoxCollider>();
                monsterGameObject.transform.GetChild(1).AddComponent<BoxCollider>();
                monsterGameObject.transform.GetChild(2).AddComponent<BoxCollider>();
                monsterGameObject.transform.GetChild(3).AddComponent<BoxCollider>();
                monsterGameObject.transform.GetChild(4).AddComponent<BoxCollider>();
                monsterGameObject.transform.GetChild(5).AddComponent<BoxCollider>();
                monsterGameObject.transform.GetChild(5).GetChild(0).AddComponent<BoxCollider>();
                monsterGameObject.transform.GetChild(5).GetChild(1).AddComponent<BoxCollider>();
                StartCoroutine(animatorOut());
                StartCoroutine(changeMaterail());
                StartCoroutine(diediedie());
                StartCoroutine(sdsd());
                monsterdie = true;
            }
        }
        
    }

    private IEnumerator diediedie()
    {
        yield return new WaitForSeconds(2.5f);
        animator.enabled = false;
       
    }
    
    private IEnumerator animatorOut()
    {
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("monserAlterDIe", false);
    }

    private IEnumerator changeMaterail()
    {
        yield return new WaitForSeconds(2f);
        if (!dieing)
        {
            monsterGameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(3).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(4).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(5).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(5).GetChild(0).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(5).GetChild(1).GetComponent<MeshRenderer>().material = dieMaterial;
            monsterGameObject.transform.GetChild(0).AddComponent<Rigidbody>();
            monsterGameObject.transform.GetChild(1).AddComponent<Rigidbody>();
            monsterGameObject.transform.GetChild(2).AddComponent<Rigidbody>();
            monsterGameObject.transform.GetChild(3).AddComponent<Rigidbody>();
            monsterGameObject.transform.GetChild(4).AddComponent<Rigidbody>();
            monsterGameObject.transform.GetChild(5).AddComponent<Rigidbody>();
            monsterGameObject.transform.GetChild(0).SetParent(null);
            monsterGameObject.transform.GetChild(0).SetParent(null);
            monsterGameObject.transform.GetChild(0).SetParent(null);
            monsterGameObject.transform.GetChild(0).SetParent(null);
            monsterGameObject.transform.GetChild(0).SetParent(null);
            monsterGameObject.transform.GetChild(0).SetParent(null);
            dieing = true;
        }
    }

    private IEnumerator sdsd()
    {
        yield return new WaitForSeconds(3.5f);
        player.Instance.gameObject.GetComponent<LookAtCamera>().enabled = false;
        RotateToMouse.Instance.anglepause = true;
        RotateToMouse.Instance.pause = true;
        player.Instance.ui = false;
        player.Instance.move = true;
        storyMonsterDie.Instance.ss();
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