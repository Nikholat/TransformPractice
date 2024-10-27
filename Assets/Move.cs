using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private bool isGo;
    [SerializeField] private Transform[] runers; 
    [SerializeField] private Transform miniMen;
    private float passDistance = 0.3f; 
    private int currentRunnerIndex = 0; 

    private void Update()
    {
        if (runers.Length > 0 && isGo)
        {
            LookWay();

            PotatoMove();
        }
        UpdateMiniMenPosition();
    }

    private void PotatoMove()
    {
        Vector3 targetPosition = runers[GetNextRunnerIndex()].position - 
        (runers[GetNextRunnerIndex()].forward * passDistance);
    
        runers[currentRunnerIndex].position = Vector3.MoveTowards(runers[currentRunnerIndex].position, 
        targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(runers[currentRunnerIndex].position, targetPosition) < 0.1f)
            {
                TransferMiniMen();

                currentRunnerIndex++;
               
                PotatoArrayCheck();
            }
    }

    private void LookWay()
    {
        miniMen.LookAt(runers[GetNextRunnerIndex()]);
        runers[currentRunnerIndex].LookAt(runers[GetNextRunnerIndex()]);
    }

    private void PotatoArrayCheck()
    {
        if (currentRunnerIndex >= runers.Length)
        {
            currentRunnerIndex = 0; 
        }
    }

    private void TransferMiniMen()
    {
        miniMen.SetParent(runers[currentRunnerIndex]);
        miniMen.localPosition = new Vector3(0.5f, 1.0f, 0); 
    }

    private void UpdateMiniMenPosition()
    {
        if (miniMen != null)
        {
            miniMen.position = runers[currentRunnerIndex].position + new Vector3(0, 0.8f, 0); 
        }
    }
    private int GetNextRunnerIndex()
    {
        return (currentRunnerIndex + 1) % runers.Length;
    }

}