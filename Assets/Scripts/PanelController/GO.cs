using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour
{
    

    [SerializeField] Animator _animator;
    [SerializeField] GameObject _goPanel;
    
    
    


   

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            
            _animator.Play("Dead");
            
            StartCoroutine(Deads());
            
        }
        
    }

    IEnumerator Deads()
    {
        
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        _goPanel.SetActive(true);
        
    }

    
}
