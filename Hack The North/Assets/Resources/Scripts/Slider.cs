using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    public class Slider : Note
    {
        public PathFollower pathFollower;
        public override void Start()
        {
            base.Start();
            pathFollower.pathCreator.path.finishedPath.AddListener(ReachedEnd);
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            if (finger != 0 && collision.GetComponent<Finger>().fingerInd != finger) return;
            active = true;
            if(!started) GameManager.Instance.audioSource.PlayOneShot(GameManager.Instance.hitsound, 0.5f);
            pathFollower.start = true;
            started = true;
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (finger != 0 && collision.GetComponent<Finger>().fingerInd != finger) return;
            active = false;
        }

        public void ReachedEnd()
        {
            if (active)
            {
                GameManager.Instance.UpdateScore(3);
                Instantiate(GameManager.Instance.hitParticles, transform.position, transform.rotation);
                GameManager.Instance.audioSource.PlayOneShot(GameManager.Instance.hitsound, 0.5f);
            }
            DestroyNote();
        }

        public override void DestroyNote()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
