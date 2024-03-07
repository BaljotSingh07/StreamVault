namespace StreamVault.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public ICollection<Cast> Cast { get; set; }
        public ICollection<Crew> Crew { get; set; }
    }
}
