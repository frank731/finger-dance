using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int finger = 0; // set 0 if any finger usable
    public float readyTime = 1f;
    public float stayTime = 0.1f;
    public bool active = false;
    public bool started = false;
    [SerializeField] Collider2D circleCollider;
    [SerializeField] TMPro.TextMeshPro numText;

    public virtual void Start()
    {
        if(Random.Range(0, 3) == 0)
        {
            finger = Random.Range(1, 6);
            numText.text = finger.ToString();
        }
        StartCoroutine(EnableCircle());
    }

    public IEnumerator EnableCircle()
    {
        yield return new WaitForSeconds(readyTime);
        circleCollider.enabled = true;
        StartCoroutine(DeleteCircle());
    }

    public IEnumerator DeleteCircle()
    {
        yield return new WaitForSeconds(stayTime);
        if (!started) DestroyNote();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (finger != 0 && collision.GetComponent<Finger>().fingerInd != finger) return;
        GameManager.Instance.UpdateScore(1);
        GameManager.Instance.audioSource.PlayOneShot(GameManager.Instance.hitsound, 0.5f);
        Instantiate(GameManager.Instance.hitParticles, transform.position, transform.rotation);
        DestroyNote();
    }

    public virtual void DestroyNote()
    {
        Destroy(gameObject);
    }
}
