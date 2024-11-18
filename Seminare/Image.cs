public class Image
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Contains(' '))
            {
                throw new ArgumentOutOfRangeException("Emri i skedarit nuk permban dot hapesira");
            }
            if (value.Length > 0 && value[0] == '.')
            {
                throw new ArgumentOutOfRangeException("Emri i skedarit nuk fillon dot me .");
            }
            _name = value;
        }
    }

    private int _size;
    public int Size
    {
        get
        {
            return _size;
        }
        set
        {
            var maxSize = 5 * 1024 * 1024;
            if (value > maxSize)
            {
                throw new ArgumentOutOfRangeException("Madhesia maksimale e imazhit duhet te jete 5MB");
            }
            _size = value;
        }
    }

    public string FilePath { get; set; }

    public override string ToString()
    {
        return $"Emri: {Name}\nMadhesia: {Size}byte;\nPath: {FilePath}";
    }

    public static Image KrijoImazh()
    {
        Console.Write("Jep emrin e img: ");
        string name = Console.ReadLine();
        Console.Write("Jep peshen e img: ");
        int size = int.Parse(Console.ReadLine());
        Console.Write("Jep pathin e img: ");
        string path = Console.ReadLine();
        return new Image
        {
            Name = name,
            Size = size,
            FilePath = path
        };
    }
}

public class Program
{
    static List<Image> Images = new List<Image>();

    static void Main(string[] args)
    {
        do
        {
            var img = Image.KrijoImazh();
            Images.Add(img);
            Console.WriteLine("Deshironi te shtoni imazh tjeter? (po per te vijuar ose cdo gje tjeter per te perfunduar hyrjen e te dhenave)");
        } while (Console.ReadLine() == "po");

        foreach (var img in Images)
        {
            Console.WriteLine(img);
        }

        var mb2Size = 2 * 1024 * 1024;
        var mb4Size = 4 * 1024 * 1024;
        int nrImages = 0;
        foreach (var img in Images)
        {
            if (img.Size >= mb2Size && img.Size <= mb4Size)
            {
                nrImages++;
            }
        }
        Console.WriteLine($"Ka {nrImages} imazhe me peshe 2MB - 4MB");

        int maxSize = 0;
        int minSize = int.MaxValue;
        Image maxSizeImg = null;
        Image minSizeImg = null;
        foreach (var img in Images)
        {
            if (img.Size > maxSize)
            {
                maxSizeImg = img;
                maxSize = img.Size;
            }
            if (img.Size < minSize)
            {
                minSizeImg = img;
                minSize = img.Size;
            }
        }
        Console.WriteLine($"Img me peshen max: {maxSizeImg.Name}; Me path: {maxSizeImg.FilePath}");
        Console.WriteLine($"Img me peshen min: {minSizeImg.Name}; Me path: {minSizeImg.FilePath}");
    }
}
