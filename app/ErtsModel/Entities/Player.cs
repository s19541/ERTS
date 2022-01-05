namespace ErtsModel.Entities {
    public class Player : ModelBase {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nick { get; set; }
        public string Nationality { get; set; }
        public int ApiId { get; set; }
    }
}
