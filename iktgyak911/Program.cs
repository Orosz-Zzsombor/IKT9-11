static void Main(string[] args)
{
    Console.WriteLine("Adjon meg egész számokat");
    if (args.Length % 2 != 1)
    {
        Console.WriteLine("Nem megfelelő argumentszám");
    }
    else
    {
        int kozepsoIndex = args.Length / 2;
        int nagyobb = int.Parse(args[kozepsoIndex - 1]) > int.Parse(args[kozepsoIndex + 1]) ? int.Parse(args[kozepsoIndex - 1]) : int.Parse(args[kozepsoIndex + 1]);
        int kisebb = int.Parse(args[kozepsoIndex - 1]) < int.Parse(args[kozepsoIndex + 1]) ? int.Parse(args[kozepsoIndex - 1]) : int.Parse(args[kozepsoIndex + 1]);

        double eredmeny = Math.Pow(int.Parse(args[kozepsoIndex]), nagyobb / kisebb);
        Console.WriteLine(eredmeny);
    }




    List<string> beolvasas = new List<string>();

    File.ReadAllLines("szavak.txt").ToList().ForEach(line => beolvasas.Add(line));
    List<char> maganhangzok = new List<char>() { 'A', 'E', 'I', 'O', 'U' };
    int maganhangzokSzama = 0;
    int tobbmintnegy = 0;
    int legnagyobb = 0;
    Console.WriteLine(beolvasas.Count);
    foreach (var item in beolvasas)
    {

        foreach (char ch in item)
        {
            if (maganhangzok.Contains(ch)) maganhangzokSzama++;

        }
        if (maganhangzokSzama > 4)
        {
            tobbmintnegy++;
        }
        if (legnagyobb < maganhangzokSzama)
        {
            legnagyobb = maganhangzokSzama;
        }
        maganhangzokSzama = 0;
    }
    Console.WriteLine($"Négy szótagból álló szavak száma: {tobbmintnegy}");
    Console.WriteLine($"Legnagyobb szótagszám: {legnagyobb}");

    Random rnd = new Random();

    int[,] arr1 = new int[6, 6];
    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 6; j++)
        {

            arr1[i, j] = rnd.Next(55, 156);
        }
    }
    double atlag = 0;

    for (int i = 0; i < 6; i++)
    {
        Console.Write("\n");
        for (int j = 0; j < 6; j++)
        {
            if (i == 0 || j == 0 || i == 5 || j == 5)
            {
                atlag += arr1[i, j];
            }
            Console.Write("{0}\t", arr1[i, j]);
        }
    }
    Console.Write("\n\n");
    Console.WriteLine($"Átlag = {Math.Round(atlag / 36),2} ");
    ;
    Console.ReadKey();

    string[] lines = File.ReadAllLines("kep.txt");
    string[][] imageData = lines.Select(line => line.Split(';')).ToArray();

    // Modify the image data
    string[][] modifiedImageData = new string[imageData.Length][];
    for (int i = 0; i < imageData.Length; i++)
    {
        modifiedImageData[i] = new string[imageData[i].Length];
        for (int j = 0; j < imageData[i].Length; j++)
        {
            string[] rgb = imageData[i][j].Split(',');
            int r = int.Parse(rgb[0]);
            int g = int.Parse(rgb[1]);
            int b = int.Parse(rgb[2]);
            if (b < 100)
            {
                b += 20;
            }
            modifiedImageData[i][j] = $"{r},{g},{b}";
        }
    }


    using (StreamWriter writer = new StreamWriter("kekitett.txt"))
    {
        for (int i = 0; i < modifiedImageData.Length; i++)
        {
            writer.WriteLine(string.Join(";", modifiedImageData[i]));
        }
    }

    Console.WriteLine("#Kész!");
}

Main(args);