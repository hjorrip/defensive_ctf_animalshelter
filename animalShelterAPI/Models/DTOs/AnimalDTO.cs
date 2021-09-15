namespace AnimalAPI{
    public class AnimalDTO
    {
        public AnimalDTO(string name, string species, string imgurl, string description)
        {
            this.Name = name;
            this.Species = species;
            this.IMGUrl = imgurl;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Species { get; set; }
        public string IMGUrl { get; set; }
        public string Description { get; set; }

    }

}
