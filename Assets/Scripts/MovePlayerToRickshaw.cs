using UnityEngine;

public class MovePlayerToRickshaw : MonoBehaviour
{

    public float moveSpeed = 2f;
    public Transform Player;
    private bool reachedRickshaw = false;
    private Transform rickshaw;
    void Start()
    {
        rickshaw = GameObject.FindGameObjectWithTag("Rickshaw").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedRickshaw)
        {
            transform.position = Vector3.MoveTowards(transform.position, rickshaw.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, rickshaw.position) < 0.2f)
            {
                reachedRickshaw = true;
                Player.SetParent(rickshaw);
                StartCoroutine(StartFlying());
            }
        }


    }
    
    System.Collections.IEnumerator StartFlying()
    {
        rickshaw.GetComponent<RickshawFly>().RickshawStartFlying();
        yield return null; 
    }
}
