using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleDebugScript : MonoBehaviour
{
    void Start()
    {
        // Task 1
        Debug.Log("---------Task 1---------");
        Debug.Log(Task1_PrintSumOfEvenNumbersInRange(7, 21));

        // Task 2
        int[] arr = new int[] { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        Debug.Log("---------Task 2---------");
        PrintArray(arr);
        Debug.Log(Task2_PrintSumOfEvenNumbersInArray(arr));

        // Task 3
        Debug.Log("---------Task 3---------");
        PrintArray(arr);
        Debug.Log($"Индекс числа 13 = {Task3_PrintFirstIndexOfNumberInArray(arr, 13)}");
        Debug.Log($"Индекс числа 70 = {Task3_PrintFirstIndexOfNumberInArray(arr, 70)}");

        // Task 4
        Debug.Log("---------Task 4---------");
        int[] arr2 = GetRandomArray(20);
        Debug.Log("Массив до сортировки выбором:");
        PrintArray(arr2);

        ChooseSort(arr2);
        Debug.Log("Массив после сортировки выбором:");
        PrintArray(arr2);

    }

    private int[] GetRandomArray(int len)
    {
        System.Random rand = new System.Random();
        int[] arr = new int[len];
        for (int i = 0; i < len; i++)
        {
            arr[i] = rand.Next(-100, 101);
        }
        return arr;
    }

    private void PrintArray(int[] arr)
    {
        Debug.Log(string.Join(", ", arr));
    }

    private int Task1_PrintSumOfEvenNumbersInRange(int left, int right)
    {
        int result = 0;
        for (int i = left; i <= right; i++)
        {
            if (i % 2 == 0)
                result += i;
        }
        return result;
    }

    private int Task2_PrintSumOfEvenNumbersInArray(int[] arr)
    {
        int result = 0;
        foreach (var el in arr)
        {
            if(el % 2 == 0)
                result += el;
        }
        return result;
    }

    private int Task3_PrintFirstIndexOfNumberInArray(int[] arr, int el)
    {
        int result = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == el)
                result = i;
        }
        return result;
    }

    private void ChooseSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min = arr[i];
            int min_ind = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < min)
                {
                    min = arr[j];
                    min_ind = j;
                }
            }
            int tmp = arr[i];
            arr[i] = min;
            arr[min_ind] = tmp;
        }
    }
}
