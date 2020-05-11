using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Vector3 latterPosition;  
    public Vector3 objectPosition  ;
    public Vector3 teacherPosition  ;
    int    index = 0;


    //public Variables;
    public   List<ModelBundle> myModels;
    public   GameObject groundCube;
    public   GameObject backgroundCube;
    public   AudioSource audioSource;
    private  GameObject latter, obj, teacher;
    private Animator teacherAnimator=null, objectAnimator=null;

    void Start()
    {
        ChangeScenePrefabs();
    }

    public void OnButtonClick()
    {
        ChangeScenePrefabs();
    }

    private void ChangeScenePrefabs()
    {
        if (index >= myModels.Count)
        {
            index = 0;
        }
         
        if (teacher!=null)
        {
            Destroy(teacher);
            Destroy(latter);
            Destroy(obj);
        }
        teacher = Instantiate(myModels[index].teacherAsset,teacherPosition,Quaternion.identity);
        latter = Instantiate(myModels[index].latterAsset, latterPosition, Quaternion.identity);
        obj = Instantiate(myModels[index].objectAsset,objectPosition, Quaternion.identity);

        //animation;
        teacherAnimator = teacher.GetComponent<Animator>();
        
        teacherAnimator.runtimeAnimatorController = Resources.Load(myModels[index].teacherAnimationName) as RuntimeAnimatorController;
        try
        {
            objectAnimator = obj.GetComponent<Animator>();
            objectAnimator.runtimeAnimatorController = Resources.Load(myModels[index].objectAnimationName) as RuntimeAnimatorController;

        }
        catch (System.Exception)
        {

            throw;
        }
         
      
        //check if any desired location provided if yes , then change location
        if (myModels[index].latterPostion!= Vector3.zero)
          latter.transform.localPosition = myModels[index].latterPostion;
        if (myModels[index].objectPostion != Vector3.zero)
            obj.transform.localPosition = myModels[index].objectPostion;
        if (myModels[index].latterPostion != Vector3.zero)
            teacher.transform.localPosition = myModels[index].teacherPostion;

        float scale = myModels[index].objectSize;
        obj.transform.localScale = new Vector3(scale,scale,scale);
        latter.transform.localScale = new Vector3(4f,4f,4f);
        
        //rotating those models and latter and teacher;
        latter.transform.Rotate(new Vector3(0f,-180f,0f));
        obj.transform.Rotate(new Vector3(0f, -180f, 0f));
        teacher.transform.Rotate(new Vector3(0f, -180f, 0f));
       
        //change background texture;
        backgroundCube.GetComponent<Renderer>().material.mainTexture = myModels[index].backgroundCube;
        groundCube.GetComponent<Renderer>().material.mainTexture = myModels[index].groundCube;
 
        // play the current audioClip;
        audioSource.clip = myModels[index].audioClip;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        index++;


    }
    private void ChangePostion(Vector3 desiredPostion)
    {

    }
    private void Update()
    {
 


    }

}
