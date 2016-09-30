using System;
using System.IO;

using NUnit.Framework;

[TestFixture]
class DataFileMaker {
    [Test]
    public void CreateFileExample4() {
        using (StreamWriter sw = File.CreateText(@"F:\Dev\Anagram\TestData\example4.txt")) {
            for (Int32 i = 0; i < 100000; i++) {
                sw.WriteLine("кот");
                sw.WriteLine("ток");
                sw.WriteLine("кто");
                sw.WriteLine("уклон");
                sw.WriteLine("колун");
                sw.WriteLine("вертикаль");
                sw.WriteLine("кильватер");
                sw.WriteLine("отк");
                sw.WriteLine("тко");
                sw.WriteLine("наказ");
                sw.WriteLine("казан");
            }
        }

        Assert.True(false); // Это не тест
    }
    [Test]
    public void CreateFileExample5() {
        // С этими данными программа работает 40 секунд. 
        // Будем считать их за репер производительности для многопоточной версии.
        using (StreamWriter sw = File.CreateText(@"F:\Dev\Anagram\TestData\example5.txt")) {
            for(Int64 i = 0; i < 10000000; i++)
                sw.WriteLine(i);
        }

        Assert.True(false); // Это не тест
    }
    [Test]
    public void CreateFileExample6() {
        // Здесь будет генерироваться большой входной файл (размер 380 МБ).
        // С этими входными данными однопоточное приложение доходит до потребления 2.2ГБ памяти
        // и работает 3 минуты 20 секунд.
        // Это практически предел нормальной работы приложения на моей машине,
        // дальнейшее увеличение объема входных данных приводит к OutOfMemoryException.

        using (StreamWriter sw = File.CreateText(@"F:\Dev\Anagram\TestData\example6.txt")) {
            for (Int64 i = 0; i < 40000000; i++)
                sw.WriteLine(i);
        }

        Assert.True(false); // Это не тест
    }
}
