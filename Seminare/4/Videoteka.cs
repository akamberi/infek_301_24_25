public class Videoteka
{
    public List<Film> Filmat { get; set; }
    public Videoteka()
    {
        Filmat = new List<Film>();  
    }
    public void ShtoFilm()
    {
        var film = Film.KrijoFilm();
        Filmat.Add(film);
    }
    public List<Film> KerkoFilm(string query)
    {
        List<Film> result = new List<Film>();
        foreach (Film film in Filmat)
        {
            if (film.Titulli.ToLower().Contains(query.ToLower()))
            {
                result.Add(film);
            }
            else if (film.Zhanri.ToString().ToLower().Contains(query.ToLower()))
            {
                result.Add(film);
            }
        }
        return result;
    }
    public void AfishoTeGjitheFilmat ()
    {
        foreach (Film film in Filmat)
        {
            film.AfishoInformacion();
        }
    }
}
