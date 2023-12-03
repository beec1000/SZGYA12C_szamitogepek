using System.Text;

namespace szamitogepek
{
    public class Program
    {
        static List<Szamitogep> F7(List<Szamitogep> sz)
        {
            return sz.Where(d => d.OS.Contains("Windows") && d.KijelzoMeret > 20).ToList();
        }

        static List<Szamitogep> F8(List<Szamitogep> sz)
        {
            var x = sz.Min(d => d.Sebesseg);
            var legmagasabb = sz.Where(d => d.Sebesseg == x).ToList();
            return legmagasabb;
        }

        static double F9(List<Szamitogep> sz)
        {
            return sz.Average(d => d.RAM);
        }

        static List<string> F10(List<Szamitogep> sz)
        {
            var x = sz.Where(d => d.Tipus == "DDR4");
            return x.Select(d => d.Gyarto).Distinct().OrderBy(d => d).ToList();
        }

        static List<Szamitogep> F11(List<Szamitogep> sz)
        {
            return sz.Where(d => d.CPU.Contains("Intel") && d.KijelzoMeret < 20).ToList();
        }

        static void Main(string[] args)
        {
            var szamitogepek = new List<Szamitogep>();

            using var sr = new StreamReader(@"..\..\..\src\szamitogepek.txt");
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    szamitogepek.Add(new Szamitogep(sr.ReadLine()));
                }
            }

            foreach (var i in szamitogepek) Console.WriteLine(i);

            Console.WriteLine("7.feladat");
            var f7 = F7(szamitogepek);
            if (f7.Count > 0)
            {
                Console.WriteLine($"{f7.Count}db ilyen gép van");
            }
            else
            {
                Console.WriteLine("HIBA 404!");
            }

            Console.WriteLine("8.feladat");
            var f8 = F8(szamitogepek);
            foreach (var i in f8)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"{f8.First().Sebesseg} Ghz a leglassabb sebesség, {f8.Count} db");

            Console.WriteLine("9.feladat");
            Console.WriteLine($"{Math.Round(F9(szamitogepek)), 2} GB az átlag memóriaméret.");

            Console.WriteLine("10.feladat");
            var f10 = F10(szamitogepek);
            if (f10.Count == 0)
            {
                Console.WriteLine("HIBA 404!");
            }
            else
            {
                Console.WriteLine($"gyártók: {string.Join(", ", f10)}");
            }

            Console.WriteLine("11.feladat");
            Console.WriteLine($"{string.Join(", ", F11(szamitogepek).Select(d => d.Azonosito))}");
            
            using var sw = new StreamWriter(@"..\..\..\src\szamitogepekCm.txt");
            {
                foreach (var i in szamitogepek)
                {
                    sw.WriteLine($"{i.Gyarto}{i.Modell}, {Math.Round(i.KijelzoMeretCm, 2)}cm");
                }
            }
        }
    }
}