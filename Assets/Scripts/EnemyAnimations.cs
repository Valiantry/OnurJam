using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;

    private void Sa�Y�r�me()
    {
        animator.SetTrigger("Sa�");
    }
    private void SolY�r�me()
    {
        animator.SetTrigger("Sol");
    }
    private void A�a��Y�r�me()
    {
        animator.SetTrigger("A�a��");
    }
    private void Yukar�Y�r�me()
    {
        animator.SetTrigger("Yukar�");
    }

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<Enemy>().dir == new Vector2(2,2))
        //{

        //}
    }
}
