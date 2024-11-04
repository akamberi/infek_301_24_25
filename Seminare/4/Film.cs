public class Film
{
    public string Titulli { get; set; }
    public string Regjizori { get; set; }

    private int _viti;
    public int VitiPublikimit
    {
        get
        {
            return _viti;
        }
        set
        {
            if (value < 1888 || value > 2100)
            {
                Console.WriteLine("Viti duhet te jete midis 1888 dhe 2100");
                return;
            }
            _viti = value;
        }
    }
    public ZhanriFilm Zhanri { get; set; }

    private float _rating;
    public float Rating
    {
        get { return _rating; }
        set
        {
            if (value < 0 || value > 5)
            {
                Console.WriteLine("Rating i filmit duhet te jete midis 0.0 dhe 5.0");
                return;
            }
            _rating = value;
        }
    }

    public void AfishoInformacion()
    {
        Console.WriteLine(@$"
Titulli: {Titulli},
Regjizori: {Regjizori},
Zhanri: {Zhanri},
Viti: {VitiPublikimit},
Rating: {Rating:0.0}
");
    }

    public static Film KrijoFilm()
    {
        Film result = new Film();
        Console.WriteLine("===Jepni te dhenat per krijimin e nje filmi===");
        Console.Write("Jep titullin: ");
        result.Titulli = Console.ReadLine();
        Console.Write("Jep regjizorin: ");
        result.Regjizori = Console.ReadLine();

        while (result.VitiPublikimit == 0)
        {
            Console.Write("Jep vitin e publikimit: ");
            string vitiNr = Console.ReadLine();
            int.TryParse(vitiNr, out int viti);
            result.VitiPublikimit = viti;
        }
        result.Zhanri = ZhanriFilm.None;
        while (result.Zhanri == ZhanriFilm.None)
        {
            Console.WriteLine("Zgjidh zhanrin (shkruaj)");
            Console.WriteLine("1. Komedi");
            Console.WriteLine("2. Aksion");
            Console.WriteLine("3. Drame");
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "Komedi")
            {
                result.Zhanri = ZhanriFilm.KOMEDI;
            }
            else if (choice == "2" || choice == "Aksion")
            {
                result.Zhanri = ZhanriFilm.AKSION;
            }
            else if (choice == "3" || choice == "Drame")
            {
                result.Zhanri = ZhanriFilm.DRAME;
            }
            else
            {
                Console.WriteLine("Zhanri duhet te jete 1,2 ose 3");
            }
        }

        result._rating = -1;
        while (result._rating == -1)
        {
            float rating;
            do
            {
                Console.Write("Jep rating: ");
            } while (!float.TryParse(Console.ReadLine(), out rating));
            result.Rating = rating;
        }

        return result;
    }


}
