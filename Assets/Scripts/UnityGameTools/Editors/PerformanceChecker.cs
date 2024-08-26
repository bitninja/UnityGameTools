using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace UnityGameTools.Editor
{
    public class PerformanceChecker : MonoBehaviour
    {
        [MenuItem("PerformanceChecker/Random Array Sort Speed")]
        static void CheckCollectionUtilsRandomizeSpeed()
        {
            const string DIALOG_TITLE = "Randomize Performance";

            if (!EditorUtility.DisplayDialog(DIALOG_TITLE, "This checks the speed of how quickly arrays can be randomized.", "ok", "cancel"))
            {
                return;
            }

            var arraySizes = new int[] { 10, 100, 1000, 10000 };
            var iterations = 10000;
            var stopWatches = new List<Stopwatch>();
            var nanosPerItems = new List<double>();

            var message = new StringBuilder();
            message.AppendLine($"Iterations: {iterations}");

            for (int arraySizesIndex = 0; arraySizesIndex < arraySizes.Length; arraySizesIndex++)
            {
                var arraySize = arraySizes[arraySizesIndex];
                var array = Enumerable.Range(0, arraySize).ToArray();
                var stopWatch = new Stopwatch();
                stopWatches.Add(stopWatch);

                stopWatch.Start();

                for (int i = 0; i < iterations; i++)
                {
                    CollectionUtils.Randomize(array);
                }

                stopWatch.Stop();

                var overallTime = stopWatch.Elapsed.TotalMilliseconds;
                var timePerArray = overallTime / iterations;
                var nanosPerItem = 1000000.0 * (timePerArray / arraySize);
                nanosPerItems.Add(nanosPerItem);
                message.AppendLine($"Array Size={arraySize} TotalTimeMillis={overallTime} MillisPerSort={timePerArray} NanosPerItem={nanosPerItem}");

                EditorUtility.DisplayProgressBar(DIALOG_TITLE, $"Completed array {arraySizesIndex + 1} / {arraySizes.Length}", (arraySizesIndex + 1.0f) / arraySizes.Length);
            }

            message.AppendLine($"PerArrayElement (Nanoseconds) Min={nanosPerItems.Min()} Max={nanosPerItems.Max()} Average={nanosPerItems.Average()}");


            EditorUtility.DisplayDialog(DIALOG_TITLE, message.ToString(), "ok");
        }

        [MenuItem("PerformanceChecker/Check Randomize Distribution")]
        static void CheckRandomizeDistribution()
        {
            const string DIALOG_TITLE = "Randomize Distribution";

            if (!EditorUtility.DisplayDialog(DIALOG_TITLE, "This checks the random distribution of the randomize method.", "ok", "cancel"))
            {
                return;
            }

            var arraySize = 10;
            var iterations = 10000;

            var slotCounts = new int[arraySize, arraySize];

            for (int i = 0; i < iterations; i++)
            {
                var array = Enumerable.Range(0, arraySize).ToArray();
                CollectionUtils.Randomize(array);

                // Count occurrences of each number in each slot
                for (int j = 0; j < arraySize; j++)
                {
                    slotCounts[array[j], j]++;
                }
            }

            var message = new StringBuilder();
            message.AppendLine($"Randomize Distribution Check:");
            message.AppendLine($"Array Size: {arraySize}, Iterations: {iterations}");

            for (int i = 0; i < arraySize; i++)
            {
                message.Append($"Number {i}: ");
                for (int j = 0; j < arraySize; j++)
                {
                    message.Append($"Slot {j}={slotCounts[i, j]} ");
                }
                message.AppendLine();
            }

            var allCounts = slotCounts.Cast<int>();
            var averageCount = allCounts.Average();
            var minCount = allCounts.Min();
            var maxCount = allCounts.Max();

            message.AppendLine($"\nSlot Statistics Average={averageCount} Min={minCount} Max={maxCount}");


            EditorUtility.DisplayDialog(DIALOG_TITLE, message.ToString(), "ok");
        }
    }
}