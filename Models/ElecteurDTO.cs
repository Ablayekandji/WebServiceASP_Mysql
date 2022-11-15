namespace DevoirPA.Models
{
    public class ElecteurDTO
    {

        public string Numero { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Lieu { get; set; }
        public DateTime Ladate { get; set; }

        //un electeur(num, nom, lieu de residence) 
        //centre(num, nom,lieu) 
        //bureau(num, centre, capac)
        //private DevoirPA context;

        //Scaffold-DbContext "server=localhost;port=3306;user=root;password=;database=devoirpa" MySql.EntityFrameworkCore -OutputDir Entities -f

    }
}
