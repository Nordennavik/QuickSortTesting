﻿using System;
using NUnit.Framework;

namespace SortTesting
{
    [TestFixture]
    class SortTests
    {
        [Test]
        public void SortSimpleArray()
        {
            var array = GenerateRandomArray(3);
            Sort.QuickSort(array, 0, array.Length -1);
            Assert.That(array[0] < array[1] && array[1] < array[2], "Simple array sorting");
        }

        /// <summary>
        /// Сортировка массива из 100 одинаковых числе работает корректно
        /// </summary>
        [Test]
        public void SortArrayEqualsElements()
        {
            var array = new int[100];
            Sort.QuickSort(array, 0, array.Length - 1);
            foreach (var n in array)
                Assert.That(n == array[0]);
        }


        /// <summary>
        /// Сортировка массива из 1000 случайных элементов.
        /// Проверить что 10 случайных пар элементов массива после сортировки упорядочены
        ///   (из пары больший тот, чей индекс больше)
        /// </summary>
        [Test]
        public void SortNormalArray()
        {
            var array = GenerateRandomArray(1000);
            var indexes = GenerateRandomArray(20, array.Length);
            Sort.QuickSort(array, 0, array.Length - 1);
            for (var i = 0; i < indexes.Length; i += 2)
                Assert.That((array[indexes[i]] < array[indexes[1 + i]] && indexes[i] < indexes[1 + i]) ||
                            (array[indexes[i]] > array[indexes[1 + i]] && indexes[i] > indexes[1 + i]), "Normal array sorting");
        }

        /// <summary>
        /// Сортировка пустого массива работает корректно
        /// </summary>
        [Test]
        public void SortEmptyArray()
        {
            var array = new int[0];
            Sort.QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Сортировка массива из 1 500 000 000 элементов
        /// </summary>
        [Test]
        public void SortHugeArray()
        {
            var array = GenerateRandomArray(1500000000);
            Sort.QuickSort(array, 0, array.Length - 1);
            for (var i = 1; i < array.Length; i++)
                Assert.That(array[i - 1] < array[i]);
        }

        static int[] GenerateRandomArray(int length, int maxEl = int.MaxValue)
        {
            var random = new Random(50);
            var array = new int[length];
            for (var i = 0; i < length; ++i)
                array[i] = random.Next(maxEl);
            return array;
        }
    }
}
