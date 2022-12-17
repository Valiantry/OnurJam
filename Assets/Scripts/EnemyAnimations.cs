using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;

    private void SaðYürüme()
    {
        animator.SetTrigger("Sað");
    }
    private void SolYürüme()
    {
        animator.SetTrigger("Sol");
    }
    private void AþaðýYürüme()
    {
        animator.SetTrigger("Aþaðý");
    }
    private void YukarýYürüme()
    {
        animator.SetTrigger("Yukarý");
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
