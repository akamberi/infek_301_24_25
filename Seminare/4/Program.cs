using ConsoleApp6;

public class Program
{
    public static void Main(string[] args)
    {
        //Film f1 = Film.KrijoFilm();
        //f1.AfishoInformacion();
        //f1.Titulli = "Titaniku";
        //f1.Regjizori = "Njeri";
        //f1.VitiPublikimit = 2000;
        //f1.Zhanri = ZhanriFilm.DRAME;
        //f1.Rating = 3.7f;
        //f1.AfishoInformacion();
        Videoteka v1 = new Videoteka();
        v1.ShtoFilm();
        v1.ShtoFilm();
        v1.AfishoTeGjitheFilmat();
    }
}