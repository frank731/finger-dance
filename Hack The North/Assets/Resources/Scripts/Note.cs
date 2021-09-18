using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int finger = 0; // set 0 if any finger usable
    public float readyTime = 1f;
    public float stayTime = 0.5f;
    public bool active = false;
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
        if (!active) DestroyNote();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (finger != 0 && collision.GetComponent<Finger>().fingerInd != finger) return;
        GameManager.Instance.UpdateScore(1);
        DestroyNote();
    }

    public virtual void DestroyNote()
    {
        Destroy(gameObject);
    }
}
