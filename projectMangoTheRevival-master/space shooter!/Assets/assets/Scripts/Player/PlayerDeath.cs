using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    [SerializeField] Material aberationMaterial;
    float shitupTime = 3f;

    CameraShader _cameraShader;
    moveCamera _moveCamera;
    // Start is called before the first frame update
    void Start()
    {
        _cameraShader = Camera.main.GetComponent<CameraShader>();
        _moveCamera = Camera.main.GetComponent<moveCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.transform.tag == "EnemyBullet"){
            // Start the Death Behavior
            //Invoke("startPlaygroundScene", 6f);
            Debug.Log("CALLED");
            StartCoroutine(FuckMyShitUp());
        }
    }

    IEnumerator FuckMyShitUp(){
        _cameraShader.enabled = true;
        aberationMaterial.SetFloat("_OffsetRedY", 0);
        aberationMaterial.SetFloat("_OffsetBlueY", 0);

        Time.timeScale = 0;
        float fuckUpMeasure = 0f;
        float dampVelocity = 0.0f;

        yield return new WaitForSecondsRealtime(1f);
        while(shitupTime > 0){
            shitupTime -= Time.unscaledDeltaTime;

            aberationMaterial.SetFloat("_OffsetRedY", Mathf.Max(0, fuckUpMeasure));
            aberationMaterial.SetFloat("_OffsetBlueY", -Mathf.Max(0, fuckUpMeasure));

            fuckUpMeasure += Time.unscaledDeltaTime / 30f;

            _moveCamera.movementSpeed = Mathf.SmoothDamp(_moveCamera.movementSpeed, 0, ref dampVelocity, 1f, Mathf.Infinity, Time.unscaledDeltaTime);
            yield return null;
        }
        int movesMade = 1;
        while(movesMade < 100){
            if(movesMade % 2 == 0){
                _moveCamera.MoveCamera(new Vector3(-0.25f * movesMade, 0.2f * movesMade, 0f));
            }else{
                _moveCamera.MoveCamera(new Vector3(0.25f * movesMade, -0.2f * movesMade, 0f));
            }
            movesMade++;
            yield return new WaitForSecondsRealtime(2f / (movesMade*5));
        }
         _cameraShader.enabled = false;
         Time.timeScale = 1;
        Fungus.Flowchart.BroadcastFungusMessage("Playground");

    }

    void startPlaygroundScene()
    {
        Debug.Log("called playground scene");
        Fungus.Flowchart.BroadcastFungusMessage("Playground");

    }
}
