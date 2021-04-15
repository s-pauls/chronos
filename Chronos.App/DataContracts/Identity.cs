namespace Chronos.App.DataContracts
{
    public class Identity
    {
        public Identity()
        {
        }

        public Identity(in int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
