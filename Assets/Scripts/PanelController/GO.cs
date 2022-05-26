using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour
{
    MoveController _moveController;

    [SerializeField] Animator _animator;
    [SerializeField] GameObject _goPanel, _victoryPanel;
    [SerializeField] GameObject _vmCam;
    
    


    private void Awake()
    {
        _moveController = new MoveController();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            
            _animator.Play("Dead");
            
            StartCoroutine(Deads());
            
        }
        if (collision.gameObject.CompareTag("Chest"))
        {
            
            _animator.Play("Victory");
            StartCoroutine(Victory());
        }
    }

    IEnumerator Deads()
    {
        
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        _goPanel.SetActive(true);
        
    }

    IEnumerator Victory()
    {
        
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        _victoryPanel.SetActive(true);
    }
}
