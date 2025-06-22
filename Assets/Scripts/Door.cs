using UnityEngine;

public class Door : TempleObject
{
    private bool isOpen = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator no encontrado en Door");
        }
    }

    public override void Interact()
    {
        Debug.Log("Interact llamado en Door");
        if (!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("Open");
        }
    }
}
