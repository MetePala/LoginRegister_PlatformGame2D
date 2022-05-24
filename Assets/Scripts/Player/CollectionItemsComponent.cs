using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectionItemsComponent : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] Rigidbody2D _playerRigid;
    [SerializeField] GameObject _finishPanel;
    [SerializeField] Text _finishText;
     int _diamond;
    private void Awake()
    {
        _diamond= PlayerPrefs.GetInt("Diamond");
        _text.text = _diamond.ToString();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Dia"))
        {
            _diamond++;
            _text.text = _diamond.ToString();
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("under"))
        {
            _playerRigid.gravityScale = 0.5f;
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            PlayerPrefs.SetInt("level", 2);
            PlayerPrefs.SetInt("Diamond", _diamond);
            SceneManager.LoadScene(3);
        }
        if (col.gameObject.CompareTag("fire"))
        {
            SceneManager.LoadScene(3);
        }
        if (col.gameObject.CompareTag("door"))
        {
            StartCoroutine(finish());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("lion"))
        {
            SceneManager.LoadScene(3);
        }
        if (col.gameObject.CompareTag("frog"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

       
    }
    IEnumerator finish()
    {
        yield return new WaitForSeconds(1f);
        _finishPanel.SetActive(true);
        PlayerPrefs.SetInt("Diamond", _diamond);
        _finishText.text = _diamond.ToString();
        yield return new WaitForSeconds(1.4f);
        Time.timeScale = 0;
    }
}
