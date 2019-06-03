//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using GameClass;
//
//
//
//public class StepCheck : MonoBehaviour {
//
//
//    public GetMessage StepMessage;
//    public bool IsStart;
//    
//
//
//    private void Start()
//    {
//        string A = StepMessage.MySelf.ToString();
//        TiggerList.GetTiggerList.AddChild(A, StepMessage);
//        if(IsStart)
//        {
//            Invoke("SetMySelf", 2.0f);
//        }
//    }
//
//
//    private bool ErrorGo;
//    public void SetMySelf(ref int Nub)
//    {
//        StepMessage.StepValue = true;
//        if (CheckError())
//        {
//            Debug.Log("停止操作");
//            //foreach (Object child in StepMessage.DisEableAction)
//            //{
//                
//            //}
//            // TiggerList.GetTiggerList.ScorePlease();
//           
//            Nub = ErrorGo?Nub:-1;
//            Debug.Log("AA" + Nub);
//        }
//        else
//        {
//            StepMessage.StepValue = true;
//
//        }
//
//        TiggerList.GetTiggerList.ChangeScore(StepMessage.StepAddScore);
//    }
//
//
//    public bool CheckError()
//    {
//     
//        List<ErrorMessage> SaveTagaLL = new List<ErrorMessage>();
//        SaveTagaLL = StepMessage.CheckValue;
//
//        Dictionary<string, GetMessage> GetSaveStep = new Dictionary<string, GetMessage>();
//        GetSaveStep = TiggerList.GetTiggerList.SaveStep;
//        bool GetBool=false;
//        
//        foreach (ErrorMessage child in SaveTagaLL)
//        {
//          
//            GetMessage SaveSM = null;
//            bool IsHave=  GetSaveStep.TryGetValue(child.SaveTag.ToString(), out SaveSM);
//            if (IsHave)
//            {
//                Debug.Log(child.SaveTag.ToString());
//                if (!SaveSM.StepValue)
//                {
//                    SaveSM.ShowError.Invoke();
//                   // Debug.Log(child.ShowText);                
//                    TiggerList.GetTiggerList.AddStepMessage("曲臂登高车",StepMessage.StepName,child.SaveTag.ToString(), child.ShowText);
//                    Debug.Log(child.SaveMode);
//                    if (child.SaveMode == TrigMode.CantAction)
//                    {
//                        GetBool = true;
//                        ErrorGo = false;
//                    }
//                    if (child.SaveMode == TrigMode.CanAction)
//                    {
//                        GetBool = true;
//                        ErrorGo = true;
//                    }
//                    TiggerList.GetTiggerList.ChangeScore(child.DisScore);
//                    break;
//                }
//   
//            }
//            else
//            {
//                Debug.Log("添加的异常操作没有获取到！");
//            }
//        }
//        if(!GetBool)
//        TiggerList.GetTiggerList.AddStepMessage("曲臂登高车", StepMessage.StepName);
//        return GetBool;
//    }
//
//}
