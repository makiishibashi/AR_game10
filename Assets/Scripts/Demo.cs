using UnityEngine ;

public class Demo : MonoBehaviour {

   [SerializeField] Timer timer ;


    //private void Start () {
    public void StartCountdown()
    { 
       timer
      .SetDuration (60)
      .OnEnd (() => Debug.Log ("Timer 1 ended"))
      .Begin () ;
    }

}
